using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Product.Models.Product_Model
{
	public class ProductModel
	{
        private List<Product> products;

        public ProductModel()
        {
            this.products = new List<Product>() {
                new Product {
                    ProductId = 1,
                    ProductName = "Name 1",
                    ProductDetails = "Details 2",
                    ProductPrice = 5,
                    productLinkImg = "thumb1.gif",
                    productComment = "cmt 1"
                },
                new Product {
                    ProductId = 2,
                    ProductName = "Name 2",
                    ProductDetails = "Details 2",
                    ProductPrice = 2,
                    productLinkImg = "thumb2.gif",
                    productComment = "cmt 2"
                   
                },
                new Product {
                    ProductId = 3,
                    ProductName = "Name 3",
                    ProductDetails = "Details 3",
                    ProductPrice = 6,
                    productLinkImg = "thumb3.gif",
                    productComment = "cmt 3"
                }
            };
        }

        public List<Product> findAll()
        {
            return this.products;
        }

        public Product find(string id)
        {
            return this.products.Single(p => p.ProductId.Equals(Convert.ToInt32(id)));
        }
    }
}