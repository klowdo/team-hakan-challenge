using FluentAssertions;
using NUnit.Framework;
using v35.Interfaces;
using v35.Models.Vehicles;

namespace v35.Tests
{
    public class VehicleTest
    {
        [Test]
        public void Overide_Property()
        {
            var car = new Car();
            car.Should()
                .NotBeOfType<IEnviromentFriendly>();
            var enviromentFriendlyCar = new EnviromentFriendlyCar();
            Assert.IsInstanceOf<IEnviromentFriendly>(enviromentFriendlyCar);
        }

        [Test]
        public void Weight_Change()
        {
            var initWeight = 1000m;
            var carChange = 300m;
            var car = new Car();
            car.AddWeight(carChange);
            car.Weight.Should().Be(initWeight + carChange);
            car.RemoveWeight(carChange);
            car.Weight.Should().Be(1000m);
        }

        [Test]
        public void Car_Is_Not_Bike()
        {
            var car = new Car();
            Assert.IsNotInstanceOf<Bike>(car);
        }

        [Test]
        public void Bike_Is_Bike()
        {
            var bike = new Bike();
            Assert.IsInstanceOf<Bike>(bike);
            Assert.IsNotAssignableFrom<ILarge>(bike);
        }

        [Test]
        public void Truck_Is_Truck()
        {
            var truck = new Truck();
            Assert.IsInstanceOf<ILarge>(truck);
        }

        [Test]
        public void Car_Is_Not_Truck()
        {
            var car = new Car();
            Assert.IsNotInstanceOf<ILarge>(car);
        }
    }
}