using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tullvakt
{
    public class Tullvakt
    {
        public double BasePriceHigh = 1000;
        public double BasePriceLow = 500;
        

        public double Price(Car car, DateTime time)
        {
            var price = 0.0;
            price = ApplyRule1(price, car);
            price = ApplyRule2(price, car);
            price = ApplyRule3(price, time);
            price = ApplyRule4(price, car);
            price = ApplyRule6(price, car);
            price = ApplyRule7(price, time);
            price = ApplyRule8(price, car);
            return price;
        }

        private static bool IsWeekend(DateTime time)
        {
            return (time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday);
        }

        public double ApplyRule1(double price, Car car)
        {
            return car.Weight > 1000 ? BasePriceHigh : price;
        }

        public double ApplyRule2(double price, Car car)
        {
            return car.Weight < 1000 ? BasePriceLow : price;
        }

        public double ApplyRule3(double price, DateTime time)
        {
            if (!(IsWeekend(time)) && (time.Hour > 17 || time.Hour < 6))
                return price * 0.5;
            return price;
        }

        public double ApplyRule4(double price, Car car)
        {
            if (car.Typ == Car.Type.Lastbil) return 2000;
            return price;
        }

        public double ApplyRule6(double price, Car car)
        {
            if (car.Typ == Car.Type.Motorcykel) return price*0.7;
            return price;
        }

        public double ApplyRule7(double price, DateTime time)
        {
            if (IsWeekend(time)) return price*2;
            return price;
        }

        public double ApplyRule8(double price, Car car)
        {
            if (car.Miljobil) return 0;
            return price;
        }
    }

    public class Car
    {
        public enum Type
        {
            Lastbil,
            Motorcykel,
            Personbil
        };

        public Type Typ;
        public int Weight;
        public bool Miljobil;

    }


}

