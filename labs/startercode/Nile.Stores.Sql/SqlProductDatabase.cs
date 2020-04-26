using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        public SqlProductDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        protected override Product AddCore ( Product product )
        {

            using (var conn = OpenConnection())
            using (var cmd = new SqlCommand("AddProduct", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                conn.Open();
                var result = (decimal)cmd.ExecuteNonQuery();
                product.Id = Convert.ToInt32(result);

                return product;
            }
        }

        protected override void RemoveCore ( int id )
        {
            var product = GetCore(id);
            if (product == null)
                return;

            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", GetCore(product.Id));

                conn.Open();
                cmd.ExecuteNonQuery();
            };

        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            var ds = new DataSet();

            //Create a connection and open
            using (var conn = OpenConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GetAllProducts";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var da = new SqlDataAdapter() {
                        SelectCommand = cmd
                    };

                    da.Fill(ds);
                };
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    var product = new Product() {
                        Id = (int)row[0],
                        Name = row["Name"] as string,
                        Description = row.Field<string>("Description"),
                        Price = row.Field<decimal>("Price"),
                        IsDiscontinued = row.Field<bool>("IsDiscontinued")
                    };

                    yield return product;
                };
            };
        }

        protected override Product GetCore ( int id )
        {
            using (var conn = OpenConnection())
            using (var cmd = new SqlCommand("GetProduct", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var NameIndex = reader.GetOrdinal("Name");
                        var PriceIndex = reader.GetOrdinal("Price");
                        var IsDiscontinuedIndex = reader.GetOrdinal("IsDiscontinued");

                        var product = new Product() {
                            Id = (int)reader[0],
                            Name = reader["Name"] as string,

                            Description = !reader.IsDBNull(3) ? reader.GetString(3) : "",
                            Price = (decimal)reader.GetValue(2),
                            IsDiscontinued = reader.GetBoolean(4)
                        };

                        return product;
                    };
                };
            };

            return null;

        }

        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var conn =OpenConnection())
            {

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetCore(existing.Id);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", newItem.Name);
                cmd.Parameters.AddWithValue("@description", newItem.Description);
                cmd.Parameters.AddWithValue("@price", newItem.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", newItem.IsDiscontinued);


                conn.Open();
                cmd.ExecuteNonQuery();
            };
            return UpdateCore(existing, newItem);
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }
    }
}
