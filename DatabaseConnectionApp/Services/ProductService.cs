
using DatabaseConnectionApp.Models;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace DatabaseConnectionApp.Services
{

    public class ProductService
    {
        public ProductService() { }

        private static string db_source = "divyansh2020.database.windows.net";
        private static string db_user = "Pupulu";
        private static string db_password = "Divyansh@2020";
        private static string db_connectionstring = "";
        private static string db_database = "DivyanshDb";

        private SqlConnection CreateDatabaseConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection sqlConnection = CreateDatabaseConnection();
            List<Product> productsList = new List<Product>();
            string statement = "Select ProductId, ProductName, Quantity From Product";
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = statement;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product() { ProductId = reader.GetInt32(0), ProductName = reader.GetString(1), Quantity = reader.GetInt32(2) };
                    productsList.Add(product);
                }
            }
            sqlConnection.Close();
            return productsList;
        }
    }
}
