using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;

namespace ProcessGateway.Workers
{
    public class PaymentDetailsWorker : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public PaymentDetailsWorker(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Run(() => PaymentProcessService(stoppingToken));
        }

        private async void PaymentProcessService(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<PGDbContext>();
                    _ = new UnitOfWork(dbContext).PaymentProcesses.ProcessPendingPayments();
                }
                

                await Task.Delay((2 * 60 * 1000), stoppingToken); 
            }
        }
    }
}
