using API.Requests;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IProductService
    {
        public IEnumerable<List<ProductRequest>> GetAll();
        public ProductRequest GetById(ObjectId id);
        public void Insert(ProductRequest req);
        public void Update(ProductRequest req);
        public void Delete(ObjectId id);
    }
}
