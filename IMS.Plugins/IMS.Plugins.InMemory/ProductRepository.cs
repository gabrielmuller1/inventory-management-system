using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product> ()
            {
                new Product() { ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 400},
                new Product() { ProductId = 1, ProductName = "Car", Quantity = 3, Price = 9000}
            };
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync ( string name )
        {
            if (string.IsNullOrWhiteSpace ( name )) return await Task.FromResult ( _products );

            return _products.Where ( x => x.ProductName.Contains ( name, StringComparison.OrdinalIgnoreCase ) );
        }

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase) ))
                return Task.CompletedTask;

            var maxId = _products.Max(x=> x.ProductId);
            product.ProductId = maxId + 1;

            _products.Add(product);

            return Task.CompletedTask;
        }

        public async Task<Product?> GetProductByIdAsync ( int productId )
        {
            var prod = _products.FirstOrDefault ( x => x.ProductId == productId ) ;
            var newProd = new Product ();
            if(prod != null)
            {
                newProd.ProductId = prod.ProductId;
                newProd.ProductName = prod.ProductName;
                newProd.Quantity = prod.Quantity;
                newProd.Price = prod.Price;
                newProd.ProductInventories = new List<ProductInventory> ();
                if(prod.ProductInventories != null && prod.ProductInventories.Count > 0)
                {
                    foreach(var prodInv in prod.ProductInventories)
                    {
                        var newProdInv = new ProductInventory
                        {
                            InventoryId = prodInv.InventoryId,
                            ProductId = prodInv.ProductId,
                            Product = prod,
                            Inventory = new Inventory (),
                            InventoryQuantity = prodInv.InventoryQuantity
                        };

                        if(prodInv.Inventory != null)
                        {
                            newProdInv.Inventory.InventoryId = prodInv.Inventory.InventoryId;
                            newProdInv.Inventory.InventoryName = prodInv.Inventory.InventoryName;
                            newProdInv.Inventory.Quantity = prodInv.Inventory.Quantity;
                            newProdInv.Inventory.Price = prodInv.Inventory.Price;
                        }

                        newProd.ProductInventories.Add ( newProdInv );
                    }
                }

            }
            return await Task.FromResult(newProd);
        }

        public Task UpdateProductAsync ( Product product )
        {
            throw new NotImplementedException ();
        }
    }
}
