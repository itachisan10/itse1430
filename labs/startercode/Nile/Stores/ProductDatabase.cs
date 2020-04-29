/*
 * Carlos Vargas
 * April 25, 2020
 * ITSE 1430
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //done: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product),"Null");

            ObjectValidator.Validate(product);

            try
            {
                var existing = ProductName(product.Name);
                if (existing != null)
                    throw new InvalidOperationException("Product must be unique");

                return AddCore(product);
            } catch (InvalidOperationException)
            {
                throw;
            } catch (Exception e)
            {
                throw new InvalidOperationException("Error adding Product", e);
            };
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //Done: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be unique.");

           return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            //Done: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zer0.");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            //done: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product),"product is null");

            ObjectValidator.Validate(product);

            try
            {
                var existing = ProductName(product.Name);
                if (existing != null && existing.Id != product.Id)
                    throw new InvalidOperationException("Product must be unique");

                return UpdateCore(existing, product);
            } catch (InvalidOperationException)
            {
                throw;
            } catch (Exception e)
            {
                throw new InvalidOperationException("Error adding product", e);
            };
        }

        #region Protected Members

        protected abstract Product GetCore( int id );
        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract void RemoveCore( int id );
        protected abstract Product UpdateCore( Product existing, Product newItem );
        protected abstract Product AddCore( Product product );
        protected abstract Product ProductName ( string name );
        #endregion
    }
}
