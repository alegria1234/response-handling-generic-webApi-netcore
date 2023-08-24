using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }
    }
}
