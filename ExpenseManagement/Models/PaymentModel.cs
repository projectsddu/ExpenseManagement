using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManagement.Models
{
    public class PaymentModel
    {
        private int paymentId;
        private string paymentDescription;
        private DateTime paymentDate;
        private float paymentAmount;
        private string paymentToUser;
        private string paymentFromUser;

        [DataMember]
        public int PaymentId
        {
            get { return this.paymentId; }
            set { this.paymentId = value; }
        }

        [DataMember]
        public string PaymentDescription
        {
            get { return this.paymentDescription; }
            set { this.paymentDescription = value; }
        }

        [DataMember]
        public DateTime PaymentDate
        {
            get { return this.paymentDate; }
            set { this.paymentDate = value; }
        }

        [DataMember]
        public float PaymentAmount
        {
            get { return this.paymentAmount; }
            set { this.paymentAmount = value; }
        }

        [DataMember]
        public string PaymentToUser
        {
            get { return this.paymentToUser; }
            set { this.paymentToUser = value; }
        }

        [DataMember]
        public string PaymentFromUser
        {
            get { return this.paymentFromUser; }
            set { this.paymentFromUser = value; }
        }
    }
}
