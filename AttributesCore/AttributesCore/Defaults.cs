using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.Attributes;

#region Struct Defaultability
/// <summary>
/// Indicates that a <see langword="struct"/>-type property, field or return value that is default-determinable should
/// not accept the default value of its type.
/// </summary>
/// <remarks>
/// This is, in a way, the <i>opposite</i> of the struct equivalent of the nullability operator on types - the presence
/// of this attribute indicates that a default-determinable struct should be considered <i>not</i> defaultable.
/// </remarks>
/// <seealso cref="NonDefaultableStructParameterAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = true)]
public sealed class NonDefaultableStructAttribute : Attribute { }

/// <summary>
/// Indicates that a <see langword="struct"/>-type parameter that is default-determinable should not be the default
/// value of its type.
/// </summary>
/// <remarks>
/// This is, in a way, the <i>opposite</i> of the struct equivalent of the nullability operator on types - the presence
/// of this attribute indicates that a default-determinable struct should be considered <i>not</i> defaultable.
/// </remarks>
/// <seealso cref="NonDefaultableStructAttribute"/>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class NonDefaultableStructParameterAttribute : Attribute { }
#endregion

#region General-Purpose
#region Nullable Attribute Analogs
/// <summary>
/// Specifies that a default value is allowed as an input even if the corresponding type or struct defaultability
/// attributes disallow it.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property,
    AllowMultiple = false,
    Inherited = false)]
public sealed class AllowDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that a default value is disallowed as an input even if the corresponding type or struct defaultability
/// attributes allow it.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property,
    AllowMultiple = false, Inherited = false)]
public sealed class DisallowDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that a default value is allowed as an output even if the corresponding type or struct defaultability
/// attributes disallow it.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class MaybeDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that an output is not the default even if the corresponding type or struct defaultability attributes
/// allows it.
/// Specifies that an input argument was not default when the call returns.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NotDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that when a method returns <see cref="ReturnValue"/>, the parameter may be default even if the
/// corresponding type or struct defaultability attributes disallows it.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class MaybeDefaultWhenAttribute : Attribute
{
    /// <summary>
    /// Gets the boolean return value that indicates the defaultability of the target.
    /// </summary>
    public bool ReturnValue { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="MaybeDefaultWhenAttribute"/> class with the return value that
    /// indicates the defaultability of the target.
    /// </summary>
    /// <param name="ReturnValue"></param>
    public MaybeDefaultWhenAttribute(bool ReturnValue) { this.ReturnValue = ReturnValue; }
}

/// <summary>
/// Specifies that when a method returns <see cref="ReturnValue"/>, the parameter will not be default even if the
/// corresponding type or struct defaultability attributes allows it.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class NotDefaultWhenAttribute : Attribute
{
    /// <summary>
    /// Gets the boolean return value that indicates the non-defaultability of the target.
    /// </summary>
    public bool ReturnValue { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NotDefaultWhenAttribute"/> class with the return value that
    /// indicates the non-defaultability of the target.
    /// </summary>
    /// <param name="ReturnValue"></param>
    public NotDefaultWhenAttribute(bool ReturnValue) { this.ReturnValue = ReturnValue; }
}

/// <summary>
/// Specifies that the output will be non-default if the named parameter is non-default.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = true,
    Inherited = false)]
public sealed class NotDefaultIfNotDefaultAttribute : Attribute
{
    /// <summary>
    /// Gets the name of the parameter whose defaultability describes the defaultability of the target.
    /// </summary>
    public string ParameterName { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NotDefaultIfNotDefaultAttribute"/> class with the name of the
    /// parameter whose defaultability describes the defaultability of the target.
    /// </summary>
    /// <param name="ParameterName"></param>
    public NotDefaultIfNotDefaultAttribute(string ParameterName) { this.ParameterName = ParameterName; }
}

/// <summary>
/// Specifies that the method or property will ensure that the listed field and property members have values that
/// aren't default.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
public sealed class MemberNotDefaultAttribute : Attribute
{
    /// <summary>
    /// Gets the names of methods or properties that will not be default when the target returns.
    /// </summary>
    public string[] MemberNames { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="MemberNotDefaultAttribute"/> class with the name of a method or
    /// property that will not be default when the target returns.
    /// </summary>
    /// <param name="MemberNames"></param>
    public MemberNotDefaultAttribute(string MemberName) { this.MemberNames = new[] { MemberName }; }

    /// <summary>
    /// Constructs a new instance of the <see cref="MemberNotDefaultAttribute"/> class with the names of methods or
    /// properties that will not be default when the target returns.
    /// </summary>
    /// <param name="MemberNames"></param>
    public MemberNotDefaultAttribute(params string[] MemberNames) { this.MemberNames = MemberNames; }
}
#endregion
#endregion

