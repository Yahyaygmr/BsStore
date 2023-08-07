using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacıvat", Price = 75 },
                new Book { Id = 2, Title = "Mesnevi", Price = 175 },
                new Book { Id = 3, Title = "Devlet", Price = 95 },
                new Book { Id = 4, Title = "Kaşağı", Price = 65 }
                );
        }
    }
}
