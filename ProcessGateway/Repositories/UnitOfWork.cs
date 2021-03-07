using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessGateway.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PGDbContext _context;

        public UnitOfWork(PGDbContext context)
        {
            _context = context;
            PaymentProcesses = new PaymentProcessRepository(_context);
        }

        public IPaymentProcessRepository PaymentProcesses { get; private set; }



        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
