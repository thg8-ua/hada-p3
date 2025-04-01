using System;
using System.Collections.Generic;
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
                float price = float.Parse(priceInput.Text);
                int category = int.Parse(categoryInput.SelectedValue);
                DateTime creationDate = DateTime.Parse(dateInput.Text);

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
            ENProduct newProduct = GetProductFromInputs();
            if (newProduct == null) return;

            bool isDeleted = newProduct.Delete();
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
            ENProduct newProduct = GetProductFromInputs();
            if (newProduct == null) return;

            bool isRead = newProduct.Read();
            if (isRead)
            {
                statusLabel.Text = "Product read successfully!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Product operation has failed.";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void readfirst_Click(object sender, EventArgs e)
        {
            ENProduct newProduct = GetProductFromInputs();
            if (newProduct == null) return;

            bool isRead = newProduct.ReadFirst();
            if (isRead)
            {
                statusLabel.Text = "First product read successfully!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Product operation has failed.";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void readprev_Click(object sender, EventArgs e)
        {
            ENProduct newProduct = GetProductFromInputs();
            if (newProduct == null) return;

            bool isRead = newProduct.ReadPrev();
            if (isRead)
            {
                statusLabel.Text = "Previous product read successfully!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Product operation has failed.";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void readnext_Click(object sender, EventArgs e)
        {
            ENProduct newProduct = GetProductFromInputs();
            if (newProduct == null) return;

            bool isRead = newProduct.ReadNext();
            if (isRead)
            {
                statusLabel.Text = "Next product read successfully!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Product operation has failed.";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}