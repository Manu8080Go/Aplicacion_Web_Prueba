using Prueba.DBContext.DB1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Negocio
{
    public class GenericDB1Impl<T> where T: class, new()
    {
        public int Create(T entity)
        {
            try
            {
                using(DB_PRUEBA_1Entities db = new DB_PRUEBA_1Entities())
                {
                    db.Entry(entity).State = System.Data.Entity.EntityState.Added;
                    return db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                using (DB_PRUEBA_1Entities db = new DB_PRUEBA_1Entities())
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
