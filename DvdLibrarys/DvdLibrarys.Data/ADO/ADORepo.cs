using DvdLibrarys.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrarys.Data.ADO
{
    public class ADORepo : IDvdRepository
    {
        // Return all the dvds in the database
        public List<Dvd> GetAll()
        {
            List<Dvd> dvd = new List<Dvd>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.Title = dr["Title"].ToString();

                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        }

                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.DirectorName = dr["DirectorName"].ToString();
                        dvd.Add(currentRow);
                    }

                }
            }
            return dvd;
        }

        // Return single Dvd
        public Dvd GetOne(int dvdId)
        {
            Dvd dvd = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DvdId", dvdId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Title = dr["Title"].ToString();
                        if (dr["ReleaseYear"] != DBNull.Value)
                        {
                            dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        }
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.DirectorName = dr["DirectorName"].ToString();
                    }
                }
            }
            return dvd;
        }

        // Return Dvd by it is director
        public List<Dvd> GetByDirectorName(string director)
        {
            throw new NotImplementedException();
        }

        // Return Dvd by its title
        public List<Dvd> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        // Return Dvd by its  ratings
        public List<Dvd> GetByRating(string rating)
        {
            throw new NotImplementedException();
        }

        // Return Dvd by its year
        public List<Dvd> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

        // Add new dvd
        public void Add(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);


                cn.Open();
                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)param.Value;
            }
        }

        // Edit Dvd
        public void Edit(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);


                cn.Open();
                cmd.ExecuteNonQuery();


            }
        }

        // Delete Dvd
        public void Delete(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DvdDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();
                cmd.ExecuteNonQuery();


            }
        }

        
    }
}
