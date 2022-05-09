using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    [Table("LoaiTaiKhoan")]
    public class LoaiTaiKhoanModel
    {
        [Key]
        public int Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }
}
