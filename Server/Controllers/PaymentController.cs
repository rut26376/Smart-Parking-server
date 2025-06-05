using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    IBLPayment payment;
    public PaymentController(IBL manager)
    {
        payment = manager.Payment;
    }

    [HttpGet("GetPayments")]
    public async Task<List<BlPayment>> GetAllPayments() =>await payment.GetPayments();

    [HttpPost("AddPayment/{licensePlate}/{numOfPayments}")]

    public void Create(Shiluv shalvush, string licensePlate, int numOfPayments) => payment.Create(shalvush, licensePlate, numOfPayments);
}
