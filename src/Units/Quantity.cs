namespace Units
{
	using System;

	public class Quantity : IEquatable<Quantity>, IComparable<Quantity>, IComparable
	{
		private readonly decimal _Amount;
		private readonly Unit _Unit;

		public decimal Amount
		{
			get { return _Amount; }
		}

		public Unit Unit
		{
			get { return _Unit; }
		}

		public Quantity(decimal amount, Unit unit)
		{
			_Amount = amount;
			_Unit = unit;
		}

		#region Arithmetic Operators

		public static Quantity operator +(Quantity first, Quantity second)
		{
			RequireUnitsMatch(first, second);
			return new Quantity(first.Amount + second.Amount, first.Unit);
		}

		public static Quantity operator -(Quantity first, Quantity second)
		{
			RequireUnitsMatch(first, second);
			return new Quantity(first.Amount - second.Amount, first.Unit);
		}

		public static Quantity operator *(Quantity quantity, decimal multiplier)
		{
			return new Quantity(quantity.Amount * multiplier, quantity.Unit);
		}

		public static Quantity operator *(decimal multiplier, Quantity quantity)
		{
			return quantity * multiplier;
		}

		public static Quantity operator /(Quantity quantity, decimal denominator)
		{
			return new Quantity(quantity.Amount / denominator, quantity.Unit);
		}

		public static decimal operator /(Quantity numerator, Quantity denominator)
		{
			RequireUnitsMatch(numerator, denominator);
			return numerator.Amount / denominator.Amount;
		}

		public static Quantity operator %(Quantity quantity, decimal denominator)
		{
			return new Quantity(quantity.Amount % denominator, quantity.Unit);
		}

		#endregion

		#region Comparison Operators

		public static bool operator ==(Quantity left, Quantity right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Quantity left, Quantity right)
		{
			return !Equals(left, right);
		}

		public static bool operator <(Quantity first, Quantity second)
		{
			return first.CompareTo(second) < 0;
		}

		public static bool operator >(Quantity first, Quantity second)
		{
			return first.CompareTo(second) > 0;
		}

		public static bool operator <=(Quantity first, Quantity second)
		{
			return first.CompareTo(second) <= 0;
		}

		public static bool operator >=(Quantity first, Quantity second)
		{
			return first.CompareTo(second) >= 0;
		}

		#endregion

		public static implicit operator decimal(Quantity quantity)
		{
			return quantity.Amount;
		}

		public bool Equals(Quantity other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other.Amount == Amount && Equals(other.Unit, Unit);
		}

		public int CompareTo(Quantity other)
		{
			RequireUnitsMatch(this, other);
			return Amount.CompareTo(other.Amount);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Quantity)) return false;
			return Equals((Quantity) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Amount.GetHashCode() * 397) ^ Unit.GetHashCode();
			}
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (!(obj is Quantity))
			{
				throw new ArgumentException("Argument must be Quantity!", "obj");
			}
			return CompareTo((Quantity) obj);
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", Amount, Unit);
		}

		private static void RequireUnitsMatch(Quantity first, Quantity second)
		{
			if (UnitsMatch(first, second))
			{
				return;
			}
			throw new Exception("Quantities must have same units!");
		}

		private static bool UnitsMatch(Quantity first, Quantity second)
		{
			return first.Unit == second.Unit;
		}
	}
}