using Data;
using PriceConfigurator.Model;
using PriceConfigurator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceConfigurator.Controllers
{
    public class HomeController : Controller
    {
        //first determine current mode i.e. EF, ADO, etc
        IAppRepo _repo = AppFactory.Create();
        AppDbContext _ctx = new AppDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var vm = new AppVM();
            vm.App = _repo.GetAppById(id);
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(AppVM model)
        {
            if (model.App.SuggestedPrice == 0)
            {
                string fileExt = Path.GetExtension(model.CsvUpload.FileName);
                if (fileExt == ".csv")
                {
                    string csvPath = Server.MapPath("~/CSVFiles/") + Path.GetFileName(model.CsvUpload.FileName);
                    model.CsvUpload.SaveAs(csvPath);
                    var lines = System.IO.File.ReadAllLines(csvPath);
                    if (lines.Count() == 0)
                    {
                        return View(model);
                    }
                    var columns = lines[0].Split(',');
                    var table = new DataTable();
                    foreach (var c in columns)
                    {
                        table.Columns.Add(c);
                    }
                    for (int i = 1; i < lines.Count() - 1; i++)
                    {
                        table.Rows.Add(lines[i].Split(','));
                    }
                    var connection = @"Server=localhost;Database=PriceConfigurator;Integrated Security=True;";
                    var sqlBulk = new SqlBulkCopy(connection);
                    sqlBulk.DestinationTableName = "dbo.Apps";
                    sqlBulk.WriteToServer(table);
                }
 
                //string fileExt = Path.GetExtension(model.CsvUpload.FileName);
                //if (fileExt == ".csv")
                //{
                //    string csvPath = Server.MapPath("~/CSVFiles/") + Path.GetFileName(model.CsvUpload.FileName);
                //    model.CsvUpload.SaveAs(csvPath);

                //    //Add columns to Datatable to bind data
                //    DataTable dataTable = new DataTable();
                //    dataTable.Columns.AddRange(new DataColumn[4] { new DataColumn("AppId", typeof(int)),
                //    new DataColumn("Title", typeof(string)),
                //    new DataColumn("CurrentPrice", typeof(double)),
                //    new DataColumn("SuggestedPrice", typeof(double))
                //});

                //    //Read all the lines from the text file and close it
                //    string csvData = System.IO.File.ReadAllText(csvPath);

                //    //iterate over each row and Split it to new line.
                //    foreach (string row in csvData.Split('\n'))
                //    {
                //        //check for null or empty row record
                //        if (!string.IsNullOrEmpty(row))
                //        {
                //            dataTable.Rows.Add();
                //            int i = 0;
                //            foreach (string cell in row.Split(','))
                //            {
                //                dataTable.Rows[dataTable.Rows.Count - 1][i] = cell;
                //                i++;
                //            }
                //        }
                //    }
                //    //Database connection string
                //    string connectS = ConfigurationManager.ConnectionStrings["PriceConfigurator"].ConnectionString;
                //    using (SqlConnection con = new SqlConnection(connectS))
                //    {
                //        //class use to bulk load data from another source
                //        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                //        {
                //            //Set the database table name in which data to be added
                //            sqlBulkCopy.DestinationTableName = "dbo.Apps";
                //            con.Open();
                //            //copy all the rows from dataTable to destination table
                //            sqlBulkCopy.WriteToServer(dataTable);
                //            con.Close();
                //        }
                //    }
                //}
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var toReturn = _repo.GetAppById(model.App.AppId);
                    toReturn.AppId = model.App.AppId;
                    toReturn.CurrentPrice = model.App.SuggestedPrice;
                    _repo.UpdateApp(toReturn);
                    return RedirectToAction("Edit");
                }
            }
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}