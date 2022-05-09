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
    public class TaiKhoanConcrete : ITaiKhoan
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public TaiKhoanConcrete(DatabaseContext context)
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

        public List<TaiKhoanModel> GetAll()
        {
            try
            {
                return _context.TaiKhoanService.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TaiKhoanModel GetById(int Id)
        {
            try
            {
                return _context.TaiKhoanService.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TaiKhoanModel GetByEmail(string email)
        {
            try
            {
                var result = (from usermaster in _context.TaiKhoanService
                              where usermaster.Email == email
                              select usermaster).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckEmailExists(string email)
        {
            try
            {
                var result = (from menu in _context.TaiKhoanService
                              where menu.Email == email
                              select menu).Any();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Add(TaiKhoanModel model)
        {
            try
            {
                int result = -1;

                if (model != null)
                {
                    _context.TaiKhoanService.Add(model);
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

        public int Update(TaiKhoanModel model)
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

        public int Update(int id, TaiKhoanModel model)
        {
            try
            {

                int result = -1;

                if (model != null)
                {
                    var existingEntity = _context.TaiKhoanService.Find(id);
                    _context.Entry(existingEntity).CurrentValues.SetValues(model);
                    _context.SaveChanges();
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
                TaiKhoanModel model = _context.TaiKhoanService.Find(userId);
                if (model != null) _context.TaiKhoanService.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
