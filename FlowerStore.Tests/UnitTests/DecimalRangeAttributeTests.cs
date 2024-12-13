using FlowerStore.Components;

namespace FlowerStore.Tests.UnitTests
{
    /// <summary>
    /// This attribute is tested because appeared as not tested in coverlet
    /// </summary>

    [TestFixture]
    internal class DecimalRangeAttributeTests
    {
        //IsValid tests
        [Test]
        public void IsValid_WhenValueIsWithinRange_ReturnsTrue()
        {
            var attribute = new DecimalRangeAttribute(0.5, 10.5);

            var result = attribute.IsValid(5.5m);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValid_WhenValueIsBelowMin_ReturnsFalse()
        {
            var attribute = new DecimalRangeAttribute(1.0, 10.0);

            var result = attribute.IsValid(-183.00m);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValid_WhenValueIsAboveMax_ReturnsFalse()
        {
            var attribute = new DecimalRangeAttribute(1.0, 10.0);

            var result = attribute.IsValid(1232.00m);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValid_WhenValueIsNull_ReturnsTrue()
        {
            var attribute = new DecimalRangeAttribute(1.0, 10.0);

            var result = attribute.IsValid(null);

            Assert.That(result, Is.True); //RequiredAttribute will handle the null
        }

        [Test]
        public void IsValid_WhenValueIsInvalid_ReturnsFalse()
        {
            var attribute = new DecimalRangeAttribute(1.0, 10.0);

            var result = attribute.IsValid("invalid");

            Assert.That(result, Is.False);
        }

        //Constructor tests
        [Test]
        public void Constructor_WhenValuesAreValid_ConvertsDoubleToDecimalCorrectly()
        {
            var attribute = new DecimalRangeAttribute(1.5, 10.5);

            Assert.That(attribute.MinValue, Is.EqualTo(1.5m));
            Assert.That(attribute.MaxValue, Is.EqualTo(10.5m));
        }
    }
}
