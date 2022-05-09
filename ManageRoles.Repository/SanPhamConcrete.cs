using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using System.Linq.Dynamic;
using ManageRoles.ViewModels;
using System.Data.Entity.Validation;

namespace ManageRoles.Repository
{
    public class SanPhamConcrete : ISanPham
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public SanPhamConcrete(DatabaseContext context)
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

        public List<SanPhamModel> GetAll()
        {
            try
            {
                return _context.SanPhamService.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SanPhamModel GetById(int Id)
        {
            try
            {
                return _context.SanPhamService.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(SanPhamModel model)
        {
            try
            {
                int result = -1;

                if (model != null)
                {
                    _context.SanPhamService.Add(model);
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

        public int Update(SanPhamModel model)
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

        public int Update(int id, SanPhamModel model)
        {
            try
            {

                int result = -1;

                if (model != null)
                {
                    try
                    {
                        var existingEntity = _context.SanPhamService.Find(id);
                        _context.Entry(existingEntity).CurrentValues.SetValues(model);
                        _context.SaveChanges();
                        result = id;
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        var msg = string.Empty;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                            }
                        }
                        throw new Exception(msg, dbEx);
                    }
                   
                }
               
                
                return result;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(msg, dbEx);
            }
        }

        public void Delete(int? userId)
        {
            try
            {
                SanPhamModel model = _context.SanPhamService.Find(userId);
                if (model != null) _context.SanPhamService.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
