using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Table
{
    public class SizeTable
    {
        //[BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double Height { get; set; }
        //[BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public double Weight { get; set; }
        public string? Uom { get; set; }
    }
}
