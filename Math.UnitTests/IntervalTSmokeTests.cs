// Copyright and trademark notices at bottom of file.

using SharperHacks.CoreLibs.Constants;
using SharperHacks.CoreLibs.Math.Interfaces;

using System.Diagnostics.CodeAnalysis;

namespace SharperHacks.CoreLibs.Math.UnitTests;

[ExcludeFromCodeCoverage]
[TestClass]
public class IntervalTSmokeTests
{
    [TestMethod]
    public void IRangeTSmokeTests()
    {
        IInterval<int> emptyRange = new Interval<int>(0, IntervalBoundaryType.Exclusive, 1, IntervalBoundaryType.Exclusive);
        Assert.IsFalse(emptyRange.IsInclusiveLowerBound);
        Assert.IsFalse(emptyRange.IsInclusiveUpperBound);
        Assert.IsFalse(emptyRange.Contains(0));
        Assert.IsFalse(emptyRange.Contains(1));
        Assert.IsTrue(emptyRange.IsEmpty);

        IInterval<char> tinyRange = new Interval<char>('a', IntervalBoundaryType.Inclusive, 'b', IntervalBoundaryType.Exclusive);
        Assert.IsTrue(tinyRange.IsInclusiveLowerBound);
        Assert.IsFalse(tinyRange.IsInclusiveUpperBound);
        Assert.IsTrue(tinyRange.IsExclusiveUpperBound);
        Assert.IsTrue(tinyRange.Contains('a'));
        Assert.IsFalse(tinyRange.Contains('b'));
        Assert.IsFalse(tinyRange.IsEmpty);

        IInterval<int> exclusiveNotEmpty = new Interval<int>("(41, 43)", StandardSets.DecimalDigits);
        Assert.IsFalse(exclusiveNotEmpty.IsInclusiveLowerBound);
        Assert.IsFalse(exclusiveNotEmpty.IsInclusiveUpperBound);
        Assert.IsTrue(exclusiveNotEmpty.Contains(42));
        Assert.IsFalse(exclusiveNotEmpty.Contains(41));
        Assert.IsFalse(exclusiveNotEmpty.Contains(43));
        Assert.IsFalse(exclusiveNotEmpty.Contains(0));
        Assert.IsFalse(tinyRange.IsEmpty);

        IInterval<long> bigAndInclusive = new Interval<long>(
            long.MinValue, IntervalBoundaryType.Inclusive,
            long.MaxValue, IntervalBoundaryType.Inclusive);
        Assert.IsTrue(bigAndInclusive.Contains(long.MinValue));
        Assert.IsTrue(bigAndInclusive.Contains(long.MaxValue));
    }

    [TestMethod]
    public void IRangeByteExtensionSmokeTests()
    {
        IInterval<byte> inclusiveRange = new Interval<byte>(1, IntervalBoundaryType.Inclusive, 3, IntervalBoundaryType.Inclusive);
        Assert.AreEqual(1, inclusiveRange.GetFirstOf());
        Assert.AreEqual(3, inclusiveRange.GetLastOf());
        var itemCount = 0;
        foreach (var item in inclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(inclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        var immutableArray = inclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(1, immutableArray[0]);
        Assert.AreEqual(2, immutableArray[1]);
        Assert.AreEqual(3, immutableArray[2]);

        IInterval<byte> exclusiveRange = new Interval<byte>(1, IntervalBoundaryType.Exclusive, 5, IntervalBoundaryType.Exclusive);
        Assert.AreEqual(2, exclusiveRange.GetFirstOf());
        Assert.AreEqual(4, exclusiveRange.GetLastOf());
        itemCount = 0;
        foreach (var item in exclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(exclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        immutableArray = exclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(2, immutableArray[0]);
        Assert.AreEqual(3, immutableArray[1]);
        Assert.AreEqual(4, immutableArray[2]);
    }

    [TestMethod]
    public void IRangeSByteExtensionSmokeTests()
    {
        IInterval<sbyte> inclusiveRange = new Interval<sbyte>(1, IntervalBoundaryType.Inclusive, 3, IntervalBoundaryType.Inclusive);
        Assert.AreEqual(1, inclusiveRange.GetFirstOf());
        Assert.AreEqual(3, inclusiveRange.GetLastOf());
        var itemCount = 0;
        foreach (var item in inclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(inclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        var immutableArray = inclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(1, immutableArray[0]);
        Assert.AreEqual(2, immutableArray[1]);
        Assert.AreEqual(3, immutableArray[2]);

        IInterval<sbyte> exclusiveRange = new Interval<sbyte>(1, IntervalBoundaryType.Exclusive, 5, IntervalBoundaryType.Exclusive);
        Assert.AreEqual(2, exclusiveRange.GetFirstOf());
        Assert.AreEqual(4, exclusiveRange.GetLastOf());
        itemCount = 0;
        foreach (var item in exclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(exclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        immutableArray = exclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(2, immutableArray[0]);
        Assert.AreEqual(3, immutableArray[1]);
        Assert.AreEqual(4, immutableArray[2]);
    }

    [TestMethod]
    public void IRangeIntExtensionSmokeTests()
    {
        IInterval<int> inclusiveRange = new Interval<int>(1, IntervalBoundaryType.Inclusive, 3, IntervalBoundaryType.Inclusive);
        Assert.AreEqual(1, inclusiveRange.GetFirstOf());
        Assert.AreEqual(3, inclusiveRange.GetLastOf());
        var itemCount = 0;
        foreach (var item in inclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(inclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        var immutableArray = inclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(1, immutableArray[0]);
        Assert.AreEqual(2, immutableArray[1]);
        Assert.AreEqual(3, immutableArray[2]);

        IInterval<int> exclusiveRange = new Interval<int>(1, IntervalBoundaryType.Exclusive, 5, IntervalBoundaryType.Exclusive);
        Assert.AreEqual(2, exclusiveRange.GetFirstOf());
        Assert.AreEqual(4, exclusiveRange.GetLastOf());
        itemCount = 0;
        foreach (var item in exclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(exclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        immutableArray = exclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(2, immutableArray[0]);
        Assert.AreEqual(3, immutableArray[1]);
        Assert.AreEqual(4, immutableArray[2]);
    }

    [TestMethod]
    public void IRangeUintExtensionSmokeTests()
    {
        IInterval<uint> inclusiveRange = new Interval<uint>(1, IntervalBoundaryType.Inclusive, 3, IntervalBoundaryType.Inclusive);
        Assert.AreEqual(1u, inclusiveRange.GetFirstOf());
        Assert.AreEqual(3u, inclusiveRange.GetLastOf());
        var itemCount = 0;
        foreach (var item in inclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(inclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        var immutableArray = inclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(1u, immutableArray[0]);
        Assert.AreEqual(2u, immutableArray[1]);
        Assert.AreEqual(3u, immutableArray[2]);

        IInterval<uint> exclusiveRange = new Interval<uint>(1, IntervalBoundaryType.Exclusive, 5, IntervalBoundaryType.Exclusive);
        Assert.AreEqual(2u, exclusiveRange.GetFirstOf());
        Assert.AreEqual(4u, exclusiveRange.GetLastOf());
        itemCount = 0;
        foreach (var item in exclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(exclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        immutableArray = exclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(2u, immutableArray[0]);
        Assert.AreEqual(3u, immutableArray[1]);
        Assert.AreEqual(4u, immutableArray[2]);
    }

    [TestMethod]
    public void IRangeShortExtensionSmokeTests()
    {
        IInterval<short> inclusiveRange = new Interval<short>(1, IntervalBoundaryType.Inclusive, 3, IntervalBoundaryType.Inclusive);
        Assert.AreEqual(1, inclusiveRange.GetFirstOf());
        Assert.AreEqual(3, inclusiveRange.GetLastOf());
        var itemCount = 0;
        foreach (var item in inclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(inclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        var immutableArray = inclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(1, immutableArray[0]);
        Assert.AreEqual(2, immutableArray[1]);
        Assert.AreEqual(3, immutableArray[2]);

        IInterval<short> exclusiveRange = new Interval<short>(1, IntervalBoundaryType.Exclusive, 5, IntervalBoundaryType.Exclusive);
        Assert.AreEqual(2, exclusiveRange.GetFirstOf());
        Assert.AreEqual(4, exclusiveRange.GetLastOf());
        itemCount = 0;
        foreach (var item in exclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(exclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        immutableArray = exclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(2, immutableArray[0]);
        Assert.AreEqual(3, immutableArray[1]);
        Assert.AreEqual(4, immutableArray[2]);
    }

    [TestMethod]
    public void IRangeUshortExtensionSmokeTests()
    {
        IInterval<ushort> inclusiveRange = new Interval<ushort>(1, IntervalBoundaryType.Inclusive, 3, IntervalBoundaryType.Inclusive);
        Assert.AreEqual(1, inclusiveRange.GetFirstOf());
        Assert.AreEqual(3, inclusiveRange.GetLastOf());
        var itemCount = 0;
        foreach (var item in inclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(inclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        var immutableArray = inclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(1, immutableArray[0]);
        Assert.AreEqual(2, immutableArray[1]);
        Assert.AreEqual(3, immutableArray[2]);

        IInterval<ushort> exclusiveRange = new Interval<ushort>(1, IntervalBoundaryType.Exclusive, 5, IntervalBoundaryType.Exclusive);
        Assert.AreEqual(2, exclusiveRange.GetFirstOf());
        Assert.AreEqual(4, exclusiveRange.GetLastOf());
        itemCount = 0;
        foreach (var item in exclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(exclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        immutableArray = exclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(2, immutableArray[0]);
        Assert.AreEqual(3, immutableArray[1]);
        Assert.AreEqual(4, immutableArray[2]);
    }

    [TestMethod]
    public void IRangeLongExtensionSmokeTests()
    {
        IInterval<long> inclusiveRange = new Interval<long>(1, IntervalBoundaryType.Inclusive, 3, IntervalBoundaryType.Inclusive);
        Assert.AreEqual(1, inclusiveRange.GetFirstOf());
        Assert.AreEqual(3, inclusiveRange.GetLastOf());
        var itemCount = 0;
        foreach (var item in inclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(inclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        var immutableArray = inclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(1, immutableArray[0]);
        Assert.AreEqual(2, immutableArray[1]);
        Assert.AreEqual(3, immutableArray[2]);

        IInterval<long> exclusiveRange = new Interval<long>(1, IntervalBoundaryType.Exclusive, 5, IntervalBoundaryType.Exclusive);
        Assert.AreEqual(2, exclusiveRange.GetFirstOf());
        Assert.AreEqual(4, exclusiveRange.GetLastOf());
        itemCount = 0;
        foreach (var item in exclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(exclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        immutableArray = exclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(2, immutableArray[0]);
        Assert.AreEqual(3, immutableArray[1]);
        Assert.AreEqual(4, immutableArray[2]);
    }

    [TestMethod]
    public void IRangeUlongtExtensionSmokeTests()
    {
        IInterval<ulong> inclusiveRange = new Interval<ulong>(1, IntervalBoundaryType.Inclusive, 3, IntervalBoundaryType.Inclusive);
        Assert.AreEqual(1ul, inclusiveRange.GetFirstOf());
        Assert.AreEqual(3ul, inclusiveRange.GetLastOf());
        var itemCount = 0;
        foreach (var item in inclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(inclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        var immutableArray = inclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(1ul, immutableArray[0]);
        Assert.AreEqual(2ul, immutableArray[1]);
        Assert.AreEqual(3ul, immutableArray[2]);

        IInterval<ulong> exclusiveRange = new Interval<ulong>(1, IntervalBoundaryType.Exclusive, 5, IntervalBoundaryType.Exclusive);
        Assert.AreEqual(2ul, exclusiveRange.GetFirstOf());
        Assert.AreEqual(4ul, exclusiveRange.GetLastOf());
        itemCount = 0;
        foreach (var item in exclusiveRange.GetEnumerator())
        {
            itemCount++;
            Assert.IsTrue(exclusiveRange.Contains(item));
        }
        Assert.AreEqual(3, itemCount);

        immutableArray = exclusiveRange.ToImmutableArray();
        Assert.AreEqual(3, immutableArray.Length);
        Assert.AreEqual(2ul, immutableArray[0]);
        Assert.AreEqual(3ul, immutableArray[1]);
        Assert.AreEqual(4ul, immutableArray[2]);
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

