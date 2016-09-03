namespace v35.Models.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck() : base(2000)
        {
        }

        public override bool IsLarge() => true;
    }
}