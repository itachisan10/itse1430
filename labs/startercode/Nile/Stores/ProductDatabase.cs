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
                throw new ArgumentNullException(nameof(product));

            var results = ObjectValidator.TryValidate(product);
            if (results.Count() > 0)
                throw new ValidationException(results.FirstOrDefault().ErrorMessage);

            ObjectValidator.TryValidate(product);
            //Emulate database by storing copy
            return AddCore(product);
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
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be unique.");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            //done: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var results = ObjectValidator.TryValidate(product);
            if (results.Count() > 0)
                throw new ValidationException(results.FirstOrDefault().ErrorMessage);
            //Get existing product
            var existing = GetCore(product.Id);
            if (existing != null && existing == product)
                throw new ArgumentException("Product must be unique.");

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );
        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract void RemoveCore( int id );
        protected abstract Product UpdateCore( Product existing, Product newItem );
        protected abstract Product AddCore( Product product );
        #endregion
    }
}
