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
    public class ChiTietDonHangConcrete : IChiTietDonHang
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public ChiTietDonHangConcrete(DatabaseContext context)
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

        public List<ChiTietDonHangModel> GetAll()
        {
            try
            {
                return _context.ChiTietDonHangService.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ChiTietDonHangModel GetById(int Id)
        {
            try
            {
                return _context.ChiTietDonHangService.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ChiTietDonHangModel GetByIdDH(int IdDH)
        {
            try
            {
                return _context.ChiTietDonHangService.ToList().Where(x => x.IdDonHang == IdDH).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(ChiTietDonHangModel model)
        {
            try
            {
                int result = -1;

                if (model != null)
                {
                    _context.ChiTietDonHangService.Add(model);
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

        public int Update(ChiTietDonHangModel model)
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

        public void Delete(int? id)
        {
            try
            {
                ChiTietDonHangModel model = _context.ChiTietDonHangService.Find(id);
                if (model != null) _context.ChiTietDonHangService.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
