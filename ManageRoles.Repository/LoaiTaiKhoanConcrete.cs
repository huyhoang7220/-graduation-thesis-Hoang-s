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
    public class LoaiTaiKhoanConcrete : ILoaiTaiKhoan
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public LoaiTaiKhoanConcrete(DatabaseContext context)
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

        public List<LoaiTaiKhoanModel> GetAll()
        {
            try
            {
                return _context.LoaiTaiKhoanService.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LoaiTaiKhoanModel GetById(int Id)
        {
            try
            {
                return _context.LoaiTaiKhoanService.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LoaiTaiKhoanModel GetByMa(string ma)
        {
            try
            {
                return _context.LoaiTaiKhoanService.Where(x => x.Ma == ma).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(LoaiTaiKhoanModel model)
        {
            try
            {
                int result = -1;

                if (model != null)
                {
                    _context.LoaiTaiKhoanService.Add(model);
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

        public int Update(LoaiTaiKhoanModel model)
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
                LoaiTaiKhoanModel model = _context.LoaiTaiKhoanService.Find(userId);
                if (model != null) _context.LoaiTaiKhoanService.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
