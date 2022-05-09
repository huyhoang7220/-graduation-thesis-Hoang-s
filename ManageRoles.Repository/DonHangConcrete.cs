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
    public class DonHangConcrete : IDonHang
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public DonHangConcrete(DatabaseContext context)
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

        public List<DonHangModel> GetAll()
        {
            try
            {
                return _context.DonHangService.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DonHangModel GetById(int Id)
        {
            try
            {
                return _context.DonHangService.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DonHangModel GetDHByUser(int idUser, int idSP)
        {
            try
            {
                return _context.DonHangService.ToList().Where(x => x.IdTaiKhoan == idUser 
                && x.IdSanPham == idSP && x.IdTinhTrangDonHang == 5).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(DonHangModel model)
        {
            try
            {
                int result = -1;

                if (model != null)
                {
                    _context.DonHangService.Add(model);
                    _context.SaveChanges();
                    result = model.Id;
                }
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int Update(DonHangModel model)
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
                DonHangModel model = _context.DonHangService.Find(userId);
                if (model != null) _context.DonHangService.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
