using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.Core.Attributes;

/// <summary>
/// Indicates that an <see langword="enum"/>-type property, field or return value should not accept values of its
/// type that are unnamed values.
/// </summary>
/// <remarks>
/// This attribute can also be used to indicate that a property, field or return value of an <see langword="enum"/>
/// type that is decorated with a <see cref="FlagsAttribute"/> should only accept a bit set of named values.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = true)]
public sealed class NamedEnumAttribute : Attribute { }

/// <summary>
/// Indicates that an <see langword="enum"/>-type parameter should be a named value of its type.
/// </summary>
/// <remarks>
/// This attribute can also be used to indicate that a parameter of an <see langword="enum"/>
/// type that is decorated with a <see cref="FlagsAttribute"/> should be a bit set of only named values.
/// </remarks>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class NamedEnumParameterAttribute : Attribute { }

