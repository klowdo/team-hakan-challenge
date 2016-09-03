using FluentAssertions;
using NUnit.Framework;
using v35.Models.Vehicles;

namespace v35.Tests
{
    public class VehicleTest
    {
        [Test]
        public void Overide_Property()
        {
            var car = new Car();
            car.IsEnviromentFriendly()
                .Should()
                .Be(false);
            var enviromentFriendlyCar = new EnviromentFriendlyCar();
            enviromentFriendlyCar
                .IsEnviromentFriendly()
                .Should()
                .Be(true);
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
            car.IsBike()
                .Should()
                .Be(false, "Car is not bike");
        }

        [Test]
        public void Bike_Is_Bike()
        {
            var bike = new Bike();
            bike.IsBike()
                .Should()
                .Be(true, "It is a bike");
        }

        [Test]
        public void Truck_Is_Truck()
        {
            var truck = new Truck();
            truck.IsLarge()
                .Should()
                .Be(true, "It is a truck duh");
        }

        [Test]
        public void Car_Is_Not_Truck()
        {
            var car = new Car();
            car.IsLarge()
                .Should()
                .Be(false, "It is not a truck");
        }
    }
}