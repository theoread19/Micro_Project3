using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Table
{
    public class ProductTable
    {
        public ObjectId Id { get; set; }
        public string? Item { get; set; }
        public int Qty { get; set; }
        public string? Status { get; set; }

        //[BsonRepresentation(BsonType.ObjectId, AllowTruncation = true)]
        public SizeTable? Size { get; set; }
    }
}
