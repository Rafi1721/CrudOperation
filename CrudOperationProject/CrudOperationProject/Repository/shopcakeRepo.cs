using CrudOperationProject.Model;
using CrudOperationProject.Repository.Interface;
using MySql.Data.MySqlClient;
using System.Data;

namespace CrudOperationProject.Repository
{
    public class shopcakeRepo : Ishopcakerepo
    {

        private readonly ILogger<shopcakeRepo> logger;
        private IConfiguration _Configuration;

        public shopcakeRepo(IConfiguration configuration, ILogger<shopcakeRepo> logger)
        {
            this.logger = logger;
            _Configuration = configuration;
        }

        public List<ShopCake>GetCakes(string CName)
        {

            try
            {
                if (string.IsNullOrEmpty(CName))
                    CName = string.Empty;

                var cakesList = new List<ShopCake>();

                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("CakeGet_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_Name", CName);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var cakes = new ShopCake();
                    cakes.Id = Convert.ToInt32(reader["Id"]);
                    cakes.Name = reader["Name"].ToString();



                    cakesList.Add(cakes);
                }
                con.Close();
                return cakesList;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

      

        public ShopCake GetCakesById(int Id)
        {

            try
            {
                ShopCake shopcake = null;

                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("CakeGetById_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_cakeId", Id);
                

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    shopcake = new ShopCake();
                    shopcake.Id = Convert.ToInt32(reader["Id"]);
                    shopcake.Name = reader["Name"].ToString();


                }
                con.Close();
                return shopcake;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }

        }

        

        public int SaveCakes(ShopCake ShopCake)
        {


            try
            {
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("CakeInsert_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_Name", ShopCake.Name);
                cmd.Parameters.AddWithValue("_Id", ShopCake.Id);
                var cakesId = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                return cakesId;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }

        }

        public int Updatecakes(ShopCake ShopCake)
        {

            try
            {
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("CakeUpdate_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_Id", ShopCake.Id);
                cmd.Parameters.AddWithValue("_Name", ShopCake.Name);
                var res = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                return res;
            }

            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }
        }
    }
}







