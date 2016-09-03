namespace v35.Models.Vehicles
{
    public class EnviromentFriendlyCar : Vehicle
    {
        public EnviromentFriendlyCar() : base(1000m)
        {
        }

        public override bool IsEnviromentFriendly() => true;
    }
}