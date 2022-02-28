using ProyectoFinalTDP.Administrador.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalTDP.Administrador.DAL.Repositorios
{
        abstract class EFRepositorio<TEntity, TDbContext> : IRepositorio<TEntity>
        where TEntity : class
        where TDbContext : DbContext
        {
            protected readonly TDbContext iDbContext;

            public EFRepositorio(TDbContext pContext)
            {
                if (pContext == null)
                {
                    throw new ArgumentNullException(nameof(pContext));
                }

                this.iDbContext = pContext;
            }

            public void Add(TEntity pEntity)
            {
                if (pEntity == null)
                {
                    throw new ArgumentNullException(nameof(pEntity));
                }

                this.iDbContext.Set<TEntity>().Add(pEntity);
            }

            public void Remove(TEntity pEntity)
            {
                if (pEntity == null)
                {
                    throw new ArgumentNullException(nameof(pEntity));
                }

                this.iDbContext.Set<TEntity>().Remove(pEntity);
            }

            public TEntity Get(int pId)
            {
                TEntity borrar = this.iDbContext.Set<TEntity>().Find(pId);
                return borrar;
            }

            public IEnumerable<TEntity> GetAll()
            {
                return this.iDbContext.Set<TEntity>().ToList<TEntity>();
            }

        }
}
