using DvdLibrary.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Model;
using System.Data.SqlClient;
using DvdLibrary.Data;
using System.Data;

namespace DVDLibrary.Data.ADO
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public void DeleteDvd(int id)
        {
            throw new NotImplementedException();
        }

        public void EditDvd(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.DirectorName = dr["DirectorName"].ToString();
                        currentRow.RatingType = dr["RatingType"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
                return dvds;
            }
        }

        public Dvd GetDvdById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsbyDirector(string director)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsbyRating(string rating)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsByReleaseYear(int year)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
