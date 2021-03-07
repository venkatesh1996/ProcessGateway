using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProcessGateway.Repositories
{
    public class PGDbContext:DbContext
    {
        public PGDbContext(DbContextOptions<PGDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Add PaymentProcess dataset to DBContext
        /// </summary>
        public DbSet<PaymentDetailsEntity> PaymentProcesses { get; set; }
    }
}
