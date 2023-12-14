using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Manager : Employee
    {
        public Manager(int id, string name, string email, string role) : base(id, name, email, nameof(Manager))
        {
        }
    }
}
