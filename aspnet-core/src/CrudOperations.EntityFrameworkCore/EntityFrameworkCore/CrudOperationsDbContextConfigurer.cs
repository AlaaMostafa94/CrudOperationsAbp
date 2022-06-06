using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations.EntityFrameworkCore
{
    public static class CrudOperationsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CrudOperationsDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CrudOperationsDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
