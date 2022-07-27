using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rem.Core.Attributes;

/// <summary>
/// Internal throw helpers.
/// </summary>
internal static class Throw
{
    public static T IfArgNull<T>([MaybeNull] T argValue, string argName)
        => argValue is null ? throw new ArgumentNullException(argName) : argValue;
}
