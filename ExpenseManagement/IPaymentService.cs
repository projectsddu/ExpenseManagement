using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Models;
namespace ExpenseManagement
{
    [ServiceContract]
    public interface IPaymentService
    {
        [OperationContract]
        PaymentModel AddPayment(PaymentModel payment);

        [OperationContract]
        Boolean DeletePayment(int paymentId);

        [OperationContract]
        PaymentModel UpdatePayment(PaymentModel payment);

        [OperationContract]
        PaymentModel ViewSinglePayment(int paymentId);

        [OperationContract]
        List<PaymentModel> ViewAllPayment(int userId);
    }
}
