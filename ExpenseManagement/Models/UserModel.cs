using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ExpenseManagement.Models
{
    [DataContract]
    public class UserModel
    {
        private int intUserId;
        private string stringUserName;
        private string stringUserEmail;
        private float intCredit;
        private float intDebit;
        private string stringPassword;

        [DataMember]
        public int UserId
        {
            get { return intUserId; }
            set { intUserId = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return stringUserName; }
            set { stringUserName = value; }
        }

        [DataMember]
        public string UserEmail
        {
            get { return stringUserEmail; }
            set { stringUserEmail = value; }
        }

        [DataMember]
        public float UserCredit
        {
            get { return intCredit; }
            set { intCredit = value; }
        }

        [DataMember]
        public float UserDebit
        {
            get { return intDebit; }
            set { intDebit = value; }
        }

        [DataMember]
        public string UserPassword
        {
            get { return stringPassword; }
            set { stringPassword = value; }
        }

    }
}
