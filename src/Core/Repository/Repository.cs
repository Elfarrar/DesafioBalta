using Microsoft.EntityFrameworkCore;
using Model;
using Model.Enums;
using Repository.Context;
using System.Linq.Expressions;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly ApplicationContext Db;
        protected readonly DbSet<T> DbSet;
        protected readonly DbSet<Audit> DbSetAudit;

        public Repository(ApplicationContext db)
        {
            Db = db;
            DbSet = Db.Set<T>();
            DbSetAudit = Db.Set<Audit>();
        }

        public virtual async Task<IEnumerable<T>> Get(bool track = true, CancellationToken cancellationToken = default)
        {
            if (track)
                return await DbSet.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
            else
                return await DbSet.AsNoTracking().Where(x => !x.IsDeleted).ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate, bool track = true, CancellationToken cancellationToken = default)
        {
            if (track)
                return await DbSet.Where(x => !x.IsDeleted).Where(predicate).ToListAsync();
            else
                return await DbSet.AsNoTracking().Where(x => !x.IsDeleted).Where(predicate).ToListAsync();
        }

        public virtual async Task<T?> GetById(Guid id, bool track = true, CancellationToken cancellationToken = default)
        {
            if (track)
                return await DbSet.FindAsync(id);
            else
                return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            DbSet.Add(entity);

            entity.Audit?.Add(Auditory(AuditType.Create, entity));

            await Db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity, CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);

            entity.Audit?.Add(Auditory(AuditType.Update, entity));

            await Db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Delete(T entity, CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);

            entity.Audit?.Add(Auditory(AuditType.Delete, entity));

            await Db.SaveChangesAsync();
            return entity;
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        private Audit Auditory(AuditType type, T entity)
        {
            return new Audit()
            {
                CreateDate = DateTime.Now,
                CreateUser = Guid.NewGuid(),
                Type = type,
                State = entity.SerializedObject,
            };
        }
    }
}
