using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheZoo.Animals
{
    class Lejon : IAnimal
    {
        public void FeedMe(string user)
        {
            Console.WriteLine(user + " - " + DateTime.Now.ToString("dd-MM"));
        }
    }
}
