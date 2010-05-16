namespace Units.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class QuantityTests : QuantityTestHelpers
	{
		[Test]
		public void Equals_EquivalentInstances_AreEqual()
		{
			var equivalent1 = Bushels(1);
			var equivalent2 = Bushels(1);

			Expect(equivalent1.Equals(equivalent2));
		}

		[Test]
		public void Equals_SameInstance_AreEqual()
		{
			var sameInstance1 = Bushels(1);
			var sameInstance2 = sameInstance1;

			Expect(sameInstance1.Equals(sameInstance2));
		}

		[Test]
		public void EqualsOperator_EquivalentInstances_AreEqual()
		{
			var equivalent1 = Bushels(1);
			var equivalent2 = Bushels(1);

			Expect(equivalent1 == equivalent2);
		}

		[Test]
		public void EqualsOperator_SameInstance_AreEqual()
		{
			var sameInstance1 = Bushels(1);
			var sameInstance2 = sameInstance1;

			Expect(sameInstance1 == sameInstance2);
		}

		[Test]
		public void NotEquals_DifferentUnits_AreNotEqual()
		{
			var bu = Bushels(1);
			var bbl = Barrels(1);

			Expect(bu != bbl);
		}

		[Test]
		public void NotEquals_DifferentAmounts_AreNotEqual()
		{
			var bigger = Bigger;
			var smaller = Smaller;

			Expect(bigger != smaller);
		}

		[Test]
		public void Addition_SameUnits_SumsToTotal()
		{
			var bu1 = Bushels(1);
			var bu2 = Bushels(1);

			var total = bu1 + bu2;

			Expect(total.Amount == 2);
		}

		[Test]
		public void Addition_SameUnits_KeepsCorrectUnits()
		{
			var bu1 = Bushels(1);
			var bu2 = Bushels(1);

			var total = bu1 + bu2;

			Expect(total.Unit == Unit.Bushels);
		}

		[Test]
		public void Subtraction_SameUnits_SumsToTotal()
		{
			var bigger = Bushels(3);
			var smaller = Bushels(1);

			var total = bigger - smaller;

			Expect(total.Amount == 2);
		}

		[Test]
		public void Subtraction_SameUnits_KeepsCorrectUnits()
		{
			var bigger = Bushels(3);
			var smaller = Bushels(1);

			var total = bigger - smaller;

			Expect(total.Unit == Unit.Bushels);
		}

		[Test]
		public void Multiplication_ByScalar_AmountIsMultiplied()
		{
			var currency = Bushels(2);

			var total = currency * 3;

			Expect(total.Amount == 6);
		}

		[Test]
		public void Multiplication_ByScalar_KeepsUnits()
		{
			var currency = Bushels(2);

			var total = currency * 3;

			Expect(total.Unit == Unit.Bushels);
		}

		[Test]
		public void Division_ByScalar_AmountIsDivided()
		{
			var currency = Bushels(6);

			var total = currency / 3;

			Expect(total.Amount == 2);
		}

		[Test]
		public void Division_ByScalar_KeepsUnits()
		{
			var currency = Bushels(6);

			var total = currency / 3;

			Expect(total.Unit == Unit.Bushels);
		}

		[Test]
		public void Division_BySameUnits_ScalarResult()
		{
			var bigger = Bushels(6);
			var smaller = Bushels(3);

			var scalar = bigger / smaller;

			Expect(scalar == 2);
		}

		[Test]
		public void Division_ByDifferentUnits_Exception()
		{
			var bu = Bushels(6);
			var bbl = Barrels(3);

			decimal blowUp;
			TestDelegate action = () => blowUp = bu / bbl;

			Expect(action, Throws.Exception);
		}

		[Test]
		public void Modulus_ByScalar_ReturnsRemainder()
		{
			var currency = Bushels(6);

			var total = currency % 5;

			Expect(total.Amount == 1);
		}

		[Test]
		public void Modulus_ByScalar_KeepsUnits()
		{
			var currency = Bushels(6);

			var total = currency % 5;

			Expect(total.Unit == Unit.Bushels);
		}

		[Test]
		public void ImplicitCast_ResultIsAmount()
		{
			var currency = Bushels(1);

			decimal amount = currency;

			Expect(amount == 1m);
		}

		[Test]
		public void LessThan_IsLessThan_True()
		{
			Expect(Smaller < Bigger);
		}

		[Test]
		public void LessThan_IsGreaterThan_False()
		{
			Expect(Bigger < Smaller, Is.False);
		}

		[Test]
		public void LessThanOrEqualTo_IsLessThan_True()
		{
			Expect(Smaller < Bigger);
		}

		[Test]
		public void LessThanOrEqualTo_AreEqual_True()
		{
			Expect(Equal <= Equal);
		}

		[Test]
		public void LessThanOrEqualTo_IsGreaterThan_False()
		{
			Expect(Bigger < Smaller, Is.False);
		}

		[Test]
		public void GreaterThan_IsGreaterThan_True()
		{
			Expect(Bigger > Smaller);
		}

		[Test]
		public void GreaterThan_IsLessThan_False()
		{
			Expect(Smaller > Bigger, Is.False);
		}

		[Test]
		public void GreaterThanOrEqual_IsGreaterThan_True()
		{
			Expect(Bigger >= Smaller);
		}

		[Test]
		public void GreaterThanOrEqual_IsEqual_True()
		{
			Expect(Equal >= Equal);
		}

		[Test]
		public void GreaterThanOrEqual_IsLessThan_False()
		{
			Expect(Smaller >= Bigger, Is.False);
		}

		[Test]
		public void ToString_Formatted()
		{
			var quantity = new Quantity(1, Unit.Bushels);

			var result = quantity.ToString();

			Expect(result == "1 Bushels");
		}
	}
}