using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.Core.Attributes;

#region Struct Defaultability
/// <summary>
/// Indicates that a property, field, parameter, return value or type parameter of a defaultable
/// <see langword="struct"/> type should accept the default value of its type.
/// </summary>
/// <remarks>
/// This can be considered the struct equivalent of including the nullability (<c>?</c>) operator on a reference type
/// declaration in a nullable context.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Property
        | AttributeTargets.ReturnValue | AttributeTargets.Parameter
        | AttributeTargets.GenericParameter,
    AllowMultiple = false,
    Inherited = false)]
public sealed class DefaultableStructAttribute : Attribute { }

/// <summary>
/// Indicates that a property, field, parameter, return value or type parameter of a defaultable
/// <see langword="struct"/> type should not accept the default value of its type.
/// </summary>
/// <remarks>
/// This can be considered the struct equivalent of excluding the nullability (<c>?</c>) operator on a reference type
/// declaration in a nullable context.
/// </remarks>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Property
        | AttributeTargets.ReturnValue | AttributeTargets.Parameter
        | AttributeTargets.GenericParameter,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NonDefaultableStructAttribute : Attribute { }

/// <summary>
/// Indicates that a generic <see langword="struct"/> type definition should be considered defaultable if and only if
/// the listed type parameters are non-defaultable.
/// </summary>
[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class DefaultableIfTypeParamsNonDefaultableAttribute : Attribute
{
    /// <summary>
    /// Gets the list of type parameter names that indicate the defaultability of the declared
    /// <see langword="struct"/> type.
    /// </summary>
    public string[] ParameterNames { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="DefaultableIfTypeParamsNonDefaultableAttribute"/> class with
    /// the name of the type parameter that indicate the defaultability of the declared <see langword="struct"/> type.
    /// </summary>
    /// <param name="ParameterName"></param>
    public DefaultableIfTypeParamsNonDefaultableAttribute(string ParameterName) : this(new[] { ParameterName })
    { }

    /// <summary>
    /// Constructs a new instance of the <see cref="DefaultableIfTypeParamsNonDefaultableAttribute"/> class with
    /// the names of the type parameters that indicate the defaultability of the declared
    /// <see langword="struct"/> type.
    /// </summary>
    /// <param name="ParameterNames"></param>
    public DefaultableIfTypeParamsNonDefaultableAttribute(params string[] ParameterNames)
    {
        this.ParameterNames = ParameterNames;
    }
}
#endregion

#region General-Purpose
#region Nullable Attribute Analogs
/// <summary>
/// Specifies that a default value is allowed as an input even if the corresponding type or struct defaultability
/// attributes disallow it.
/// </summary>
/// <seealso cref="DefaultableStructAttribute"/>
/// <seealso cref="NonDefaultableStructAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property,
    AllowMultiple = false,
    Inherited = false)]
public sealed class AllowDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that a default value is disallowed as an input even if the corresponding type or struct defaultability
/// attributes allow it.
/// </summary>
/// <seealso cref="DefaultableStructAttribute"/>
/// <seealso cref="NonDefaultableStructAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property,
    AllowMultiple = false, Inherited = false)]
public sealed class DisallowDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that a default value is allowed as an output even if the corresponding type or struct defaultability
/// attributes disallow it.
/// </summary>
/// <seealso cref="DefaultableStructAttribute"/>
/// <seealso cref="NonDefaultableStructAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class MaybeDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that an output is not the default even if the corresponding type or struct defaultability attributes
/// allow it.
/// Specifies that an input argument was not default when the call returns.
/// </summary>
/// <seealso cref="DefaultableStructAttribute"/>
/// <seealso cref="NonDefaultableStructAttribute"/>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class NotDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that when a method returns <see cref="ReturnValue"/>, the parameter may be default even if the
/// corresponding type or struct defaultability attributes disallow it.
/// </summary>
/// <seealso cref="DefaultableStructAttribute"/>
/// <seealso cref="NonDefaultableStructAttribute"/>
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
/// corresponding type or struct defaultability attributes allow it.
/// </summary>
/// <seealso cref="DefaultableStructAttribute"/>
/// <seealso cref="NonDefaultableStructAttribute"/>
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
/// Specifies that the output will be non-default if the named parameter is a named enum value.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = true,
    Inherited = false)]
public sealed class NotDefaultIfNamedAttribute : Attribute
{
    /// <summary>
    /// Gets the name of the parameter whose nameability describes the defaultability of the target.
    /// </summary>
    public string ParameterName { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NotDefaultIfNamedAttribute"/> class with the name of the
    /// parameter whose nameability describes the defaultability of the target.
    /// </summary>
    /// <param name="ParameterName"></param>
    public NotDefaultIfNamedAttribute(string ParameterName) { this.ParameterName = ParameterName; }
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
    /// <param name="MemberName"></param>
    public MemberNotDefaultAttribute(string MemberName) { this.MemberNames = new[] { MemberName }; }

    /// <summary>
    /// Constructs a new instance of the <see cref="MemberNotDefaultAttribute"/> class with the names of methods or
    /// properties that will not be default when the target returns.
    /// </summary>
    /// <param name="MemberNames"></param>
    public MemberNotDefaultAttribute(params string[] MemberNames) { this.MemberNames = MemberNames; }
}
#endregion

#region Type Parameters
/// <summary>
/// Indicates that an output is not the default value of its type if the listed type parameters are non-defaultable,
/// even if the corresponding type or struct defaultability attributes allow it.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue | AttributeTargets.Parameter,
    AllowMultiple = false, Inherited = false)]
public sealed class NotDefaultIfTypeParamsNonDefaultableAttribute : Attribute
{
    /// <summary>
    /// Gets the list of type parameter names that indicate the defaultability of the target.
    /// </summary>
    public string[] ParameterNames { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NotDefaultIfTypeParamsNonDefaultableAttribute"/> with the name of
    /// the type parameter that indicates the defaultability of the target.
    /// </summary>
    /// <param name="ParameterName"></param>
    public NotDefaultIfTypeParamsNonDefaultableAttribute(string ParameterName) : this(new[] { ParameterName }) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="NotDefaultIfTypeParamsNonDefaultableAttribute"/> with the names of
    /// the type parameters that indicate the defaultability of the target.
    /// </summary>
    /// <param name="ParameterNames"></param>
    public NotDefaultIfTypeParamsNonDefaultableAttribute(params string[] ParameterNames)
    {
        this.ParameterNames = ParameterNames;
    }
}
#endregion

#region Default Instance Members
/// <summary>
/// Specifies that an output of a <see langword="struct"/> instance property or method may be the default value of
/// its type if the instance is the default.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class MaybeDefaultIfInstanceDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that a <see langword="struct"/> instance property or method does not return if the instance is
/// the default.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class DoesNotReturnIfInstanceDefaultAttribute : Attribute { }
#endregion
#endregion

