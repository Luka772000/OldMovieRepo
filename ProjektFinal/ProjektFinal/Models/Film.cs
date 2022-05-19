using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektFinal.Models
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string FilmName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public int Earnings { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public int YearOfProduction { get; set; }

        [ForeignKey(nameof(ProductionHouse))]
        public int HouseID { get; set; }
        public  ProductionHouse ProductionHouse { get; set; }


        public  ICollection<Role> Role{ get; set; }

    }
}
