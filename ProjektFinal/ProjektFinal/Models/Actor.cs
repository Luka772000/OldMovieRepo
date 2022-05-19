using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektFinal.Models
{
    public class Actor
    {
        [Key]
        public int ActorID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ActorName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public int YearOfBirth { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PlaceOfBirth { get; set; }


        public ICollection<Role> Role{ get; set; }
    }
}
