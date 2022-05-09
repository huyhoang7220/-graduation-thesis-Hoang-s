using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    [Table("Slide")]
    public class SlideModel
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Anh { get; set; }
        public int IdSP { get; set; }
    }
}
