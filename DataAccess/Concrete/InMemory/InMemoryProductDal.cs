using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        // ctor --- Constructor
        public InMemoryProductDal()
        {
            // Oracle, Sql Server, Postgres, MongoDb ' den geliyormuş gibi simüle ediyoruz
            _products = new List<Product> {
                new Product{ ProductId=1,  CategoryId=1, ProductName="Bardak", UnitPrice = 15},
                new Product{ ProductId=2,  CategoryId=1, ProductName="Kamera", UnitPrice = 500},
                new Product{ ProductId=3,  CategoryId=2, ProductName="Telefon", UnitPrice = 1500},
                new Product{ ProductId=4,  CategoryId=2, ProductName="Klavye", UnitPrice = 150},
                new Product{ ProductId=5,  CategoryId=2, ProductName="Fare", UnitPrice = 85},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // Direk kullanamayız çünkü referanslar birbirini tutmuyor newlediğimiz için
            // foreach ile dönüp, id kontrolü yapıp, değer atayıp, sonra silmemiz gerekir
            // _products.Remove(product);

            // Ama LINQ ile olay çok basite indirgenir.
            // LINQ - Language Integrated Query

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int cateogryId)
        {
            // SQL deki where ile aynı işi yapıyor ve && ile istediğimiz kadar koşul ekleyebiliyoruz.
            return _products.Where(p => p.CategoryId == cateogryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            //productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
