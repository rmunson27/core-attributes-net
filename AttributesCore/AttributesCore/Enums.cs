using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.Core.Attributes;

/// <summary>
/// Indicates that an <see langword="enum"/>-type input should always be a named, defined value of its type.
/// Indicates that an <see langword="enum"/>-type output is always a named, defined value of its type.
/// </summary>
/// <remarks>
/// This attribute also covers bit sets of named, defined values if the <see langword="enum"/> type in question is
/// decorated with an instance of <see cref="FlagsAttribute"/>.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue | AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NamedEnumAttribute : Attribute { }

/// <summary>
/// Indicates that the target <see langword="enum"/> represents a bit set of instances of a specified
/// <see langword="enum"/> type.
/// </summary>
/// <remarks>
/// Targets of this attribute should also be decorated with <see cref="FlagsAttribute"/>.
/// </remarks>
[AttributeUsage(AttributeTargets.Enum)]
public sealed class EnumBitSetOfAttribute : Attribute
{
    /// <summary>
    /// Gets the <see langword="enum"/> type that the decorated <see langword="enum"/> type is a bit set of.
    /// </summary>
    public Type EnumType { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="EnumBitSetOfAttribute"/> class.
    /// </summary>
    /// <param name="EnumType"></param>
    public EnumBitSetOfAttribute(Type EnumType) { this.EnumType = EnumType; }
}

