using API.Converters;
using API.Requests;
using Domain.Repository;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.iplm
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ProductConverter _converter;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            this._converter = new ProductConverter();
        }

        public void Delete(ObjectId id)
        {
            this._productRepository.Delete(id);
        }

        public IEnumerable<List<ProductRequest>> GetAll()
        {
            var tables = this._productRepository.GetAll();
            var reqs = new List<ProductRequest>();
            foreach(var item in tables)
            {
                var req = this._converter.ToReq(item);
                reqs.Add(req);
            }
            yield return reqs;
        }

        public ProductRequest GetById(ObjectId id)
        {
            return this._converter.ToReq(this._productRepository.GetById(id));
        }

        public void Insert(ProductRequest req)
        {
            this._productRepository.Insert(this._converter.ToTable(req));
        }

        public void Update(ProductRequest req)
        {
            this._productRepository.Update(this._converter.ToTable(req));
        }
    }
}
