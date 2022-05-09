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
    public class TinhTrangDonHangConcrete : ITinhTrangDonHang
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public TinhTrangDonHangConcrete(DatabaseContext context)
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

        public List<TinhTrangDonHangModel> GetAll()
        {
            try
            {
                return _context.TinhTrangDonHangService.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TinhTrangDonHangModel GetById(int Id)
        {
            try
            {
                return _context.TinhTrangDonHangService.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(TinhTrangDonHangModel model)
        {
            try
            {
                int result = -1;

                if (model != null)
                {
                    _context.TinhTrangDonHangService.Add(model);
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

        public int Update(TinhTrangDonHangModel model)
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
                TinhTrangDonHangModel model = _context.TinhTrangDonHangService.Find(userId);
                if (model != null) _context.TinhTrangDonHangService.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
