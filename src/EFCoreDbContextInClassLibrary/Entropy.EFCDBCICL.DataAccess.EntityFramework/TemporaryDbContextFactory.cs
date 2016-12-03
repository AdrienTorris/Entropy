using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entropy.EFCDBCICL.DataAccess.EntityFramework
{
    public class TemporaryDbContextFactory : IDbContextFactory<MyDbContext>
    {
        private const string _CONNECTION_STRING = @"data source=M0157\\SQLSRVEXPRSS2014;initial catalog=POCValoris;persist security info=True;user id=pocvaloris;password=hjd3423!3jsd;MultipleActiveResultSets=True;";

        public MyDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseSqlServer(_CONNECTION_STRING);
            return new MyDbContext(builder.Options);
        }
    }
}