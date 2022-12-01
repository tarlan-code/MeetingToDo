using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingToDo.Exceptions
{
    internal class WrongDateInterval:Exception
    {
        public WrongDateInterval(string message):base(message)
        {

        }
    }
}
