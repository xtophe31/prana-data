using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prana.Data
{
    public partial class User
    {
        public User()
            : base()
        {
            this.Person = new Person();
        }
    }
}
