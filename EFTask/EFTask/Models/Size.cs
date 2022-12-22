using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.Models
{
    internal class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
