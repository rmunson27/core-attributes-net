using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Attributes;

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
