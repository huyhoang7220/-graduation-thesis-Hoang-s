using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface IDanhMuc
    {
        List<DanhMucModel> GetAll();
        DanhMucModel GetById(int id);
        int Add(DanhMucModel model);
        int Update(DanhMucModel model);
        int Update(int id, DanhMucModel model);
        void Delete(int id);
    }
}
