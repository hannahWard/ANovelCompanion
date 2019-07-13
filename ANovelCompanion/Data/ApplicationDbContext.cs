using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ANovelCompanion.Data
{
    public class NovelDbContext : IdentityDbContext
    {
        public NovelDbContext(DbContextOptions<NovelDbContext> options)
            : base(options)
        {
        }
    }
}
