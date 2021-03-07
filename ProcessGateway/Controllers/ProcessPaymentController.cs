using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Models;
using ProcessGateway.Entities;
using ProcessGateway.Process;
using ProcessGateway.Validators;
using ProcessGateway.Repositories;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace ProcessGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPaymentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Brand management constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public ProcessPaymentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentTry>>> GetAsync()
        {
            List<PaymentTry> _DTO = null;

            try
            {
                IEnumerable<PaymentDetailsEntity> _payments = await _unitOfWork.PaymentProcesses.GetAllAsync();
                _DTO = _mapper.Map<List<PaymentTry>>(_payments);

                return Ok(_DTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        // POST: api/PaymentProcesses
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentProcess"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PaymentTry>> PostPaymentProcess(PaymentDetails paymentProcess)
        {
            try
            {

                // Request validation
                PaymentDetailsValidator _validator = new PaymentDetailsValidator();
                ValidationResult result = _validator.Validate(paymentProcess);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                PaymentDetailsEntity _paymentProcess = _mapper.Map<PaymentDetailsEntity>(paymentProcess);
                _paymentProcess.PId = Guid.NewGuid().ToString();
                _paymentProcess.process = ProcessState.PENDING;
                _paymentProcess.Tries = 0;

                _ = _unitOfWork.PaymentProcesses.InsertAsync(_paymentProcess);

                await _unitOfWork.CompleteAsync();

                return Ok(_paymentProcess);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }

}
