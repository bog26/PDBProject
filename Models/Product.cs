using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;




namespace PDBProject.Models
{
    public class Product
    {
        //[Key]
        public int Id { get; set;}

        [Required]
        public string Name { get; set;}
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set;}
    }
}
