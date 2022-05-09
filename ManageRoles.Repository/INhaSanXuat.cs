using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface INhaSanXuat
    {
        List<NhaSanXuatModel> GetAll();
        NhaSanXuatModel GetById(int id);
        int Add(NhaSanXuatModel model);
        int Update(NhaSanXuatModel model);
        void Delete(int? id);
    }
}
