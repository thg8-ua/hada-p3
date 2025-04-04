using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
        }

        protected void code_TextChanged(object sender, EventArgs e)
        {

        }

        protected void name_TextChanged(object sender, EventArgs e)
        {

        }

        protected void amount_TextChanged(object sender, EventArgs e)
        {

        }

        protected void category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void price_TextChanged(object sender, EventArgs e)
        {

        }

        protected void date_TextChanged(object sender, EventArgs e)
        {

        }
        private ENProduct GetProductFromInputs()
        {
            try
            {
                string code = codeInput.Text;
                string name = nameInput.Text;
                int amount = int.Parse(amountInput.Text);
                float price = float.Parse(priceInput.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
                int category = int.Parse(categoryInput.SelectedValue);
                DateTime creationDate = DateTime.ParseExact(
                    dateInput.Text,
                    "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None
                );

                return new ENProduct(code, name, amount, price, category, creationDate);
            }
            catch (FormatException ex)
            {
                statusLabel.Text = $"ERROR: Invalid input. {ex.Message}";
                statusLabel.ForeColor = System.Drawing.Color.Red;
                return null; // Return null if there is an issue with the input
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"ERROR: {ex.Message}";
                statusLabel.ForeColor = System.Drawing.Color.Red;
                return null; // Return null for general exceptions
            }
        }
        protected string GetCategoryName(int categoryId)
        {
            switch (categoryId)
            {
                case 1: return "Computing";
                case 2: return "Telephony";
                case 3: return "Gaming";
                case 4: return "Home appliances";
                default: return "Unknown";
            }
        }
        protected void DisplayProductInGrid(ENProduct product, string successMessage)
        {
            if (product != null)
            {
                List<ENProduct> products = new List<ENProduct> { product };
                productGrid.DataSource = products;
                productGrid.DataBind();
                productGrid.Visible = true;
                statusLabel.Text = successMessage;
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                productGrid.Visible = false;
                statusLabel.Text = "Product operation has failed.";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void create_Click(object sender, EventArgs e)
        {
            ENProduct newProduct = GetProductFromInputs();
            if (newProduct == null) return; // Exit if parsing failed

            bool isCreated = newProduct.Create();
            if (isCreated)
            {
                statusLabel.Text = "Product created successfully!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Product creation failed.";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            ENProduct newProduct = GetProductFromInputs();
            if (newProduct == null) return;

            bool isUpdated = newProduct.Update();
            if (isUpdated)
            {
                statusLabel.Text = "Product Updated";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Product operation has failed.";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.code = codeInput.Text;
            if (product == null) return;

            bool isDeleted = product.Delete();
            if (isDeleted)
            {
                statusLabel.Text = "Product Deleted";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Product operation has failed.";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void read_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.code = codeInput.Text;
            if (product == null) return;

            if (product.Read())
            {
                DisplayProductInGrid(product, "Product found!");
            }
            else
            {
                productGrid.Visible = false;
                statusLabel.Text = "Product not found";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void readfirst_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            if (product.ReadFirst())
            {
                DisplayProductInGrid(product, "First product loaded!");
                
            }
            else
            {
                productGrid.Visible = false;
                statusLabel.Text = "No products found";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void readprev_Click(object sender, EventArgs e)
        {
            ENProduct currentProduct = GetProductFromInputs();
            if (currentProduct == null) return;

            if (currentProduct.ReadPrev())
            {
                DisplayProductInGrid(currentProduct, "Previous product loaded!");
                
            }
            else
            {
                productGrid.Visible = false;
                statusLabel.Text = "No previous product found";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void readnext_Click(object sender, EventArgs e)
        {
            ENProduct currentProduct = GetProductFromInputs();
            if (currentProduct == null) return;

            if (currentProduct.ReadNext())
            {
                DisplayProductInGrid(currentProduct, "Next product loaded!");
                
            }
            else
            {
                productGrid.Visible = false;
                statusLabel.Text = "No next product found";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}