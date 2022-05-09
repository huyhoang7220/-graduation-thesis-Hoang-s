using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using System.Linq.Dynamic;
using ManageRoles.ViewModels;

namespace ManageRoles.Repository
{
    public class NhaSanXuatConcrete : INhaSanXuat
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public NhaSanXuatConcrete(DatabaseContext context)
        {
            _context = context;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public List<NhaSanXuatModel> GetAll()
        {
            try
            {
                return _context.NhaSanXuatService.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public NhaSanXuatModel GetById(int Id)
        {
            try
            {
                return _context.NhaSanXuatService.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(NhaSanXuatModel model)
        {
            try
            {
                int result = -1;

                if (model != null)
                {
                    _context.NhaSanXuatService.Add(model);
                    _context.SaveChanges();
                    result = model.Id;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(NhaSanXuatModel model)
        {
            try
            {

                int result = -1;

                if (model != null)
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = model.Id;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int? userId)
        {
            try
            {
                NhaSanXuatModel model = _context.NhaSanXuatService.Find(userId);
                if (model != null) _context.NhaSanXuatService.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
