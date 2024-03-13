using System.ComponentModel.DataAnnotations;

namespace FlowerStore.Components
{
    /// <summary>
    /// Custom attribute for operation with prices. This will accept 2 double numbers and parse it to decimal.
    /// </summary>
    public class DecimalRangeAttribute : ValidationAttribute
    {
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }

        public DecimalRangeAttribute(double minValue, double maxValue)
        {
            MinValue = Convert.ToDecimal(minValue);
            MaxValue = Convert.ToDecimal(maxValue);
        }

        //Handle parsing
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;  //The Required attribute will handle this
            }

            decimal decimalValue;

            if (!decimal.TryParse(value.ToString(), out decimalValue))
            {
                return false;  //Not valid decimal
            }

            return decimalValue >= MinValue && decimalValue <= MaxValue;
        }
    }
}
