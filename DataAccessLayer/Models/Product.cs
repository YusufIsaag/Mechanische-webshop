using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Product
    {        
        public int ProductId { get; set; }

        public string Naam { get; set; }

        public string Beschrijving { get; set; }

        public decimal Prijs { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

        public ICollection<Part> Parts { get; } = new List<Part>();
    }
}
