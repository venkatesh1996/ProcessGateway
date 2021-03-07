using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Entities;
using ProcessGateway.Repositories;
using ProcessGateway.Process;
using ProcessGateway.Payment_Gateway;
using Microsoft.EntityFrameworkCore;

namespace ProcessGateway.Repositories
{
    public class PaymentProcessRepository : BaseRepository<PaymentDetailsEntity, string>, IPaymentProcessRepository
    {
        protected readonly PGDbContext _context;

        public PaymentProcessRepository(PGDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.PaymentProcesses.AnyAsync(e => e.PId.Equals(id));
        }

        public async Task<List<PaymentDetailsEntity>> GetPendingPayments()
        {
            return await _context.PaymentProcesses.Where(a => a.process.Equals(ProcessState.PENDING)).ToListAsync();
        }

        public async Task ProcessPendingPayments()
        {
            IList<PaymentDetailsEntity> pendingPayment = await GetPendingPayments();
            IPaymentGateway _paymentFactory = new PaymentGateway();


            foreach (PaymentDetailsEntity _payment in pendingPayment)
            {
                // Payment Condition
                if (_payment.Amount > 500)
                {
                    // IPremium Payment Gateway
                    if (_paymentFactory.PremiumPayments.MakePayment())
                    {
                        _payment.process = ProcessState.PROCESSED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    else
                    {
                        _payment.process = ProcessState.PENDING;
                        _payment.Tries = _payment.Tries + 1;

                        if (_payment.Tries == 3)
                        {
                            _payment.process = ProcessState.FAILED;
                        }
                        _ = await this.UpdateAsync(_payment);
                    }
                    _ = _context.SaveChangesAsync();
                    continue;
                }

                if (_payment.Amount < 21)
                {
                    // ICheap Payment Gateway
                    if (_paymentFactory.CheapPayments.MakePayment())
                    {
                        _payment.process = ProcessState.PROCESSED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    else
                    {
                        _payment.process = ProcessState.FAILED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    _ = _context.SaveChangesAsync();
                    continue;
                }

                if (_payment.Amount <= 500)
                {
                    // Check Expensive payment availability
                    if (_paymentFactory.ExpensivePayments.CheckAvailability() && _paymentFactory.ExpensivePayments.MakePayment())
                    {
                        _payment.process = ProcessState.PROCESSED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    // Try ICheap Payment Gateway
                    else if (_paymentFactory.CheapPayments.MakePayment())
                    {
                        _payment.process = ProcessState.PROCESSED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    else
                    {
                        _payment.process = ProcessState.FAILED;
                        _payment.Tries = _payment.Tries + 1;
                        _ = await this.UpdateAsync(_payment);
                    }
                    _ = _context.SaveChangesAsync();
                    continue;
                }
            }
        }
    }
}
