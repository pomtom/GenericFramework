using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableStore
{
    public class Employee : Tbl
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
