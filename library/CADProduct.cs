using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            this.constring = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            
        }

  

        public bool Create(ENProduct en)
        {
            string query = "INSERT INTO Products(code, name, amount, category, price, creationDate) VALUES (@code, @name, @amount, @category, @price, @creationDate)";

            try
            {
                // Using block for the SqlConnection ensures that the connection is properly disposed of
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();

                    // Using block for the SqlCommand ensures that the command is properly disposed of
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        // Add parameters to the command with explicit types for safety
                        com.Parameters.Add("@code", System.Data.SqlDbType.NVarChar).Value = en.code;
                        com.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = en.name;
                        com.Parameters.Add("@amount", System.Data.SqlDbType.Int).Value = en.amount;
                        com.Parameters.Add("@category", System.Data.SqlDbType.Int).Value = en.category;
                        com.Parameters.Add("@price", System.Data.SqlDbType.Float).Value = en.price;
                        com.Parameters.Add("@creationDate", System.Data.SqlDbType.DateTime2).Value = en.creationDate;

                        // Execute the query
                        int rowAffect = com.ExecuteNonQuery();
                        return rowAffect > 0;
                    }
                }
            }
            catch (SqlException e)
            {
                // Log the exception (consider using a logging library here)
                Console.WriteLine($"ERROR creando producto: {e.Message}");
                return false;
            }
        }

        public bool Update(ENProduct en)
        {
            string query = "UPDATE Products SET name = @name, amount = @amount, category = @category, price = @price, creationDate = @creationDate WHERE code = @code";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        com.Parameters.AddWithValue("@code", en.code);
                        com.Parameters.AddWithValue("@name", en.name);
                        com.Parameters.AddWithValue("@amount", en.amount);
                        com.Parameters.AddWithValue("@category", en.category);
                        com.Parameters.AddWithValue("@price", en.price);
                        com.Parameters.AddWithValue("@creationDate", en.creationDate);

                        int rowAffect = com.ExecuteNonQuery();
                        return rowAffect > 0;

                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"ERROR actualizar: {e.Message}");
                return false;
            }
        }

        public bool Delete(ENProduct en)
        {
            string query = "DELETE FROM Products WHERE code = @code";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        com.Parameters.AddWithValue("@code", en.code);

                        int rowAffect = com.ExecuteNonQuery();
                        return rowAffect > 0;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"ERROR borrar: {e.Message}");
                return false;
            }
        }

        public bool Read(ENProduct en)
        {
            string query = "SELECT * FROM Products WHERE code = @code";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        com.Parameters.AddWithValue("@code", en.code);

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.name = reader["name"].ToString();
                                en.amount = Convert.ToInt32(reader["amount"]);
                                en.category = Convert.ToInt32(reader["category"]);  // category as int
                                en.price = Convert.ToSingle(reader["price"]);
                                en.creationDate = Convert.ToDateTime(reader["creationDate"]);
                                return true;
                            }
                            return false;  // No se encontró el producto
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"ERROR al leer el producto: {e.Message}");
                return false;
            }
        }

        // Método para leer el primer producto
        public bool ReadFirst(ENProduct en)
        {
            string query = "SELECT TOP 1 * FROM Products ORDER BY creationDate";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.code = reader["code"].ToString();
                                en.name = reader["name"].ToString();
                                en.amount = Convert.ToInt32(reader["amount"]);
                                en.category = Convert.ToInt32(reader["category"]);  // category as int
                                en.price = Convert.ToSingle(reader["price"]);
                                en.creationDate = Convert.ToDateTime(reader["creationDate"]);
                                return true;
                            }
                            return false;  // No hay productos en la base de datos
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"ERROR al leer el primer producto: {e.Message}");
                return false;
            }
        }

        // Método para leer el siguiente producto
        public bool ReadNext(ENProduct en)
        {
            string query = "SELECT TOP 1 * FROM Products WHERE creationDate > @creationDate ORDER BY creationDate";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        com.Parameters.AddWithValue("@creationDate", en.creationDate);

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.code = reader["code"].ToString();
                                en.name = reader["name"].ToString();
                                en.amount = Convert.ToInt32(reader["amount"]);
                                en.category = Convert.ToInt32(reader["category"]);
                                en.price = Convert.ToSingle(reader["price"]);
                                en.creationDate = Convert.ToDateTime(reader["creationDate"]);
                                return true;  // Found the next product
                            }
                            return false;  // No next product
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"ERROR while reading the next product: {e.Message}");
                return false;
            }
        }


        // Método para leer el producto anterior
        public bool ReadPrev(ENProduct en)
        {
            string query = "SELECT TOP 1 * FROM Products WHERE creationDate < @creationDate ORDER BY creationDate DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        com.Parameters.AddWithValue("@creationDate", en.creationDate);

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.code = reader["code"].ToString();
                                en.name = reader["name"].ToString();
                                en.amount = Convert.ToInt32(reader["amount"]);
                                en.category = Convert.ToInt32(reader["category"]);
                                en.price = Convert.ToSingle(reader["price"]);
                                en.creationDate = Convert.ToDateTime(reader["creationDate"]);
                                return true;  // Found the previous product
                            }
                            return false;  // No previous product
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"ERROR while reading the previous product: {e.Message}");
                return false;
            }
        }
    }
}
    
