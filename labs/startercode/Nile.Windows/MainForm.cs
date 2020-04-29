/*
 * Carlos Vargas
 * April 25, 2020
 * ITSE 1430
 */
using System;
using System.Windows.Forms;
using System.Configuration;
using Nile.Stores.Sql;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            var connString = ConfigurationManager.ConnectionStrings["ProductDatabase"];
            _database = new SqlProductDatabase(connString.ConnectionString);

            _gridProducts.AutoGenerateColumns = false;

            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }
        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                ObjectValidator.Validate(child.Product);

                //Save product
                _database.Add(child.Product);
                UpdateList();
            } catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }
        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                DisplayError("No product available.");
                return;
            };
            try
            {
                ObjectValidator.Validate(product);
                EditProduct(product);
            } catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }        
        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                DisplayError("No product available");
                return;
            }
                

            DeleteProduct(product);
        }               
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }
        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }
        
        #endregion
        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Done: Handle errors
            if (product.Id <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.Id), "Invalid product ID");
            //Delete product 
            _database.Remove(product.Id);
            UpdateList();
        }
        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;
            //DONE;
            ObjectValidator.Validate(product);

            _database.Update(child.Product);
            UpdateList();
        }
        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }
        private void UpdateList ()
        {
            _bsProducts.Clear();
            //Handle errors
            try
            {
                

                _bsProducts.DataSource = _database.GetAll();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            };
        }
        private void DisplayError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private IProductDatabase _database;
        #endregion

        private void AboutBox(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }
    }
  
}
