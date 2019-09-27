using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Сompletion
{
    class Students
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalCode { get; set; }

        public string Status { get; set; }

        public Students(string firstName, string lastName, string personalCode, string status)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalCode = personalCode;
            this.Status = status;

        }
    }
}
