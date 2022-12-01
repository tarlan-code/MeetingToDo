using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingToDo.Models
{
    internal class Meeting
    {
        DateTime _fromDate;
        DateTime _toDate;
        string _fullName;
        public static uint count = 1;

        public DateTime FromDate
        {
            get => _fromDate;   
            init => _fromDate = value;
        }

        public DateTime ToDate
        {
            get => _toDate;
            init => _toDate = value;
        }

        public string FullName {
            get => _fullName;
            set
            {
                value = value.Trim();   
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                    _fullName = "New Meeting";
                else
                {
                    
                    if (value.Length>30)
                    {
                        value.Substring(0,30);
                    }
                    _fullName = value;
                }
            }
        }


        public uint ID { get; set; }

        public Meeting()
        {
            ID = count++;
        }

    }
}
