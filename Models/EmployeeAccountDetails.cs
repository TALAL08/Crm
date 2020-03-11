using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crm.Models
{
    public class EmployeeAccountDetails
    {
        public int Id { get; set; }
        public string BankName { get; set; }

        public string AccountNo { get; set; }

        public string IFSC { get; set; }

    }
}