using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface IChiTietDonHang
    {
        List<ChiTietDonHangModel> GetAll();
        ChiTietDonHangModel GetById(int id);
        ChiTietDonHangModel GetByIdDH(int id);
        int Add(ChiTietDonHangModel model);
        int Update(ChiTietDonHangModel model);
        void Delete(int? id);
    }
}
