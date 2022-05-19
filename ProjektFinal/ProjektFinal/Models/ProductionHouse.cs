using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektFinal.Models
{
    public class ProductionHouse
    {
        [Key]
        public int HouseID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string HouseName { get; set; }
        public  ICollection<Film> Films { get; set; }
    }
}
