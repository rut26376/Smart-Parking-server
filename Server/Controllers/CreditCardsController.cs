using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {

        IBLCreditCard creditCard;

        public CreditCardsController(IBL manager) => creditCard = manager.CreditCard;


        [HttpPost("addCreditCard")]
        public void addCreditCard(BlCreditCards c) => creditCard.Create(c);


        [HttpGet("getAll")]
        public List<BlCreditCards> getAll() => creditCard.GetCards();

        [HttpGet("get/{DriverCode}")]
        public List<BlCreditCards> getAll(string DriverCode) => creditCard.GetCardsForDriver(DriverCode);
    }
}
