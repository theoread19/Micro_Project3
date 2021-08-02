using Domain.Repository;
using Domain.Table;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly IMongoCollection<ProductTable> _product;

        public ProductRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("ProductDB");
            var collection = database.GetCollection<ProductTable>(nameof(ProductTable));
            this._product = collection;
        }

        public void Delete(ObjectId Id)
        {
            var filter = Builders<ProductTable>.Filter.Eq(c => c.Id, Id);
            this._product.DeleteOne(filter);
        }

        public List<ProductTable> GetAll()
        {
            var x = this._product.Find(_ => true).ToList(); 
            return this._product.Find(_ => true).ToList();
        }

        public ProductTable GetById(ObjectId Id)
        {
           var filter = Builders<ProductTable>.Filter.Eq(c => c.Id, Id);
            return this._product.Find(filter).FirstOrDefault();
        }

        public void Insert(ProductTable productTable)
        {
            this._product.InsertOne(productTable);
            
        }

        public void Update(ProductTable productTable)
        {
            var filter = Builders<ProductTable>.Filter.Eq(c => c.Id, productTable.Id);
            var update = Builders<ProductTable>.Update
                        .Set(c => c.Item, productTable.Item)
                        .Set(c => c.Qty, productTable.Qty)
                        .Set(c => c.Size, productTable.Size)
                        .Set(c => c.Status, productTable.Status);
            this._product.UpdateOne(filter, update);
        }
    }
}
