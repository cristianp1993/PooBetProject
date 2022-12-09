using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BetProject.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        public BetProjectEntities Context { get; set; }       

        public string Message { get; set; }
        #region Constructors
        public GenericRepository()
        {           
            
            //Context.Database.CommandTimeout = 300;

            Message = string.Empty;
        }

        #endregion

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                Context.Set<T>().AddOrUpdate(entity);
                await Context.SaveChangesAsync();

                return entity;

            }
            catch (DbEntityValidationException ex)
            {
                Message = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
                return null;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                SqlException s = ex.InnerException.InnerException as SqlException;
                if (s != null)
                {
                    Message = s.Number + "|" + ex.Message;
                }
                else
                {
                    Message = ex.Message;
                }
                if (ex.InnerException != null)
                {
                    Message = Message + ex.InnerException.InnerException.Message;
                }
                Message = Message.Replace("\"", "'").Replace("\r\n", "");
                return null;
            }

        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                Context.Set<T>().Attach(entity);
                Context.Set<T>().Remove(entity);
                await Context.SaveChangesAsync();

            }
            catch (DbEntityValidationException ex)
            {
                Message = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                
                if (ex.InnerException != null)
                {
                    Message = Message + ex.InnerException.InnerException.Message;
                }
                Message = Message.Replace("\"", "'").Replace("\r\n", "");
            }
        }

        public IQueryable<T> GetAll()
        {
            return this.Context.Set<T>().AsNoTracking();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                Context.Set<T>().AddOrUpdate(entity);
                await Context.SaveChangesAsync();
                return entity;

            }
            catch (DbEntityValidationException ex)
            {
                Message = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
                return null;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                SqlException s = ex.InnerException.InnerException as SqlException;
                if (s != null)
                {
                    Message = s.Number + "|" + ex.Message;
                }
                else
                {
                    Message = ex.Message;
                }
                if (ex.InnerException != null)
                {
                    Message = Message + ex.InnerException.InnerException.Message;
                }
                Message = Message.Replace("\"", "'").Replace("\r\n", "");
                return null;

            }
        }
    }


}
