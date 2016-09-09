using v35.Interfaces;

namespace v35.Models.Vehicles
{
    public class Truck : Vehicle, ILarge
    {
        public Truck() : base(2000)
        {
        }
    }
}