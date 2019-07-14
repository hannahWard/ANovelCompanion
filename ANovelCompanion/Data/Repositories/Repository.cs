using ANovelCompanion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IModel
    {
        protected NovelDbContext context;
        protected DbSet<TEntity> models;

        public Repository(NovelDbContext context)
        {
            this.context = context;
            this.models = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return models.SingleOrDefault(m => m.Id == id);
        }

        public List<TEntity> GetModels()
        {
            return models.ToList();
        }

        public int Save(TEntity model)
        {
            context.Add(model);
            context.SaveChanges();
            return model.Id;
        }

        public void Update(TEntity model)
        {
            context.Update(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = this.GetById(id);
            context.Remove(model);
            context.SaveChanges();
        }

        public void DeleteManyToMany(TEntity model)
        {
            context.Remove(model);
            context.SaveChanges();
        }
    }
}
