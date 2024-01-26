// Copyright and trademark notices at bottom of file.

using SharperHacks.CoreLibs.Constraints;

namespace SharperHacks.CoreLibs.Math;

/// <summary>
/// Statistics algorithms.
/// </summary>
public static class Stats
{
    /// <summary>
    /// Base clase for the various Stats result types.
    /// </summary>
    public abstract record ResultsBase
    {
        ///
        public string CollectionName { get; init; } = string.Empty;

        ///
        public string ValueTag { get; init; } = string.Empty;
    }

    /// <summary>
    /// Record type returned by Stats methods.
    /// </summary>
    public record LongResults : ResultsBase
    {
        ///
        public long Avg { get; init; }

        ///
        public long Count { get; init; }

        ///
        public long Min { get; init; }

        ///
        public long Max { get; init; }

        ///
        public decimal Sum { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="avg"></param>
        /// <param name="count"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="sum"></param>
        /// <param name="collectionName"></param>
        /// <param name="valueTag"></param>
        public LongResults(
            long avg, 
            long count, 
            long min, 
            long max, 
            decimal sum,
            string? collectionName = null,
            string? valueTag = null)
        {
            CollectionName = collectionName ?? string.Empty;
            ValueTag = valueTag ?? "long";
            Avg = avg;
            Count = count;
            Min = min;
            Max = max;
            Sum = sum;
        }
    }

    ///
    public record DecimalResults : ResultsBase

    {
        ///
        public decimal Avg { get; init; }

        ///
        public long Count { get; init; }

        ///
        public decimal Min { get; init; }

        ///
        public decimal Max { get; init; }

        ///
        public decimal Sum { get; init; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="avg"></param>
        /// <param name="count"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="sum"></param>
        /// <param name="collectionName"></param>
        /// <param name="valueTag"></param>
        public DecimalResults(
            decimal avg,
            long count,
            decimal min,
            decimal max,
            decimal sum,
            string? collectionName = null,
            string? valueTag = null)
        {
            CollectionName = collectionName ?? string.Empty;
            ValueTag = valueTag ?? "decimal";

            Avg = avg;
            Count = count;
            Min = min;
            Max = max;
            Sum = sum;
        }
    }

    /// <summary>
    /// Calculate average, sum, min, max and count.
    /// </summary>
    /// <param name="container"></param>
    /// <param name="collectionName"></param>
    /// <param name="valueTag"></param>
    /// <returns></returns>
    public static LongResults GetStats(
        IEnumerable<long> container,
        string? collectionName = null,
        string? valueTag = null)
    {
        Verify.IsTrue(container.Any(), "container has zero elements");

        decimal sum = 0;
        decimal count = 0;

        long min = long.MaxValue;
        long max = long.MinValue;

        foreach (var value in container)
        {
            sum += value;
            count++;

            if (value < min) min = value;
            if (value > max) max = value;
        }

        return new LongResults((long)(sum/count), (long)count, min, max, sum, collectionName, valueTag);
    }

    /// <summary>
    /// Calculate average, sum, min, max and count.
    /// </summary>
    /// <param name="container"></param>
    /// <param name="collectionName"></param>
    /// <param name="valueTag"></param>
    /// <returns></returns>
    public static DecimalResults GetStats(
        IEnumerable<double> container,
        string? collectionName = null,
        string? valueTag = null)
    {
        Verify.IsTrue(container.Any(), "container has zero elements");

        decimal sum = 0;
        decimal count = 0;

        decimal min = long.MaxValue;
        decimal max = long.MinValue;

        foreach (var item in container)
        {
            var value = (decimal)item;
            sum += value;
            count++;

            if (value < min) min = value;
            if (value > max) max = value;
        }

        return new DecimalResults(sum / count, (long)count, min, max, sum, collectionName, valueTag);
    }

    /// <summary>
    /// Calculate average, sum, min, max and count.
    /// </summary>
    /// <param name="container"></param>
    /// <param name="collectionName"></param>
    /// <param name="valueTag"></param>
    /// <returns></returns>
    public static DecimalResults GetStats(
        IEnumerable<decimal> container,
        string? collectionName = null,
        string? valueTag = null)
    {
        Verify.IsTrue(container.Any(), "container has zero elements");

        decimal sum = 0;
        decimal count = 0;

        decimal min = long.MaxValue;
        decimal max = long.MinValue;

        foreach (var item in container)
        {
            var value = (decimal)item;
            sum += value;
            count++;

            if (value < min) min = value;
            if (value > max) max = value;
        }

        return new DecimalResults(sum / count, (long)count, min, max, sum, collectionName, valueTag);
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

