using DvdModels.Interfaces;
using DvdModels.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdData.Repositories
{
    public class DvdRepositoryADO : IDvdRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DvdLibraryADO"].ConnectionString;

        public void Create(Dvd dvd)
        {
            if (dvd.Title == " " || string.IsNullOrEmpty(dvd.Title))
            {
                return;
            }

            //Empty or invalid release year 
            else if (dvd.ReleaseYear < 1000 || dvd.ReleaseYear > 9999)
            {
                return;
            }

            //Empty director name
            else if (dvd.Director == " " || string.IsNullOrEmpty(dvd.Director))
            {
                return;
            }

            //Empty rating 
            else if (dvd.Rating == " " || string.IsNullOrEmpty(dvd.Rating))
            {
                return;
            }

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@DvdID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Title", dvd.Title);
                parameters.Add("@ReleaseYear", dvd.ReleaseYear);
                parameters.Add("@Director", dvd.Director);
                parameters.Add("@Rating", dvd.Rating);
                parameters.Add("@Notes", dvd.Notes);

                conn.Execute("CreateDvd", param: parameters, commandType: CommandType.StoredProcedure);

                dvd.DvdId = parameters.Get<int>("@DvdID");
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@DvdID", id);

                conn.Execute("DeleteDvd", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public Dvd Get(int id)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@DvdID", id);

                return conn.Query<Dvd>("GetDvd", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();

            }
        }

        public List<Dvd> GetAll()
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                List<Dvd> dvds =  conn.Query<Dvd>("GetAll", commandType: CommandType.StoredProcedure).ToList();

                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }
        }

        public List<Dvd> GetAllByDirector(string director)
        {
            if (string.IsNullOrEmpty(director))
            {
                return null;
            }

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Director", director);

                List<Dvd> dvds = conn.Query<Dvd>("GetAllByDirector", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }
        }

        public List<Dvd> GetAllByRating(string rating)
        {
            if (string.IsNullOrEmpty(rating))
            {
                return null;
            }

            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Rating", rating);

                List<Dvd> dvds = conn.Query<Dvd>("GetAllByRating", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }
        }

        public List<Dvd> GetAllByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return null;
            }
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@Title", title);

                List<Dvd> dvds = conn.Query<Dvd>("GetAllByTitle", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }
        }

        public List<Dvd> GetAllByYear(int releaseYear)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@ReleaseYear", releaseYear);

                List<Dvd> dvds = conn.Query<Dvd>("GetAllByYear", param: parameters, commandType: CommandType.StoredProcedure).ToList();
                if (dvds.Any())
                {
                    return dvds;
                }
                return null;
            }
        }

        public void Update(Dvd dvd)
        {
            if (dvd.Title == " " || string.IsNullOrEmpty(dvd.Title))
            {
                return;
            }

            //Empty or invalid release year 
            else if (dvd.ReleaseYear < 1000 || dvd.ReleaseYear > 9999)
            {
                return;
            }

            //Empty director name
            else if (dvd.Director == " " || string.IsNullOrEmpty(dvd.Director))
            {
                return;
            }

            //Empty rating 
            else if (dvd.Rating == " " || string.IsNullOrEmpty(dvd.Rating))
            {
                return;
            }
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;

                var parameters = new DynamicParameters();

                parameters.Add("@DvdID", dvd.DvdId);
                parameters.Add("@Title", dvd.Title);
                parameters.Add("@ReleaseYear", dvd.ReleaseYear);
                parameters.Add("@Director", dvd.Director);
                parameters.Add("@Rating", dvd.Rating);
                parameters.Add("@Notes", dvd.Notes);


                conn.Execute("UpdateDvd", param: parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
