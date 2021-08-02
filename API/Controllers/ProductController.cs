using API.Requests;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProjectCore.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private ILogger _logger;
        public ProductController(IProductService productService, ILogger logger)
        {
            this._logger = logger;
            this._productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<List<ProductRequest>> GetAllProduct()
        {
            try
            {
                this._logger.LogInfo("Fetching all the product from the storage");
                return this._productService.GetAll();
            }
            catch
            {
                throw new Exception("Exception while fetching all the product from the storage.");
            }
            
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductRequest GetProduct(string id)
        {
            
            try
            {
                this._logger.LogInfo("Fetching a product from the storage");
                return this._productService.GetById(ObjectId.Parse(id));
            }
            catch
            {
                throw new Exception("Exception while fetching a product from the storage.");
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public void CreateProduct([FromBody] ProductRequest req)
        {
            
            try
            {
                this._logger.LogInfo("Inserting a product from the storage");
                this._productService.Insert(req);
            }
            catch
            {
                throw new Exception("Exception while inserting a product from the storage.");
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void UpdateProduct(string id, [FromBody] ProductRequest req)
        {
            try
            {
                this._logger.LogInfo("Updating a product from the storage");
                req.Id = ObjectId.Parse(id);
                this._productService.Update(req);
            }
            catch
            {
                throw new Exception("Exception while updating a product from the storage.");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void DeleteProduct(string id)
        {
            
            try
            {
                this._logger.LogInfo("Deleting a product from the storage");
                this._productService.Delete(ObjectId.Parse(id));
            }
            catch
            {
                throw new Exception("Exception while deleting a product from the storage.");
            }
        }
    }
}
