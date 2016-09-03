namespace v35.Models.Vehicles
{
    public class Bike : Vehicle
    {
        public Bike() : base(250)
        {
        }

        public override bool IsBike() => true;
    }
}