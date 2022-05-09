using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface IDonHang
    {
        List<DonHangModel> GetAll();
        DonHangModel GetById(int id);
        DonHangModel GetDHByUser(int idUser, int idSP);
        int Add(DonHangModel model);
        int Update(DonHangModel model);
        void Delete(int? id);
    }
}
