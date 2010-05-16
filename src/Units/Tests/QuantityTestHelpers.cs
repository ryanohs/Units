namespace Units.Tests
{
	using NUnit.Framework;

	public class QuantityTestHelpers : AssertionHelper
	{
		protected static Quantity Bushels(decimal amount)
		{
			return new Quantity(amount, Unit.Bushels);
		}

		protected static Quantity Barrels(decimal amount)
		{
			return new Quantity(amount, Unit.Barrels);
		}

		protected static Quantity Smaller
		{
			get { return Bushels(1); }
		}

		protected static Quantity Bigger
		{
			get { return Bushels(2); }
		}

		protected static Quantity Equal
		{
			get { return Bushels(1); }
		}
	}
}