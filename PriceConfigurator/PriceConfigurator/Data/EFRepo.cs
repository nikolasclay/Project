using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceConfigurator.Model;

namespace Data
{
    //Inherit from interface and implement members
    public class EFRepo : IAppRepo
    {
        //create ref to DbContext object. DbContext object allows you to interact with the DB
        AppDbContext _ctx = new AppDbContext();

        public void AddApp(App app)
        {
            //checks if table is empty. If so set ID to 1
            if(_ctx.Apps.Count() == 0)
            {
                app.AppId = 1;
            }
            else
            {
                //find the max ID in the table and add 1
                var maxID = _ctx.Apps.Max(a => a.AppId);

                //set the AppId to the value stored in maxId variable
                app.AppId = maxID;
            }
            _ctx.Apps.Add(app);
            _ctx.SaveChanges();
        }

        public void DeleteApp(int id)
        {
            //find the app by ID and assign to variable t
            App t = _ctx.Apps.Find(id);

            //Remove the application
            _ctx.Apps.Remove(t);

            //save changes
            _ctx.SaveChanges();
        }

        //returns all apps
        public IEnumerable<App> GetAll()
        {
            return _ctx.Apps.ToList();
        }
        
        //returns single app by ID
        public App GetAppById(int id)
        {
            return _ctx.Apps.FirstOrDefault(a => a.AppId == id);
        }
        
        //returns single app by title
        public App GetAppByTitle(string title)
        {
            return _ctx.Apps.FirstOrDefault(t => t.Title == title);
        }

        //
        public void UpdateApp(App app)
        {
            //.Entry provides info about entity and ability to perform action on entity. State tracks current entity state which is set to Modified and indicates changes have occurred.
            _ctx.Entry(app).State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
