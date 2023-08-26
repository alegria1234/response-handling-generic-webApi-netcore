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
        /// <summary>
        /// if of Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Car
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Brand of Car
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Price of Car
        /// </summary>
        public decimal Price { get; set; }
    }
}
