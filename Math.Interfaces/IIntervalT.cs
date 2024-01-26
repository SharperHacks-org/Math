// Copyright and trademark notices at bottom of file.

namespace SharperHacks.CoreLibs.Math.Interfaces;

/// <summary>
/// Represents a interval in terms of upper and lower bounds and whether
/// they are inclusive or exclusive.
/// </summary>
/// <typeparam name="T">
/// Any type that implements IComparable{T}.
/// </typeparam>
/// <remarks>
/// <para>
/// A interval in this context is not a fixed set of values. It is very 
/// important to capture the full semantics of interval specifications
/// and behaviors in implementations of this interface.
/// </para>
/// </remarks>
public interface IInterval<T> where T : IComparable<T>
{
    /// <summary>
    /// Get the lower boundary of the interval.
    /// </summary>
    T LowerBound { get; }

    /// <summary>
    /// Get whether lower boundary is inclusive or exclusive.
    /// </summary>
    IntervalBoundaryType LowerBoundaryType { get; }

    /// <summary>
    /// Get whether the lower boundary is inclusive.
    /// </summary>
    bool IsInclusiveLowerBound => LowerBoundaryType == IntervalBoundaryType.Inclusive;


    /// <summary>
    /// Get wether the lower boundary is exclusive.
    /// </summary>
    bool IsExclusiveLowerBound => LowerBoundaryType == IntervalBoundaryType.Exclusive;

    /// <summary>
    /// Get the upper boundary of the interval.
    /// </summary>
    T UpperBound { get; }

    /// <summary>
    /// Get wehther the upper boundary is inclusive or exlusive.
    /// </summary>
    IntervalBoundaryType UpperBoundaryType { get; }

    /// <summary>
    /// Get whether the upper boundary is inclusive.
    /// </summary>
    bool IsInclusiveUpperBound => UpperBoundaryType == IntervalBoundaryType.Inclusive;

    /// <summary>
    /// Get whether the upper boundary is exclusive.
    /// </summary>
    bool IsExclusiveUpperBound => UpperBoundaryType == IntervalBoundaryType.Exclusive;

    /// <summary>
    /// Get whether the defined interval is empty.
    /// </summary>
    /// <remarks>
    /// Default implementation not adquate for all types of T.
    /// </remarks>
    bool IsEmpty => (LowerBound is null && UpperBound is null)
            || ((LowerBound is null || IsExclusiveLowerBound)
                && (UpperBound is null || IsExclusiveUpperBound))
            || ((IsExclusiveLowerBound || IsExclusiveUpperBound)
                && Equals(LowerBound, UpperBound));

    /// <summary>
    /// Determine whether value falls within specified interval.
    /// </summary>
    /// <param name="value">The value to test against the interval.</param>
    /// <returns>True if value is within the specified interval.</returns>
    public bool Contains(T value)
    {
        // 
        var lowerBoundComparison = value.CompareTo(LowerBound);
        var upperBoundComparison = value.CompareTo(UpperBound);

        var aboveLowerBound = IsInclusiveLowerBound ? lowerBoundComparison >= 0 : lowerBoundComparison >= 1;
        var belowUpperBound = IsInclusiveUpperBound ? upperBoundComparison <= 0 : upperBoundComparison <= -1;

        return aboveLowerBound && belowUpperBound;
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

