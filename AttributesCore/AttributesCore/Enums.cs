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

