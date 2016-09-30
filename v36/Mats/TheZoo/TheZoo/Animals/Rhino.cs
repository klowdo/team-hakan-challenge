using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZoo.Animals
{
    public class Rhino : IAnimal
    {
        public void FeedMe(string user)
        {
            
            if (DateTime.Now.Month > 11 && DateTime.Now.Day > 24)
                Console.WriteLine(user + " - " + ((new DateTime(DateTime.Today.Year+1,12,24))-DateTime.Now).Days);
            else
            {
                Console.WriteLine(user + " - " + ((new DateTime(DateTime.Today.Year, 12, 24)) - DateTime.Today).Days);
            }
        }
    }
}
