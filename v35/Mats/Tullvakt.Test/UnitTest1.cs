using System;
using NUnit.Framework;

namespace Tullvakt.Test
{

    public class UnitTest1

    {
        private static Car LattMotorcykel;
        private static Car TungMotorcykel;
        private static Car LattPersonbil;
        private static Car TungPersonbil;
        private static Car LattLastbil;
        private static Car TungLastbil;


        [SetUp]
        public void InitCars()
        {
            LattLastbil = new Car
            {
                Miljobil = false,
                Typ = Car.Type.Lastbil,
                Weight = 999
            };
            TungLastbil = new Car
            {
                Miljobil = false,
                Typ = Car.Type.Lastbil,
                Weight = 1001
            };
            LattMotorcykel = new Car
            {
                Miljobil = false,
                Typ = Car.Type.Motorcykel,
                Weight = 999
            };
            TungMotorcykel = new Car
            {
                Miljobil = false,
                Typ = Car.Type.Motorcykel,
                Weight = 1001
            };
            LattPersonbil = new Car
            {
                Miljobil = false,
                Typ = Car.Type.Personbil,
                Weight = 999
            };
            TungPersonbil = new Car
            {
                Miljobil = false,
                Typ = Car.Type.Personbil,
                Weight = 1001
            };

        }

        [TestCase()]
        public void Rule1(Car car)
        {
            var tullvakt = new Tullvakt();
            
            Assert.AreEqual(0,tullvakt.ApplyRule1(0,LattMotorcykel));
            Assert.AreEqual(0, tullvakt.ApplyRule1(0, LattLastbil));
            Assert.AreEqual(0, tullvakt.ApplyRule1(0, LattPersonbil));
            Assert.AreEqual(0, tullvakt.ApplyRule1(tullvakt.BasePriceHigh, TungMotorcykel));
            Assert.AreEqual(0, tullvakt.ApplyRule1(tullvakt.BasePriceHigh, TungLastbil));
            Assert.AreEqual(0, tullvakt.ApplyRule1(tullvakt.BasePriceHigh, TungPersonbil));
        }

        [Test]
        public void Rule2()
        {
            var tullvakt = new Tullvakt();
            Assert.AreEqual(0, tullvakt.ApplyRule1(tullvakt.BasePriceLow, LattMotorcykel));
            Assert.AreEqual(0, tullvakt.ApplyRule1(tullvakt.BasePriceLow, LattLastbil));
            Assert.AreEqual(0, tullvakt.ApplyRule1(tullvakt.BasePriceLow, LattPersonbil));
            Assert.AreEqual(0, tullvakt.ApplyRule1(0, TungMotorcykel));
            Assert.AreEqual(0, tullvakt.ApplyRule1(0, TungLastbil));
            Assert.AreEqual(0, tullvakt.ApplyRule1(0, TungPersonbil));
        }

        [Test]
        public void Rule3()
        {
            var tullvakt = new Tullvakt();

            double basePrice = 1000;

            var date1 = new DateTime(2016,9,3,18,1,0); //helg 18.01
            var date2 = new DateTime(2016, 9, 3, 17, 59, 0); //helg 17.59
            var date3 = new DateTime(2016, 9, 3, 6, 0, 0); //helg 6.00
            var date4 = new DateTime(2016, 9, 3, 5, 59, 0); //helg 5.59

            var date5 = new DateTime(2016, 9, 2, 18, 1, 0); //helg 18.01
            var date6 = new DateTime(2016, 9, 2, 17, 59, 0); //helg 17.59
            var date7 = new DateTime(2016, 9, 2, 6, 0, 0); //helg 6.00
            var date8 = new DateTime(2016, 9, 2, 5, 59, 0); //helg 5.59
            

            Assert.AreEqual(basePrice,tullvakt.ApplyRule3(basePrice,date1));
            Assert.AreEqual(basePrice, tullvakt.ApplyRule3(basePrice, date2));
            Assert.AreEqual(basePrice, tullvakt.ApplyRule3(basePrice, date3));
            Assert.AreEqual(basePrice, tullvakt.ApplyRule3(basePrice, date4));
            Assert.AreEqual(basePrice*0.5, tullvakt.ApplyRule3(basePrice, date5));
            Assert.AreEqual(basePrice, tullvakt.ApplyRule3(basePrice, date6));
            Assert.AreEqual(basePrice, tullvakt.ApplyRule3(basePrice, date7));
            Assert.AreEqual(basePrice*0.5, tullvakt.ApplyRule3(basePrice, date8));

        }


        [Test]
        public void Rule4()
        {
            var tullvakt = new Tullvakt();
            double baseprice = 666;
            Assert.AreEqual(baseprice, tullvakt.ApplyRule1(tullvakt.BasePriceLow, LattMotorcykel));
            Assert.AreEqual(baseprice, tullvakt.ApplyRule1(tullvakt.BasePriceLow, LattLastbil));
            Assert.AreEqual(baseprice, tullvakt.ApplyRule1(tullvakt.BasePriceLow, LattPersonbil));
            Assert.AreEqual(baseprice, tullvakt.ApplyRule1(0, TungMotorcykel));
            Assert.AreEqual(baseprice, tullvakt.ApplyRule1(0, TungLastbil));
            Assert.AreEqual(baseprice, tullvakt.ApplyRule1(0, TungPersonbil));
        }
        [Test]
        public void Rule5()
        {
        }
        [Test]
        public void Rule6()
        {
        }
        [Test]
        public void Rule7()
        {
        }
        [Test]
        public void Rule8()
        {
        }
    }
}
