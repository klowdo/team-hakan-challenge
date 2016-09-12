using v35.Interfaces;
using v35.Models;
using v35.Models.Vehicles;

namespace v35.Services
{
    public class HåkanHellströmCountryCustoms : Mutator<Vehicle, decimal>
    {
        private readonly IDateTime _dateTime;
        private readonly IHoliday _holiday;

        public HåkanHellströmCountryCustoms(IHoliday holiday, IDateTime dateTime) : base(1000)
        {
            _holiday = holiday;
            _dateTime = dateTime;
            InitRules();
        }

        private void InitRules()
        {
            //1: Om fordonet väger över 1000 kg så ska priset vara 1000 SEK
            //2: Om fordonet väger under 1000 kg så ska priset vara 500 SEK
            //4: Om fordonet är en Lastbil gäller inte regel 1 eller 2 utan då är det ett standardpris på 2000 SEK.
            //5: Priset för regel 1 och 2 gäller om fordonet är en personbil.

            AddMutation((price, vehicle) =>
            {
                if (vehicle is ILarge) return 2000;
                return vehicle.Weight < 1000 && !(vehicle is Bike) ? 500 : price;
            });
            //3: Om fordonet kör igenom tullen efter klockan 18:00 och innan 06:00 så ska priset vara det ordinarie priset minus 50%. Detta gäller endast veckodagar.
            AddMutation(
                (price, vehicle) => _dateTime.Now().Hour < 19 && _dateTime.Now().Hour > 6 ? price : price * 0.5m);
            //7: Priserna 1-6 gäller endast veckordagar. Alla helger plus högtider vill gränsvakterna ha dubbelt betalt och därmed ökar priset med 100%.
            AddMutation(
                (price, vehicle) => _holiday.IsItHoliday() ? price * 2 : price);
            //6: Om fordonet är en motorcykel är det priset för regel 1 och 2, minus 30 %.
            AddMutation(
                (price, vehicle) => vehicle is Bike ? price * 0.7m : price);
            //8: Om fordonet är en miljöbil vilket både lastbil, motorcykel och personbil kan vara så är kostnaden att passera 0 SEK till HåkanHellström - Landet. ¨
            AddMutation(
                (price, vehicle) => vehicle is IEnviromentFriendly ? 0m : price);
        }
    }
}