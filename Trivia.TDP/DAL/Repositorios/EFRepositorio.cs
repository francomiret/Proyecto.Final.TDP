using ProyectoFinalTDP.DAL.Interfaz;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProyectoFinalTDP.DAL.Repositorios
{
    abstract class EFRepositorio<TEntity, TDbContext> : IRepositorio<TEntity>
    where TEntity : class
    where TDbContext : DbContext
    {
        protected readonly TDbContext iDbContext;

        public EFRepositorio( TDbContext pContext )
        {
            this.iDbContext = pContext ?? throw new ArgumentNullException(nameof(pContext));
        }

        public void Add( TEntity pEntity )
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Add(pEntity);
        }

        public void Remove( TEntity pEntity )
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Remove(pEntity);
        }

        public TEntity Get( int pId )
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
