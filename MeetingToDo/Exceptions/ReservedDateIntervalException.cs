using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingToDo.Exceptions
{
    internal class ReservedDateIntervalException : Exception
    {
        public ReservedDateIntervalException(string message) : base(message)
        {

        }
    }
}
