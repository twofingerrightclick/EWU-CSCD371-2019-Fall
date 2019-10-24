using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PatternMatching.Tests
{
    [TestClass]
    public class TollCalculatorTests
    {
        [TestMethod]
        public void CalculateTollForCar_ShouldBe2()
        {
            TollCalculator tollCalc = new TollCalculator();
            var toll = tollCalc.CalculateToll(new Car());

            Assert.AreEqual(2.00m, toll);
        }

        [TestMethod]
        public void CalculateTollForTaxi_ShouldBe350()
        {
            TollCalculator tollCalc = new TollCalculator();
            var toll = tollCalc.CalculateToll(new Taxi());

            Assert.AreEqual(3.50m, toll);
        }

        [TestMethod]
        public void CalculateTollForBus_ShouldBe5()
        {
            TollCalculator tollCalc = new TollCalculator();
            var toll = tollCalc.CalculateToll(new Bus());

            Assert.AreEqual(5.00m, toll);
        }

        [TestMethod]
        public void CalculateTollForDeliveryTruck_ShouldBe10()
        {
            TollCalculator tollCalc = new TollCalculator();
            var toll = tollCalc.CalculateToll(new DeliveryTruck());

            Assert.AreEqual(10.00m, toll);
        }
    }
}
