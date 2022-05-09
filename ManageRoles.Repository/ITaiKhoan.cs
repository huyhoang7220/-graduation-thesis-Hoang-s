using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface ITaiKhoan
    {
        List<TaiKhoanModel> GetAll();
        TaiKhoanModel GetById(int id);
        TaiKhoanModel GetByEmail(string email);
        bool CheckEmailExists(string email);
        int Add(TaiKhoanModel model);
        int Update(TaiKhoanModel model);
        int Update(int id, TaiKhoanModel model);
        void Delete(int? id);
    }
}
