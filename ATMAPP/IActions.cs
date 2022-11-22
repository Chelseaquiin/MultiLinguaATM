using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMAPP
{
    internal interface IActions
    {
        public void Deposit();
        public void Withdraw();
        public void Balance();
    }
}
