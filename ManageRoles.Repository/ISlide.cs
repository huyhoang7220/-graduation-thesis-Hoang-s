using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public interface ISlide
    {
        List<SlideModel> GetAll();
        SlideModel GetById(int id);
        int Add(SlideModel model);
        int Update(SlideModel model);
        int Update(int id, SlideModel model);
        void Delete(int id);
    }
}
