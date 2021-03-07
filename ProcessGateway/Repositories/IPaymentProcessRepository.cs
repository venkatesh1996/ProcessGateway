using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Entities;

namespace ProcessGateway.Repositories
{
    public interface IPaymentProcessRepository : IBaseRepository<PaymentDetailsEntity, string>
    {
        Task<bool> ExistsAsync(int id);
        Task ProcessPendingPayments();
    }
}
