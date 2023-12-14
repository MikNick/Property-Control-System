using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class AssistManager : Employee
    {
        public AssistManager(int id, string name, string email, string role) : base(id, name, email, nameof(AssistManager))
        {
        }
    }
}
