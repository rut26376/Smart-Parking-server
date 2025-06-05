using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Services;

public class BlPaymentService : IBLPayment
{
    IDal dal;

    //c-tor
    public BlPaymentService(IDal dal) => this.dal = dal;
    public void Create(Shiluv shalvush, string licensePlate, int numOfPayments)
    {
        BlPayment p = shalvush.BlPayment;
        BlCreditCards cc = shalvush.BlCreditCards;
        if (!(dal.CreditCard.GetAll().Exists(c => c.CreditCardNum == cc.CreditCardNum && c.Cvv == cc.Cvv && c.Id == cc.Id)))
        {
            p.CreditCardCode = dal.CreditCard.Create(new CreditCard() { CreditCardNum = cc.CreditCardNum, Id = cc.Id, Cvv = cc.Cvv, ValidityCard = cc.ValidityCard, DriverCode = cc.DriverCode });
        }


        var paymentCode = dal.Payments.Create(new Payment() { RoutinelyCode = dal.Routines.GetRoutines().FindLast(r => r.LicensePlate == licensePlate).Code, CreditCardCode = p.CreditCardCode, Sum = p.Sum, Date = DateTime.Now.Date });
        DateTime d = DateTime.Now.Date;
        for (int i = 0; i < numOfPayments; i++)
        {
            dal.Details.Create(new PaymentsDetail() { PaymentCode = paymentCode, Date = d, Sum = p.Sum / numOfPayments, Paid = false });
            d = d.AddMonths(1);
        }
        var parkingC = dal.Routines.GetRoutines().FindLast(r => r.LicensePlate == licensePlate).ParkingCode;
        dal.Parkings.Update(parkingC);

    }
    public async Task<List<BlPayment>> GetPayments()
    {
        var pList = dal.Payments.GetPayments().Result;
        List<BlPayment> list = new();
        List<BlPaymentDetail> detailP = new List<BlPaymentDetail>();
        pList.ForEach(async p =>
        {
            p.PaymentsDetails.ToList().ForEach(pd => detailP.Add(new BlPaymentDetail() { Code = pd.Code, Sum = pd.Sum, Date = pd.Date }));
            list.Add(new BlPayment()
            {
                CreditCardCode = p.CreditCardCode,
                Sum = p.Sum,
                Date = p.Date,
               PaymentsDetails =detailP.Count>1? detailP.ToList():null
            }) ; 
            
            detailP.Clear();
        });
        return list;

    }


}