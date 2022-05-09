using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageRoles.Models;
using System.Linq.Dynamic;

namespace ManageRoles.Repository
{
    public class LuuTruMasterConcrete : ILuuTruMaster
    {
        private readonly DatabaseContext _context;
        private bool _disposed = false;

        public LuuTruMasterConcrete(DatabaseContext context)
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

        public List<LuuTruMaster> GetAll()
        {
            try
            {
                return _context.LuuTruMaster.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public LuuTruMaster GetById(int Id)
        {
            try
            {
                return _context.LuuTruMaster.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(LuuTruMaster model)
        {
            try
            {
                int result = -1;

                if (model != null)
                {
                    model.Actived = true;
                    model.CreateDate = DateTime.Now;
                    _context.LuuTruMaster.Add(model);
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

        public int Update(LuuTruMaster model)
        {
            try
            {

                int result = -1;

                if (model != null)
                {
                    model.CreateDate = DateTime.Now;
                    model.Actived = true;
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
                LuuTruMaster model = _context.LuuTruMaster.Find(userId);
                if (model != null) _context.LuuTruMaster.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
