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
        private string cadena;

        public CADProduct()
        {
            this.cadena = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool Create(ENProduct en)
        {
            SqlCommand com;
            SqlConnection conn;
            bool success = false;
            string query = "INSERT INTO Products(code, name, amount, category, price, creationDate) VALUES (@code, @name, @amount, @category, @price, @creationDate)";

            try
            {
                conn = new SqlConnection = new SqlConnection(cadena);
                conn.Open();
                com = new SqlCommand(query, conn);
                com.Parameters.AddWithValue("@code", en.code);
                com.Parameters.AddWithValue("@name", en.name);
                com.Parameters.AddWithValue("@amount", en.amount);
                com.Parameters.AddWithValue("@price", en.price);
                com.Parameters.AddWithValue("@category", en.category);
                com.Parameters.AddWithValue("@creationDate", en.creationDate);

                int rowAffect = com.ExecuteNonQuery();
                success = rowAffect > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: DIPSHIT {e.Message}");
            }
            finally {
                if (com != null)  // WHAT DO YOU MEAN ITS WITHIN THE FUCKING SCOPE
                { 
                    com.Dispose();
                    conn.Close();
                }
               
            }
            return success;
        }    
    }
}
