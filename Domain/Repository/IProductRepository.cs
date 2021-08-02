using Domain.Table;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IProductRepository
    {
        public List<ProductTable> GetAll();
        public ProductTable GetById(ObjectId Id);

        public void Insert(ProductTable productTable);
        public void Update(ProductTable productTable);
        public void Delete(ObjectId id);
//        public void SaveChange();
    }
}
