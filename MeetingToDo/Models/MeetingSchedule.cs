using MeetingToDo.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeetingToDo.Models
{
    internal class MeetingSchedule
    {
        Meeting[] Meetings;

        public MeetingSchedule()
        {
            Meetings = new Meeting[0];
        }
        public void SetMeeting(string fullname, DateTime from, DateTime to)
        {
            if (from <= DateTime.Now || to < from.AddSeconds(60) || from > to)
            {
                throw new WrongDateInterval("Yanlish tarix aralığı (Qeyd: Tarixler arasinda minimum 1 deqiqe olmalidir) ");
            }
            if (Meetings.Length > 0)
            {
                foreach (Meeting meet in Meetings)
                {
                    if (from >= meet.FromDate && from <= meet.ToDate || to >= meet.FromDate && to <= meet.ToDate)
                    {
                        throw new ReservedDateIntervalException("Bu tarix araliginda gorushunuz var");
                    }
                }
            }

            Array.Resize(ref Meetings, Meetings.Length + 1);
            Meetings[Meetings.Length - 1] = new Meeting()
            {
                FullName = fullname,
                FromDate = from,
                ToDate = to,
            };
        }

        public void AddMeeting()
        {
            Console.WriteLine("Gorushun bashligi:");
            string title = Console.ReadLine();
            Console.WriteLine("Numune: 2022-12-05 15:00");
            Console.WriteLine("Bashlangıc tarix: ");
            string from = Console.ReadLine();
            Console.WriteLine("Bitme tarix: ");
            string to = Console.ReadLine();

            try
            {

                SetMeeting(title, DateTime.Parse(from), DateTime.Parse(to));
                Console.WriteLine("Yeni gorush ugurla yaradildi!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Yazilan tarixler yanlishdir yeniden daxil edin");
            }
            catch (FormatException)
            {
                Console.WriteLine("Yazilan tarix formatlar yanlishdir yeniden daxil edin");
            }
            catch (ReservedDateIntervalException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (WrongDateInterval ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Print()
        {
            if (Meetings.Length > 0)
            {
                Console.WriteLine("ID\t\tBasliq\t\tBashganlic tarix\t\tBitme tarixi:\t\t");
                foreach (Meeting meet in Meetings)
                {
                    Console.WriteLine($"{meet.ID}\t\t{meet.FullName}\t\t{meet.FromDate}\t\t{meet.ToDate}");
                }

            }

            else
            {
                Console.WriteLine("Gorushunuz yoxdur");
            }

        }
    
        public void DeleteMeet(uint id)
        {
            if (id == 0)
            {
                Console.WriteLine("Yanlish sorgu!");
            }
            else if (Meetings.Length>=id)
            {
                Meeting[] newArr = new Meeting[Meetings.Length - 1];
                for (int i = 0; i < newArr.Length+1; i++)
                {
                    if (i < id - 1)
                        newArr[i] = Meetings[i];
                    else if (i > id - 1)
                    {
                        Meetings[i].ID--;
                        newArr[i-1] = Meetings[i];         
                    }
                }
                Meetings = newArr;
                Console.WriteLine($"{id} ID-li gorush silindi");
                Meeting.count--;
                
            }
            else
            {
                Console.WriteLine("Bu ID-ye uygun gorush tapilmadi!");
            }
        }

        public void RenameMeet(uint id)
        {
            if (id == 0)
            {
                Console.WriteLine("Yanlish sorgu!");
            }

            else if (Meetings.Length >= id)
            {
                Console.WriteLine($"{id} ID-li gorush uchun yeni bashliq: ");
                Meetings[id - 1].FullName = Console.ReadLine();
                Console.WriteLine("Bashliq deyishdirildi");
            }

            else
            {
                Console.WriteLine("Bu ID-ye uygun gorush tapilmadi!");
            }

        }
    }
}
