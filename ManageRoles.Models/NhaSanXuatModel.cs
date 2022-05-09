using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    [Table("NhaSanXuat")]
    public class NhaSanXuatModel
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Logo { get; set; }
    }
}
