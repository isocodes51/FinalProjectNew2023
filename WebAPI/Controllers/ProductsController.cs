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

        [HttpGet(("getall"))]
        public IActionResult GetAll()
        {
            //return new List<Product> 
            //{
            //    new Product{ ProductId=1, ProductName="Elma"},
            //    new Product{ ProductId=2, ProductName="Armut"}
            //};
            //IProductService productService = new ProductManager(new EfProductDal());
            
            //Swagger
            // Dependency Chain--
            var result = _productService.GetAll();
            // return result.Data;
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            // return result.Data;
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
