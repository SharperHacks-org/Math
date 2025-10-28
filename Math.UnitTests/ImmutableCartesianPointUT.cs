// Copyright and trademark notices at bottom of file.

using System.Diagnostics.CodeAnalysis;

namespace SharperHacks.CoreLibs.Math.UT;

[ExcludeFromCodeCoverage]
[TestClass]
public class ImmutableCartesianPointUT
{
    [TestMethod]
    public void SmokeIt()
    {
        var p1 = new ImmutableCartesianPoint<int>(1);
        var p2 = new ImmutableCartesianPoint<int>(1, 2);
        var p3 = new ImmutableCartesianPoint<int>(1, 2, 3);

        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p3);

        Console.WriteLine(p3.ToString(true));

        Assert.AreEqual(1, p1.Coordinates[0]);
        Assert.AreEqual(1, p2.Coordinates[0]);
        Assert.AreEqual(1, p3.Coordinates[0]);

        Assert.AreEqual(2, p2.Coordinates[1]);
    }

    [TestMethod]
    public void GetHashCodeTest()
    {
        var origin1 = new ImmutableCartesianPoint<double>(0.0, 0.0, 0.0);
        var origin2 = new ImmutableCartesianPoint<double>(0.0, 0.0, 0.0);
        var origin3 = new ImmutableCartesianPoint<float>(0, 0, 0);
        var p1 = origin1;
        var p2 = new ImmutableCartesianPoint<double>(0.0, 0.0, 0.0);

        Console.WriteLine($"origin1 == {origin1}");
        Console.WriteLine($"origin2 == {origin2}");
        Console.WriteLine($"origin3 == {origin3}");
        Console.WriteLine($"p1 == {p1}");
        Console.WriteLine($"p2 == {p2}");

        Assert.AreEqual(origin1.GetHashCode(), p1.GetHashCode());
        Assert.AreEqual(origin1.GetHashCode(), origin2.GetHashCode());
        Assert.AreEqual(origin1.GetHashCode(), origin3.GetHashCode());
        Assert.AreEqual(origin1.GetHashCode(), p1.GetHashCode());
        Assert.AreEqual(p1.GetHashCode(), p2.GetHashCode());
    }

    [TestMethod]
    public void MultiplicationAndDivisionTest()
    {
        var p1 = new ImmutableCartesianPoint<int>(2, 2, 2);
        var scaledUp = p1 * 3;
        var scaledDown = scaledUp / 3;
        var expectedUp = new ImmutableCartesianPoint<int>(6, 6, 6);
        var expectedDown = new ImmutableCartesianPoint<int>(2, 2, 2);

        Console.WriteLine(p1);
        Console.WriteLine(scaledUp);

        Assert.AreEqual(expectedUp, scaledUp);
        Assert.AreEqual(expectedDown, scaledDown);
    }

    [TestMethod]
    public void MinusOperatorTests()
    {
        var p1 = new ImmutableCartesianPoint<int>(0, 0, 0);
        var offset1 = new ImmutableCartesianPoint<int>(2, 2, 0);

        var p2 = p1 - offset1;

        Console.WriteLine(p1);
        Console.WriteLine(p2);

        Assert.AreEqual(3, p2.Dimensions);

        Assert.AreEqual(-2, p2.Coordinates[0]);
        Assert.AreEqual(-2, p2.Coordinates[1]);
        Assert.AreEqual(0, p2.Coordinates[2]);
    }

    [TestMethod]
    public void PlusOperatorTests()
    {
        var p1 = new ImmutableCartesianPoint<int>(0, 0, 0);
        var offset1 = new ImmutableCartesianPoint<int>(2, 2, 0);

        var p2 = p1 + offset1;

        Console.WriteLine(p1);
        Console.WriteLine(p2);

        Assert.AreEqual(3, p2.Dimensions);

        Assert.AreEqual(2, p2.Coordinates[0]);
        Assert.AreEqual(2, p2.Coordinates[1]);
        Assert.AreEqual(0, p2.Coordinates[2]);
    }

    [TestMethod]
    public void ToStringTest()
    {
        var p1 = new ImmutableCartesianPoint<byte>(0, 0, 0);

        Console.WriteLine(p1.ToString());
        Console.WriteLine(p1.ToString(true));
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
