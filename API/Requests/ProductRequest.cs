using Domain.Table;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Requests
{
    public class ProductRequest
    {
        public ObjectId Id { get; set; }
        public string? Item { get; set; }
        public int Qty { get; set; }
        public string? Status { get; set; }
        public SizeTable? Size { get; set; }
    }
}
