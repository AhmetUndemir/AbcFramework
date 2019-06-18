using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrete;

namespace Abc.Northwind.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; internal set; }
        public List<Category> Categories { get; internal set; }
    }
}
