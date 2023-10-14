using Prueba.DBContext.DB2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Negocio
{
    public class GenericDB2Impl<T> where T : class, new()
    {
        public int Create(T entity)
        {
            try
            {
                using (DB_PRUEBA_2Entities db = new DB_PRUEBA_2Entities())
                {
                    db.Entry(entity).State = System.Data.Entity.EntityState.Added;
                    return db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                using (DB_PRUEBA_2Entities db = new DB_PRUEBA_2Entities())
                {
                    return db.Set<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
