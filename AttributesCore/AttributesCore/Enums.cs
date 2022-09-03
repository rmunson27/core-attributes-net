using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.Core.Attributes;

#region Obsolete
/// <summary>
/// Indicates that an <see langword="enum"/>-type input should always be a named, defined value of its type.
/// Indicates that an <see langword="enum"/>-type output is always a named, defined value of its type.
/// </summary>
/// <remarks>
/// This can be considered the enum equivalent of including the nullability (<c>?</c>) operator on a type in a
/// nullable context.
/// <para/>
/// This attribute also covers bit sets of named, defined values if the <see langword="enum"/> type in question is
/// decorated with an instance of <see cref="FlagsAttribute"/>.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue | AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
[Obsolete(
    "This attribute has been deprecated in lieu of a richer nameability attribute system. "
        + $"Use {nameof(NameableEnumAttribute)} instead.")]
public sealed class NamedEnumAttribute : Attribute { }
#endregion

#region Type Decorators
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
#endregion

#region Nullability Operator Analogs
/// <summary>
/// Indicates that an <see langword="enum"/>-type input should always be a named, defined value of its type.
/// Indicates that an <see langword="enum"/>-type output is always a named, defined value of its type.
/// </summary>
/// <remarks>
/// This can be considered the enum equivalent of excluding the nullability (<c>?</c>) operator on a type in a
/// nullable context.
/// <para/>
/// This attribute also covers bit sets of named, defined values if the <see langword="enum"/> type in question is
/// decorated with an instance of <see cref="FlagsAttribute"/>.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue | AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NameableEnumAttribute : Attribute { }

/// <summary>
/// Indicates that an <see langword="enum"/>-type input or output may not be a named, defined value of its type.
/// </summary>
/// <remarks>
/// This can be considered the enum equivalent of including the nullability (<c>?</c>) operator on a type in a
/// nullable context.
/// <para/>
/// This attribute also covers bit sets of named, defined values if the <see langword="enum"/> type in question is
/// decorated with an instance of <see cref="FlagsAttribute"/>.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue | AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NonNameableEnumAttribute : Attribute { }
#endregion

#region Nullable Attribute Analogs
/// <summary>
/// Specifies that an unnamed enum value is allowed as an input even if the corresponding type or enum nameability
/// attributes disallow it.
/// </summary>
/// <seealso cref="NameableEnumAttribute"/>
/// <seealso cref="NonNameableEnumAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property,
    AllowMultiple = false,
    Inherited = false)]
public sealed class AllowUnnamedAttribute : Attribute { }

/// <summary>
/// Specifies that an unnamed enum value is disallowed as an input even if the corresponding type or enum nameability
/// attributes allow it.
/// </summary>
/// <seealso cref="NameableEnumAttribute"/>
/// <seealso cref="NonNameableEnumAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property,
    AllowMultiple = false, Inherited = false)]
public sealed class DisallowUnnamedAttribute : Attribute { }

/// <summary>
/// Specifies that an unnamed enum value is allowed as an output even if the corresponding type or enum nameability
/// attributes disallow it.
/// </summary>
/// <seealso cref="NameableEnumAttribute"/>
/// <seealso cref="NonNameableEnumAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class MaybeUnnamedAttribute : Attribute { }

/// <summary>
/// Specifies that an output is a named enum value even if the corresponding type or enum nameability
/// attributes disallow it.
/// Specifies that an input argument was a named enum value when the call returns.
/// </summary>
/// <seealso cref="NameableEnumAttribute"/>
/// <seealso cref="NonNameableEnumAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NamedAttribute : Attribute { }

/// <summary>
/// Specifies that when a method returns <see cref="ReturnValue"/>, the parameter may be an unnamed enum value even
/// if the corresponding type or enum nameability attributes disallow it.
/// </summary>
/// <seealso cref="NameableEnumAttribute"/>
/// <seealso cref="NonNameableEnumAttribute"/>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class MaybeUnnamedWhenAttribute : Attribute
{
    /// <summary>
    /// Gets the boolean return value that indicates the nameability of the target.
    /// </summary>
    public bool ReturnValue { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="MaybeUnnamedWhenAttribute"/> class with the return value that
    /// indicates the nameability of the target.
    /// </summary>
    /// <param name="ReturnValue"></param>
    public MaybeUnnamedWhenAttribute(bool ReturnValue) { this.ReturnValue = ReturnValue; }
}

/// <summary>
/// Specifies that when a method returns <see cref="ReturnValue"/>, the parameter will be a named enum value even if
/// the corresponding type or enum nameability attributes disallow it.
/// </summary>
/// <seealso cref="NameableEnumAttribute"/>
/// <seealso cref="NonNameableEnumAttribute"/>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class NamedWhenAttribute : Attribute
{
    /// <summary>
    /// Gets the boolean return value that indicates the non-nameability of the target.
    /// </summary>
    public bool ReturnValue { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NamedWhenAttribute"/> class with the return value that
    /// indicates the non-nameability of the target.
    /// </summary>
    /// <param name="ReturnValue"></param>
    public NamedWhenAttribute(bool ReturnValue) { this.ReturnValue = ReturnValue; }
}

/// <summary>
/// Specifies that the output will be a named enum value if the named parameter is non-default.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = true,
    Inherited = false)]
public sealed class NamedIfNotDefaultAttribute : Attribute
{
    /// <summary>
    /// Gets the name of the parameter whose defaultability describes the nameability of the target.
    /// </summary>
    public string ParameterName { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NamedIfNotDefaultAttribute"/> class with the name of the
    /// parameter whose defaultability describes the nameability of the target.
    /// </summary>
    /// <param name="ParameterName"></param>
    public NamedIfNotDefaultAttribute(string ParameterName) { this.ParameterName = ParameterName; }
}

/// <summary>
/// Specifies that the output will be a named enum value if the named parameter is a named enum value.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = true,
    Inherited = false)]
public sealed class NamedIfNamedAttribute : Attribute
{
    /// <summary>
    /// Gets the name of the parameter whose nameability describes the nameability of the target.
    /// </summary>
    public string ParameterName { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NamedIfNamedAttribute"/> class with the name of the
    /// parameter whose nameability describes the nameability of the target.
    /// </summary>
    /// <param name="ParameterName"></param>
    public NamedIfNamedAttribute(string ParameterName) { this.ParameterName = ParameterName; }
}

/// <summary>
/// Specifies that the method or property will ensure that the listed field and property members have values that
/// are named enum values.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
public sealed class MemberNamedAttribute : Attribute
{
    /// <summary>
    /// Gets the names of methods or properties that will be named enum values when the target returns.
    /// </summary>
    public string[] MemberNames { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="MemberNamedAttribute"/> class with the name of a method or
    /// property that will be a named enum value when the target returns.
    /// </summary>
    /// <param name="MemberName"></param>
    public MemberNamedAttribute(string MemberName) { this.MemberNames = new[] { MemberName }; }

    /// <summary>
    /// Constructs a new instance of the <see cref="MemberNamedAttribute"/> class with the names of methods or
    /// properties that will be named enum values when the target returns.
    /// </summary>
    /// <param name="MemberNames"></param>
    public MemberNamedAttribute(params string[] MemberNames) { this.MemberNames = MemberNames; }
}
#endregion

#region Unnamed Enum Instance Members
/// <summary>
/// Specifies that an output of an <see langword="enum"/> instance property or method may be an unnamed value of
/// its type if the instance is the default.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class MaybeUnnamedIfInstanceDefaultAttribute : Attribute { }
#endregion

