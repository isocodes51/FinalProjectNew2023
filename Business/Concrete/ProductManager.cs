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
           //validation

            if(product.UnitPrice <= 0)
            {
                return new ErrorResult(Messages.UnitPriceInvalid);
            }
            if (product.ProductName.Length < 2)
                 return new ErrorResult(Messages.ProductNameInvalid);

            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll() //IProductService/GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }


            //İş kodları
            //Yetkisi var mı
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(),Messages.ProductsListed);   //DataAccess/EntityFramework/EfCategoryDal/ GetAll() methodu
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id)); 
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
