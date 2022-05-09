using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface ITinhTrangDonHang
    {
        List<TinhTrangDonHangModel> GetAll();
        TinhTrangDonHangModel GetById(int id);
        int Add(TinhTrangDonHangModel model);
        int Update(TinhTrangDonHangModel model);
        void Delete(int? id);
    }
}
