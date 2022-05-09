using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageRoles.ViewModels
{
    public class LuuTruView
    {
        public int Id { get; set; }
        public string TenLT { get; set; }
        public string DiaChiLT { get; set; }
        public int SoDTLT { get; set; }
        public bool Actived { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
