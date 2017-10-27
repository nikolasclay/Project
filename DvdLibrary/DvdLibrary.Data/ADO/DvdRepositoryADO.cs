using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Model;
using System.Data.SqlClient;
using System.Data;

namespace DvdLibrary.Data.ADO
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                //cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@RatingType", dvd.RatingType);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
        }

        public void DeleteDvd(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void EditDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EditDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@RatingType", dvd.RatingType);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.DirectorName = dr["DirectorName"].ToString();
                        dvd.RatingType = dr["RatingType"].ToString();
                        dvd.Notes = dr["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }
        }

        public Dvd GetDvdById(int id)
        {
            Dvd dvd = new Dvd();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.DirectorName = dr["DirectorName"].ToString();
                        dvd.RatingType = dr["RatingType"].ToString();
                        dvd.Notes = dr["Notes"].ToString();

                    }
                }
                return dvd;
            }
        }

        public List<Dvd> GetDvdsbyDirector(string director)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DirectorName", director);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.DirectorName = dr["DirectorName"].ToString();
                        dvd.RatingType = dr["RatingType"].ToString();
                        dvd.Notes = dr["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }
        }

        public List<Dvd> GetDvdsbyRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RatingType", rating);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.DirectorName = dr["DirectorName"].ToString();
                        dvd.RatingType = dr["RatingType"].ToString();
                        dvd.Notes = dr["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }
        }

        public List<Dvd> GetDvdsByReleaseYear(int year)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdByYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ReleaseYear", year);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.DirectorName = dr["DirectorName"].ToString();
                        dvd.RatingType = dr["RatingType"].ToString();
                        dvd.Notes = dr["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", title);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.DirectorName = dr["DirectorName"].ToString();
                        dvd.RatingType = dr["RatingType"].ToString();
                        dvd.Notes = dr["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }
        }
    }
}
