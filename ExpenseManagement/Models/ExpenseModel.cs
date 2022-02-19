using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ExpenseManagement.Models
{
    [DataContract]
    public class ExpenseModel
    {
        private int expenseId;
        private string expenseDescription;
        private DateTime expenseDate;
        private int expenseAmount;
        private int expenseUserId;

        [DataMember]
        public int ExpenseId
        {
            get { return this.expenseId; }
            set { this.expenseId = value; }
        }

        [DataMember]
        public string ExpenseDescription
        {
            get { return this.expenseDescription; }
            set { this.expenseDescription = value; }
        }

        [DataMember]
        public DateTime ExpenseDate
        {
            get { return this.expenseDate; }
            set { this.expenseDate = value; }
        }

        [DataMember]
        public int ExpenseAmount
        {
            get { return this.expenseAmount; }
            set { this.expenseAmount = value; }
        }

        [DataMember]
        public int ExpenseUserId
        {
            get { return this.expenseUserId; }
            set { this.expenseUserId = value; }
        }
    }
}
