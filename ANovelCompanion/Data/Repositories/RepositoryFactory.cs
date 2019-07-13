using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.Data.Repositories
{
    public class RepositoryFactory
    {
        private NovelDbContext context;

        public RepositoryFactory(NovelDbContext context)
        {
            this.context = context;
        }

        public IRepository<Book> GetBookRepository()
        {
            return new Repository<Book>(context);
        }
    }
}
