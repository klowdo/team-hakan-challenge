namespace v35.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(decimal weight)
        {
            Weight = weight;
        }

        public decimal Weight { get; private set; }

        public virtual bool IsEnviromentFriendly() => false;

        public void RemoveWeight(decimal weight)
        {
            Weight = Weight - weight;
        }

        public void AddWeight(decimal weight)
        {
            Weight = Weight + weight;
        }

        public virtual bool IsLarge() => false;

        public virtual bool IsBike() => false;
    }
}