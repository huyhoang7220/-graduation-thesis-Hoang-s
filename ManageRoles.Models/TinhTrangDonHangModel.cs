using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageRoles.ViewModels
{
    [Table("TinhTrangDonHang")]
    public class TinhTrangDonHangModel
    {
        [Key]
        public int Id { get; set; }
        public string TenTinhTrang { get; set; }
    }
}
