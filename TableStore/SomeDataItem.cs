using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableStore
{
    public class SomeDataItem : TableEntity
    {
        public string String1 { get; set; }

        public string String2 { get; set; }

        public SomeDataItem()
        {
        }

        public SomeDataItem(string PartitionKey, string RowKey)
        {
            this.PartitionKey = PartitionKey;
            this.RowKey = RowKey;
        }
    }
}
