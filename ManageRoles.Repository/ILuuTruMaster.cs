using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;

namespace ManageRoles.Repository
{
    public interface ILuuTruMaster
    {
        List<LuuTruMaster> GetAll();
        LuuTruMaster GetById(int id);
        int Add(LuuTruMaster model);
        int Update(LuuTruMaster model);
        void Delete(int? id);
    }
}
