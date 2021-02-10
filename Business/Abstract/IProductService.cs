using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();    // Liste döndürüyor
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);    // Ürün döndürüyor
        IResult Add(Product product);   // Void Hiçbir şey döndürmüyor // Void de data olmadığı için IResult yaptık
                                        // Fakat diğerlerinde data, başarı ve mesaj olduğu için IDataResult tanımladık
    }
}
