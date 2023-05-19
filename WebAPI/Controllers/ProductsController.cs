using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entitites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled - Gevşek bağımlılık
        //Naming convention
        //IoC Container --Inversion of Control -Değişimin kontrolü
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //return new List<Product> 
            //{
            //    new Product{ ProductId=1, ProductName="Elma"},
            //    new Product{ ProductId=2, ProductName="Armut"}
            //};
            //IProductService productService = new ProductManager(new EfProductDal());
            
            // Dependency Chain--
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
