using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entitites.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //Bunu yaparak DataAccess altındaki EntityFramework Haberleşmesi sağlıyoruz

        public ProductManager(IProductDal productDal) //EntityFramework , başka zaman başka bir şey olabilir. o yuzden soyutunu tanımlayıp constructorda soyutunun çağırdığı geliyor
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
                 return new ErrorResult(Messages.ProductNameInvalid);

            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll() //IProductService/GetAll()
        {
            //İş kodları
            //Yetkisi var mı
            return new DataResult<List<Product>>( _productDal.GetAll(),true,"Ürünler Listelendi");   //DataAccess/EntityFramework/EfCategoryDal/ GetAll() methodu
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id); 
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
