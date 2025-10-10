// Copyright and trademark notices at bottom of file.

using System.Diagnostics.CodeAnalysis;

namespace SharperHacks.CoreLibs.Math.UnitTests;

[ExcludeFromCodeCoverage]
[TestClass]
public class StatsSmokeTests
{
    [TestMethod]
    public void CalculateDoubles()
    {
        var allOnes = new double[3] { 1, 1, 1 };
        var allZeros = new double[3] { 0, 0, 0 };
        var avgIsZero = new double[3] { -1, 0, 1 };

        var allOnesExpectedResult = new Stats.DecimalResults(1, allOnes.Length, 1, 1, 3, "allOnes", "int");
        var allZerosExpectedResult = new Stats.DecimalResults(0, allOnes.Length, 0, 0, 0, "allZeros", "int");
        var avgIsZeroExpectedResult = new Stats.DecimalResults(0, allOnes.Length, -1, 1, 0, "avgIsZero", "int");

        var allOnesCalculatedResult = Stats.GetStats(allOnes, "allOnes", "int");
        var allZerosCalculatedResult = Stats.GetStats(allZeros, "allZeros", "int");
        var avgIsZeroCalculatedResult = Stats.GetStats(avgIsZero, "avgIsZero", "int");

        Assert.AreEqual(allOnesExpectedResult, allOnesCalculatedResult);
        Assert.AreEqual(allZerosExpectedResult, allZerosCalculatedResult);
        Assert.AreEqual(avgIsZeroExpectedResult, avgIsZeroCalculatedResult);
    }

    [TestMethod]
    public void CalculateLongResults()
    {
        var allOnes = new long[3] { 1, 1, 1 };
        var allZeros = new long[3] { 0, 0, 0 };
        var avgIsZero = new long[3] { -1, 0, 1 };

        var allOnesCollectionName = "allOnes";

        var allOnesExpectedResult = new Stats.LongResults(1, allOnes.Length, 1, 1, 3, allOnesCollectionName);
        var allZerosExpectedResult = new Stats.LongResults(0, allOnes.Length, 0, 0, 0, "allZeros");
        var avgIsZeroExpectedResult = new Stats.LongResults(0, allOnes.Length, -1, 1, 0, "avgIsZero");

        var allOnesCalculatedResult = Stats.GetStats(allOnes, allOnesCollectionName);
        var allZerosCalculatedResult = Stats.GetStats(allZeros, "allZeros");
        var avgIsZeroCalculatedResult = Math.Stats.GetStats(avgIsZero, "avgIsZero");

        Assert.AreEqual(allOnesExpectedResult, allOnesCalculatedResult);
        Assert.AreEqual(allZerosExpectedResult, allZerosCalculatedResult);
        Assert.AreEqual(avgIsZeroExpectedResult, avgIsZeroCalculatedResult);

        Assert.AreEqual(allOnesCollectionName, allOnesExpectedResult.CollectionName);
        Assert.AreEqual(allOnesCollectionName, allOnesCalculatedResult.CollectionName);
        Assert.AreEqual("long", allOnesCalculatedResult.ValueTag);

        Console.WriteLine(allOnesCalculatedResult.ToString());
    }

    [TestMethod]
    public void CalculateDecimalResults()
    {
        var allOnes = new Decimal[3] { 1, 1, 1 };
        var allZeros = new Decimal[3] { 0, 0, 0 };
        var avgIsZero = new Decimal[3] { -1, 0, 1 };

        var allOnesCollectionName = "allOnes";

        var allOnesExpectedResult = new Stats.DecimalResults(1, allOnes.Length, 1, 1, 3, allOnesCollectionName);
        var allZerosExpectedResult = new Stats.DecimalResults(0, allOnes.Length, 0, 0, 0, "allZeros");
        var avgIsZeroExpectedResult = new Stats.DecimalResults(0, allOnes.Length, -1, 1, 0, "avgIsZero");

        var allOnesCalculatedResult = Stats.GetStats(allOnes, allOnesCollectionName);
        var allZerosCalculatedResult = Stats.GetStats(allZeros, "allZeros");
        var avgIsZeroCalculatedResult = Stats.GetStats(avgIsZero, "avgIsZero");

        Assert.AreEqual(allOnesExpectedResult, allOnesCalculatedResult);
        Assert.AreEqual(allZerosExpectedResult, allZerosCalculatedResult);
        Assert.AreEqual(avgIsZeroExpectedResult, avgIsZeroCalculatedResult);

        Assert.AreEqual(allOnesCollectionName, allOnesExpectedResult.CollectionName);
        Assert.AreEqual(allOnesCollectionName, allOnesCalculatedResult.CollectionName);
        Assert.AreEqual("decimal", allOnesCalculatedResult.ValueTag);

        Console.WriteLine(allOnesCalculatedResult.ToString());
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

