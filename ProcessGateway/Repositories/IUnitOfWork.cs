using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessGateway.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentProcessRepository PaymentProcesses { get; }
        Task<int> CompleteAsync();
    }
}
