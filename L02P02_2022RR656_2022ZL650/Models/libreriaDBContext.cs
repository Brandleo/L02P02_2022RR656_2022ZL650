using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L02P02_2022RR656_2022ZL650.Models
{
    public class libreriaDBContext: DbContext
    {

        public libreriaDBContext(DbContextOptions<libreriaDBContext> options): base(options) 
        {




        }

        public DbSet<autores> autores { get; set; }

    }
}
