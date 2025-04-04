using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace library
{
    public class CADCategory
    {
        private string constring;
        // Connection string (replace with actual connection string)
        public CADCategory()
        {
            this.constring = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }

        // Method to read a single category based on the given ENCategory object
        public bool read(ENCategory en)
        {
            string query = "SELECT * FROM Categories WHERE id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        com.Parameters.AddWithValue("@id", en.Id);

                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                en.Name = reader["name"].ToString();
                                return true;
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

            return false;
        }

        // Method to read all categories from the database
        public List<ENCategory> readAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            string query = "SELECT * FROM Categories";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ENCategory category = new ENCategory(
                                    Convert.ToInt32(reader["id"]),
                                    reader["name"].ToString()
                                );
                                categories.Add(category);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

            return categories;
        }
    }
}