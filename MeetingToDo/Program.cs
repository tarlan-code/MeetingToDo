using MeetingToDo.Exceptions;
using MeetingToDo.Models;
using System.Text;

namespace MeetingToDo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool breakpoint = true;
            MeetingSchedule meets = new();
            do
            {
                
                Console.WriteLine("\n1.Gorush elave et\n2.Gorushleri ekrana yazdir\n3.Gorush sil\n4.Gorush adın deyish\n0.Cıxısh\n");
                Console.WriteLine("Komanda: ");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        meets.AddMeeting();
                        break;
                    case "2":
                        meets.Print();
                        break;
                    case "3":
                        meets.Print();
                        Console.WriteLine("Silmek istediyiniz gorushun ID-si ni daxil edin: ");
                        uint.TryParse(Console.ReadLine(), out uint id);
                        meets.DeleteMeet(id);
                        break;
                    case "4":
                        meets.Print();
                        Console.WriteLine("Adini deyismek istediyiniz gorushun ID-si ni daxil edin: ");
                        uint.TryParse(Console.ReadLine(), out uint idRename);
                        meets.RenameMeet(idRename);
                        break;

                    case "0":
                        breakpoint = false;
                        Console.WriteLine("Chixish edildi!");
                        break;
                    default:
                        Console.WriteLine("Yanlish komanda");
                        break;
                }
            } while (breakpoint);

        }

        
    }
}