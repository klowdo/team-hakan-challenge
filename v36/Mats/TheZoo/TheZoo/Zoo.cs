using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using TheZoo.Animals;

namespace TheZoo
{
    public class Zoo
    {
        public List<IAnimal> Animals;

        public void FeedAllAnimals(string user)
        {
            if (String.IsNullOrEmpty(user)) throw new ArgumentException("user must be given", nameof(user));

            
            foreach (var animal in Animals)
            {
                animal.FeedMe(user);
            }
        }

        public Zoo()
        {
            //Add all animals. This is a manual process.
            Animals = new List<IAnimal> {new Rhino(), new Giraff(), new Lejon(), new Schimpans()};
        }
    }
}
