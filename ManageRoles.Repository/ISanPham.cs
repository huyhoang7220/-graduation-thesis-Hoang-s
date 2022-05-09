using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface ISanPham
    {
        List<SanPhamModel> GetAll();
        SanPhamModel GetById(int id);
        int Add(SanPhamModel model);
        int Update(SanPhamModel model);
        int Update(int id, SanPhamModel model);
        void Delete(int? id);
    }
}
