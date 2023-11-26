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

using SharperHacks.CoreLibs.Math.Interfaces;

using System.Collections.Immutable;

namespace SharperHacks.CoreLibs.Math;

/// <summary>
/// Extends IInterval with GetFirstOf, GetLastOf and GetEnumerator for byte,
/// sbyte, short, ushort, int, uint, long and ulong.
/// </summary>
public static class IIntervalExtensions
{
    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>First effective value in the interval.</returns>
    public static byte GetFirstOf(this IInterval<byte> interval) => (byte)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    public static byte GetLastOf(this IInterval<byte> interval) => (byte)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - 1);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    public static IEnumerable<byte> GetEnumerator(this IInterval<byte> interval, byte stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>First effective value in the interval.</returns>
    [CLSCompliant(false)]
    public static sbyte GetFirstOf(this IInterval<sbyte> interval) => (sbyte)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    [CLSCompliant(false)]
    public static sbyte GetLastOf(this IInterval<sbyte> interval) => (sbyte)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - 1);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static IEnumerable<sbyte> GetEnumerator(this IInterval<sbyte> interval, sbyte stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }
#if false
    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static Rune GetFirstOf(this IRange<Rune> interval) => 
        interval.IsInclusiveLowerBound ? 
        interval.LowerBound : 
        (Rune)(interval.LowerBound.Value + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    public static Rune GetLastOf(this IRange<Rune> interval) => 
        interval.IsInclusiveUpperBound ? 
        interval.UpperBound : 
        (Rune)(interval.UpperBound.Value - 1);
    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    public static IEnumerator<Rune> GetEnumerator(this IRange<Rune> interval, int stepSize = 1)
    {
        Verify.IsNotNull(_surragateRange);
        for (var it = interval.GetFirstOf().Value; it <= interval.GetLastOf().Value; it += stepSize)
        {
            if (!_surragateRange.Contains(it)) yield return (Rune)it;
            else it = _surragateRange.UpperBound;
        }
    }
#endif
    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static short GetFirstOf(this IInterval<short> interval) => (short)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    public static short GetLastOf(this IInterval<short> interval) => (short)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - 1);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    public static IEnumerable<short> GetEnumerator(this IInterval<short> interval, short stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static ushort GetFirstOf(this IInterval<ushort> interval) => (ushort)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    [CLSCompliant(false)]
    public static ushort GetLastOf(this IInterval<ushort> interval) => (ushort)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - 1);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static IEnumerable<ushort> GetEnumerator(this IInterval<ushort> interval, ushort stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static int GetFirstOf(this IInterval<int> interval) => (int)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    public static int GetLastOf(this IInterval<int> interval) => (int)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - 1);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    public static IEnumerable<int> GetEnumerator(this IInterval<int> interval, int stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static uint GetFirstOf(this IInterval<uint> interval) => (uint)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    [CLSCompliant(false)]
    public static uint GetLastOf(this IInterval<uint> interval) => (uint)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - 1);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static IEnumerable<uint> GetEnumerator(this IInterval<uint> interval, uint stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static long GetFirstOf(this IInterval<long> interval) => (long)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    public static long GetLastOf(this IInterval<long> interval) => (long)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - 1);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    public static IEnumerable<long> GetEnumerator(this IInterval<long> interval, long stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static ulong GetFirstOf(this IInterval<ulong> interval) => (ulong)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + 1);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    [CLSCompliant(false)]
    public static ulong GetLastOf(this IInterval<ulong> interval) => (ulong)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - 1);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static IEnumerable<ulong> GetEnumerator(this IInterval<ulong> interval, ulong stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

#if false
    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static float GetFirstOf(this IRange<float> interval) => (float)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + float.Epsilon);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    public static float GetLastOf(this IRange<float> interval) => (float)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - float.Epsilon);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    public static IEnumerator<float> GetEnumerator(this IRange<float> interval, float stepSize = float.Epsilon)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static double GetFirstOf(this IRange<double> interval) => (double)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + float.Epsilon);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    public static double GetLastOf(this IRange<double> interval) => (double)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - double.Epsilon);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    public static IEnumerable<double> GetEnumerator(this IRange<double> interval, double stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }

    /// <summary>
    /// Get the first effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static decimal GetFirstOf(this IRange<decimal> interval) => (decimal)(interval.IsInclusiveLowerBound ? interval.LowerBound : interval.LowerBound + decimal.Epsilon);

    /// <summary>
    /// Get the last effective value in the specified interval.
    /// </summary>
    /// <param name="interval"></param>
    /// <returns>Last effective value in the interval.</returns>
    public static decimal GetLastOf(this IRange<decimal> interval) => (decimal)(interval.IsInclusiveUpperBound ? interval.UpperBound : interval.UpperBound - decimal.Epsilon);

    /// <summary>
    /// Get an enumerator for the interval having the specified step size.
    /// </summary>
    /// <param name="interval"></param>
    /// <param name="stepSize"></param>
    /// <returns></returns>
    public static IEnumerable<float> GetEnumerator(this IRange<float> interval, float stepSize = 1)
    {
        for (var it = interval.GetFirstOf(); it <= interval.GetLastOf(); it += stepSize)
        {
            yield return it;
        }
    }
#endif

    /// <summary>
    /// Convert IRange{byte} to ImmutableArray{byte}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static ImmutableArray<byte> ToImmutableArray(this IInterval<byte> interval)
    {
        var list = new List<byte>();

        foreach (var ch in interval.GetEnumerator())
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }

    /// <summary>
    /// Convert IRange{sbyte} to ImmutableArray{sbyte}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static ImmutableArray<sbyte> ToImmutableArray(this IInterval<sbyte> interval)
    {
        var list = new List<sbyte>();

        foreach (var ch in interval.GetEnumerator())
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }
#if false
    /// <summary>
    /// Convert IRange{Rune} to ImmutableArray{Rune}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static ImmutableArray<Rune> ToImmutableArray(this IRange<Rune> interval)
    {
        var list = new List<Rune>();

        foreach(var ch in interval)
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }
#endif
    /// <summary>
    /// Convert IRange{short} to ImmutableArray{short}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static ImmutableArray<short> ToImmutableArray(this IInterval<short> interval)
    {
        var list = new List<short>();

        foreach(var ch in interval.GetEnumerator())
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }

    /// <summary>
    /// Convert IRange{ushort} to ImmutableArray{ushort}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static ImmutableArray<ushort> ToImmutableArray(this IInterval<ushort> interval)
    {
        var list = new List<ushort>();

        foreach(var ch in interval.GetEnumerator())
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }

    /// <summary>
    /// Convert IRange{int} to ImmutableArray{int}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static ImmutableArray<int> ToImmutableArray(this IInterval<int> interval)
    {
        var list = new List<int>();

        foreach(var ch in interval.GetEnumerator())
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }

    /// <summary>
    /// Convert IRange{uint} to ImmutableArray{uint}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static ImmutableArray<uint> ToImmutableArray(this IInterval<uint> interval)
    {
        var list = new List<uint>();

        foreach(var ch in interval.GetEnumerator())
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }

    /// <summary>
    /// Convert IRange{long} to ImmutableArray{long}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    public static ImmutableArray<long> ToImmutableArray(this IInterval<long> interval)
    {
        var list = new List<long>();

        foreach(var ch in interval.GetEnumerator())
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }

    /// <summary>
    /// Convert IRange{ulong} to ImmutableArray{ulong}
    /// </summary>
    /// <param name="interval"></param>
    /// <returns></returns>
    [CLSCompliant(false)]
    public static ImmutableArray<ulong> ToImmutableArray(this IInterval<ulong> interval)
    {
        var list = new List<ulong>();

        foreach(var ch in interval.GetEnumerator())
        {
            list.Add(ch);
        }

        return list.ToImmutableArray();
    }
#if false
    private readonly static Range<int> _surragateRange = 
        new(0xD800, RangeBoundaryType.Inclusive, 0xDFFF, RangeBoundaryType.Inclusive);
#endif
}
