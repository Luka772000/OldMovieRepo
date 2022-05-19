using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektFinal.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string RoleName { get; set; }


        [ForeignKey(nameof(Film))]
        public int FilmID { get; set; }
        public virtual Film Film { get; set; }
        
            

        [ForeignKey(nameof(Actor))]
        public int ActorID { get; set; }
        public virtual Actor Actor { get; set; }        
       

    }
}
