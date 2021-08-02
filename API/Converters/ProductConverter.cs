using API.Requests;
using Domain.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Converters
{
    public class ProductConverter
    {
        public ProductRequest ToReq(ProductTable table)
        {
            var req = new ProductRequest()
            {
                Id = table.Id,
                Item = table.Item,
                Qty = table.Qty,
                Size = table.Size,
                Status = table.Status
            };
            
            return req;
        }

        public ProductTable ToTable(ProductRequest req)
        {
            var table = new ProductTable()
            {
                Item = req.Item,
                Qty = req.Qty,
                Size = req.Size,
                Status = req.Status
            };

            return table;
        }
    }
}
