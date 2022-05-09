using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface ILoaiTaiKhoan
    {
        List<LoaiTaiKhoanModel> GetAll();
        LoaiTaiKhoanModel GetById(int id);
        LoaiTaiKhoanModel GetByMa(string ma);
        int Add(LoaiTaiKhoanModel model);
        int Update(LoaiTaiKhoanModel model);
        void Delete(int? id);
    }
}
