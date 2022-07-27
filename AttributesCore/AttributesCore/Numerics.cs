using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Attributes;

#region Signs And Categories
#region Integral
/// <summary>
/// Specifies that an input should always be positive.
/// Specifies that an output is always positive.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class PositiveAttribute : Attribute { }

/// <summary>
/// Specifies that an input should never be negative.
/// Specifies that an output is never negative.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NonNegativeAttribute : Attribute { }

/// <summary>
/// Specifies that an input should never be zero.
/// Specifies that an output is never zero.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NonZeroAttribute : Attribute { }

/// <summary>
/// Specifies that an input should never be positive.
/// Specifies that an output is never positive.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NonPositiveAttribute : Attribute { }

/// <summary>
/// Specifies that an input should always be negative.
/// Specifies that an output is always negative.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NegativeAttribute : Attribute { }
#endregion

#region Real
/// <summary>
/// Specifies that an input should always be a whole number.
/// Specifies that an output is always a whole number.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class WholeNumberAttribute : Attribute { }

/// <summary>
/// Specifies that an input should always be finite.
/// Specifies that an output is always finite.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class FiniteAttribute : Attribute { }

/// <summary>
/// Specifies that an input should never be NaN.
/// Specifies that an output is never NaN.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NotNaNAttribute : Attribute { }
#endregion
#endregion

#region Inequalities
#region Less
/// <summary>
/// Specifies that an input is always less than the supplied integer.
/// Specifies that an output should always be less than the supplied integer.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class LessThanIntegerAttribute : Attribute
{
    /// <summary>
    /// The integer value the target is less than.
    /// </summary>
    public BigInteger Max { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class with the supplied maximum value.
    /// </summary>
    /// <param name="Max"></param>
    public LessThanIntegerAttribute(long Max)
    {
        this.Max = Max;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class with the supplied string
    /// representing the maximum value.
    /// </summary>
    /// <param name="Max"></param>
    public LessThanIntegerAttribute(ulong Max)
    {
        this.Max = Max;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class with the supplied string
    /// representing the maximum value.
    /// </summary>
    /// <remarks>
    /// This constructor is provided because <see cref="BigInteger"/> is not a valid attribute constructor
    /// parameter type.
    /// </remarks>
    /// <param name="MaxString"></param>
    /// <exception cref="ArgumentNullException"><paramref name="MaxString"/> was <see langword="null"/>.</exception>
    /// <exception cref="FormatException">
    /// <paramref name="MaxString"/> could not be parsed as a <see cref="BigInteger"/>.
    /// </exception>
    public LessThanIntegerAttribute(string MaxString)
    {
        this.Max = BigInteger.Parse(Throw.IfArgNull(MaxString, nameof(MaxString)));
    }
}

/// <summary>
/// Specifies that an input is always less than or equal to the supplied integer.
/// Specifies that an output should always be less than or equal to the supplied integer.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class LessThanOrEqualToIntegerAttribute : Attribute
{
    /// <summary>
    /// The integer value the target is less than or equal to.
    /// </summary>
    public BigInteger Max { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanOrEqualToIntegerAttribute"/> class with the
    /// supplied maximum value.
    /// </summary>
    /// <param name="Max"></param>
    public LessThanOrEqualToIntegerAttribute(long Max)
    {
        this.Max = Max;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanOrEqualToIntegerAttribute"/> class with the
    /// supplied maximum value.
    /// </summary>
    /// <param name="Max"></param>
    public LessThanOrEqualToIntegerAttribute(ulong Max)
    {
        this.Max = Max;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanOrEqualToIntegerAttribute"/> class with the
    /// supplied string representing the maximum value.
    /// </summary>
    /// <remarks>
    /// This constructor is provided because <see cref="BigInteger"/> is not a valid attribute constructor
    /// parameter type.
    /// </remarks>
    /// <param name="MaxString"></param>
    /// <exception cref="ArgumentNullException"><paramref name="MaxString"/> was <see langword="null"/>.</exception>
    /// <exception cref="FormatException">
    /// <paramref name="MaxString"/> could not be parsed as a <see cref="BigInteger"/>.
    /// </exception>
    public LessThanOrEqualToIntegerAttribute(string MaxString)
    {
        this.Max = BigInteger.Parse(Throw.IfArgNull(MaxString, nameof(MaxString)));
    }
}
#endregion

#region Not Equal
/// <summary>
/// Specifies that an input is never equal to the supplied integer.
/// Specifies that an output should never be equal to the supplied integer.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NotEqualToIntegerAttribute : Attribute
{
    /// <summary>
    /// The integer value the target is not equal to.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NotEqualToIntegerAttribute"/> class with the supplied value.
    /// </summary>
    /// <param name="Value"></param>
    public NotEqualToIntegerAttribute(long Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="NotEqualToIntegerAttribute"/> class with the supplied value.
    /// </summary>
    /// <param name="Value"></param>
    public NotEqualToIntegerAttribute(ulong Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="NotEqualToIntegerAttribute"/> class with the supplied string
    /// representing the value.
    /// </summary>
    /// <remarks>
    /// This constructor is provided because <see cref="BigInteger"/> is not a valid attribute constructor
    /// parameter type.
    /// </remarks>
    /// <param name="ValueString"></param>
    /// <exception cref="ArgumentNullException"><paramref name="ValueString"/> was <see langword="null"/>.</exception>
    /// <exception cref="FormatException">
    /// <paramref name="ValueString"/> could not be parsed as a <see cref="BigInteger"/>.
    /// </exception>
    public NotEqualToIntegerAttribute(string ValueString)
    {
        this.Value = BigInteger.Parse(Throw.IfArgNull(ValueString, nameof(ValueString)));
    }
}
#endregion

#region Greater
/// <summary>
/// Specifies that an input is always greater than the supplied integer.
/// Specifies that an output should always be greater than the supplied integer.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class GreaterThanIntegerAttribute : Attribute
{
    /// <summary>
    /// The integer value the target is less than.
    /// </summary>
    public BigInteger Min { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class with the supplied minimum value.
    /// </summary>
    /// <param name="Min"></param>
    public GreaterThanIntegerAttribute(long Min)
    {
        this.Min = Min;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class with the supplied minimum value.
    /// </summary>
    /// <param name="Min"></param>
    public GreaterThanIntegerAttribute(ulong Min)
    {
        this.Min = Min;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class with the supplied string
    /// representing the minimum value.
    /// </summary>
    /// <remarks>
    /// This constructor is provided because <see cref="BigInteger"/> is not a valid attribute constructor
    /// parameter type.
    /// </remarks>
    /// <param name="MinString"></param>
    /// <exception cref="ArgumentNullException"><paramref name="MinString"/> was <see langword="null"/>.</exception>
    /// <exception cref="FormatException">
    /// <paramref name="MinString"/> could not be parsed as a <see cref="BigInteger"/>.
    /// </exception>
    public GreaterThanIntegerAttribute(string MinString)
    {
        this.Min = BigInteger.Parse(Throw.IfArgNull(MinString, nameof(MinString)));
    }
}

/// <summary>
/// Specifies that an input is always greater than or equal to the supplied integer.
/// Specifies that an output should always be greater than or equal to the supplied integer.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class GreaterThanOrEqualToIntegerAttribute : Attribute
{
    /// <summary>
    /// The integer value the target is less than or equal to.
    /// </summary>
    public BigInteger Min { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanOrEqualToIntegerAttribute"/> class with the
    /// supplied minimum value.
    /// </summary>
    /// <param name="Min"></param>
    public GreaterThanOrEqualToIntegerAttribute(long Min)
    {
        this.Min = Min;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanOrEqualToIntegerAttribute"/> class with the
    /// supplied minimum value.
    /// </summary>
    /// <param name="Min"></param>
    public GreaterThanOrEqualToIntegerAttribute(ulong Min)
    {
        this.Min = Min;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanOrEqualToIntegerAttribute"/> class with the
    /// supplied string representing the minimum value.
    /// </summary>
    /// <remarks>
    /// This constructor is provided because <see cref="BigInteger"/> is not a valid attribute constructor
    /// parameter type.
    /// </remarks>
    /// <param name="MinString"></param>
    /// <exception cref="ArgumentNullException"><paramref name="MinString"/> was <see langword="null"/>.</exception>
    /// <exception cref="FormatException">
    /// <paramref name="MinString"/> could not be parsed as a <see cref="BigInteger"/>.
    /// </exception>
    public GreaterThanOrEqualToIntegerAttribute(string MinString)
    {
        this.Min = BigInteger.Parse(Throw.IfArgNull(MinString, nameof(MinString)));
    }
}
#endregion
#endregion
