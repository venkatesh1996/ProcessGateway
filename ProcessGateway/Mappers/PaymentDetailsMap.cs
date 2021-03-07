using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Entities;
using ProcessGateway.Models;

namespace ProcessGateway.Mappers
{
    public class PaymentDetailsMap: AutoMapper.Profile
    {
        public PaymentDetailsMap()
        {
        CreateMap<PaymentDetailsEntity, PaymentDetails>().ReverseMap();
        CreateMap<PaymentDetailsEntity, PaymentTry>().ReverseMap();
        }
    }
}
