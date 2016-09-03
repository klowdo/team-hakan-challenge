using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using System;
using v35.Interfaces;
using v35.Models;
using v35.Models.Vehicles;
using v35.Services;

namespace v35.Tests
{
    internal class HåkanHellströmCountryCustomsTest
    {
        private readonly DateTime _evening = new DateTime(2016, 09, 03, 19, 15, 00);
        private readonly DateTime _midday = new DateTime(2016, 09, 03, 15, 15, 00);
        private readonly DateTime _morning = new DateTime(2016, 09, 03, 05, 15, 00);

        [Test]
        public void Car_RegularDay()
        {
            ExpectPrice(new Car(), 1000, _midday);
        }

        [Test]
        public void Light_Car_RegularDay()
        {
            var lightCar = new Car();
            lightCar.RemoveWeight(100);
            ExpectPrice(lightCar, 500, _midday);
        }

        [Test]
        public void Car_EveningDay()
        {
            ExpectPrice(new Car(), 500, _evening);
            var lightCar = new Car();
            lightCar.RemoveWeight(100);
            ExpectPrice(lightCar, 250, _evening);
        }

        [Test]
        public void Car_MorningDay()
        {
            ExpectPrice(new Car(), 500, _morning);
            var lightCar = new Car();
            lightCar.RemoveWeight(100);
            ExpectPrice(lightCar, 250, _morning);
        }

        [Test]
        public void Truck()
        {
            ExpectPrice(new Truck(), 2000, _midday);
            ExpectPrice(new Truck(), 1000, _morning);
            ExpectPrice(new Truck(), 4000, _midday, true);
            ExpectPrice(new Truck(), 2000, _morning, true);
        }

        [Test]
        public void Bike()
        {
            ExpectPrice(new Bike(), 700, _midday);
            ExpectPrice(new Bike(), 350, _morning);
            ExpectPrice(new Bike(), 1400, _midday, true);
        }

        [Test]
        public void EnviromentFriendlVehicle()
        {
            ExpectPrice(new EnviromentFriendlyCar(), 0, _morning);
            ExpectPrice(new EnviromentFriendlyBike(), 0, _morning);
            ExpectPrice(new EnviromentFriendlyTruck(), 0, _morning);
            ExpectPrice(new EnviromentFriendlyCar(), 0, _midday);
            ExpectPrice(new EnviromentFriendlyBike(), 0, _midday);
            ExpectPrice(new EnviromentFriendlyTruck(), 0, _midday);
        }

        private void ExpectPrice(Vehicle vehicle, decimal expectedPrice, DateTime dateTime,
            bool isItHoliday = false)
        {
            CreateSut(dateTime, isItHoliday)
                .CalculatePrice(vehicle)
                .Should()
                .Be(expectedPrice);
        }

        private HåkanHellströmCountryCustoms CreateSut(DateTime dateTime, bool isItHoliday = false)
        {
            var holiday = A.Fake<IHoliday>();
            A.CallTo(() => holiday.IsItHoliday()).Returns(isItHoliday);
            var date = A.Fake<IDateTime>();
            A.CallTo(() => date.Now()).Returns(dateTime);
            return new HåkanHellströmCountryCustoms(holiday, date);
        }
    }
}