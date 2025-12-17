// Copyright and trademark notices at bottom of file.

using System.Collections.Immutable;
using System.Globalization;

using SharperHacks.CoreLibs.Constraints;
using SharperHacks.CoreLibs.Math.Interfaces;

namespace SharperHacks.CoreLibs.Math;

/// <summary>
/// An implementation of <see cref="IInterval{T}"/>.
/// </summary>
/// <typeparam name="T">The interval type where IComparable{T}.</typeparam>
/// <remarks>
/// In order to preserve the maximum genericity of the interval concept accross all
/// possible types, certain operations cannot be implemented here. For instance, when
/// a boundary is specified as exclusive, it's not possible to know the next closest 
/// value that would be included in the interval. We cannot simply apply the ++ or --
/// operators against any T, nor can we declare that a T must be incremantable and
/// decrementable.
/// </remarks>
public record Interval<T> : IInterval<T> where T : IComparable<T>
{
    /// <inheritdoc cref="IInterval{T}.LowerBound"/>
    public T LowerBound { get; init; }

    /// <inheritdoc cref="IInterval{T}.LowerBoundaryType"/>
    public IntervalBoundaryType LowerBoundaryType { get; init; }

    /// <inheritdoc cref="IInterval{T}.UpperBound"/>
    public T UpperBound { get; init; }

    /// <inheritdoc cref="IInterval{T}.UpperBoundaryType"/>
    public IntervalBoundaryType UpperBoundaryType { get; init; }

    /// <summary>
    /// Constructor specifying discrete boundary conditions.
    /// </summary>
    /// <param name="lowerBound"></param>
    /// <param name="lowerBoundaryType"></param>
    /// <param name="upperBound"></param>
    /// <param name="upperBoundaryType"></param>
    /// <exception cref="VerifyException"/>
    public Interval(
        T lowerBound, 
        IntervalBoundaryType lowerBoundaryType, 
        T upperBound, 
        IntervalBoundaryType upperBoundaryType)
    {
        Verify.IsNotNull(lowerBound, "Lower bound cannot be null.");
        Verify.IsNotNull(upperBound, "Upper bound cannot be null.");

        LowerBound = lowerBound;
        LowerBoundaryType = lowerBoundaryType;
        UpperBound = upperBound;
        UpperBoundaryType = upperBoundaryType;

        Verify.IsTrue(LowerBound.CompareTo(UpperBound) <= 0);
    }

    /// <summary>
    /// Construct from standard interval notation".
    /// </summary>
    /// <param name="intervalSpec">String conforming to standard interval notation.</param>
    /// <param name="validChars">
    /// Set of allowed value characters in <paramref name="intervalSpec"/> between the
    /// boundary characters and the comma. No character checks performed if null.
    /// </param>
    /// <example>Exclude boundary values: (a,b) == {a &lt; x &lt; b}</example>
    /// <example>Include boundary values: [a,b] == {a &lt;= x &lt;= b}</example>
    /// <exception cref="VerifyException"/>
    /// <remarks>
    /// </remarks>
    public Interval(string intervalSpec, ImmutableHashSet<char>? validChars = null)
    {
        Verify.IsNotNullOrEmpty(intervalSpec, "The interval spec cannot be null.");
        Verify.IsTrue(
                _lowerBoundaryInclusiveSpecifiers.Contains(intervalSpec[0]) ||
                _lowerBoundaryExclusiveSpecifiers.Contains(intervalSpec[0]),
                $"Missing lower boundary type specifier: expected one of '[', ']', '(', found {intervalSpec[0]}");
        Verify.IsTrue(
                _upperBoundaryInclusiveSpecifier.Contains(intervalSpec[^1]) ||
                _upperBoundaryExclusiveSpecifier.Contains(intervalSpec[^1]),
                $"Missing upper boundary type specifier: expected one of ']', '[', ')', found {intervalSpec[^1]}");

        LowerBoundaryType = _lowerBoundaryInclusiveSpecifiers.Contains(intervalSpec[0])
            ? IntervalBoundaryType.Inclusive
            : IntervalBoundaryType.Exclusive;
        UpperBoundaryType = _upperBoundaryInclusiveSpecifier.Contains(intervalSpec[^1])
            ? IntervalBoundaryType.Inclusive
            : IntervalBoundaryType.Exclusive;

        var idx = intervalSpec.IndexOf(',');

        Verify.IsTrue(idx > 0, $"Missing comma in {intervalSpec}.");
        Verify.IsTrue(idx > 1, $"Missing lower bound in {intervalSpec}");
        Verify.IsTrue(idx + 2 < intervalSpec.Length, $"Missing upper bound in {intervalSpec}");

        var leftStr = intervalSpec[1..idx]!.Trim();
        var rightStr = intervalSpec[(idx + 1)..^1]!.Trim();

        if (validChars is not null)
        {
            Verify.IsTrue(leftStr.IsLimitedToSetOf(validChars));
            Verify.IsTrue(rightStr.IsLimitedToSetOf(validChars));
        }

        LowerBound = (T)Convert.ChangeType(leftStr, typeof(T), CultureInfo.InvariantCulture);
        UpperBound = (T)Convert.ChangeType(rightStr, typeof(T), CultureInfo.InvariantCulture);

        Verify.IsTrue(LowerBound.CompareTo(UpperBound) <= 0);
    }

    private readonly char[] _lowerBoundaryInclusiveSpecifiers = new[] { '[' };
    private readonly char[] _lowerBoundaryExclusiveSpecifiers = new[]
    {
        '(',
        ']'
    };
    private readonly char[] _upperBoundaryInclusiveSpecifier = new[] { ']' };
    private readonly char[] _upperBoundaryExclusiveSpecifier = new[]
    {
        ')', 
        '['
    };
}

// Copied from StringExtensions to prevent dependency cycle.
internal static class IntervalStringExensions
{
    internal static bool IsLimitedToSetOf(this string str, ImmutableHashSet<char> set)
    {
        foreach (var ch in str)
        {
            if (!set.Contains(ch)) return false;
        }

        return true;
    }        
}

// Copyright Joseph W Donahue and Sharper Hacks LLC (US-WA)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// SharperHacks is a trademark of Sharper Hacks LLC (US-Wa), and may not be
// applied to distributions of derivative works, without the express written
// permission of a registered officer of Sharper Hacks LLC (US-WA).

