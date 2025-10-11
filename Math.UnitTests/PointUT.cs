// Copyright and trademark notices at bottom of file.

using SharperHacks.CoreLibs.Math;

using System.Diagnostics.CodeAnalysis;

namespace SharperHacks.CoreLibs.Math.UnitTests;

[TestClass]
[ExcludeFromCodeCoverage]
public class PointUT
{
    [TestMethod]
    public void SmokeIt()
    {
        var p1 = new ImmutablePoint<int>(1);
        var p2 = new ImmutablePoint<int>(1, 2);
        var p3 = new ImmutablePoint<int>(1, 2, 3);

        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p3);

        Console.WriteLine(p3.ToString(true));

        Assert.AreEqual(1, p1.Coordinates[0]);
        Assert.AreEqual(1, p2.Coordinates[0]);
        Assert.AreEqual(1, p3.Coordinates[0]);

        Assert.AreEqual(2, p2.Coordinates[1]);
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

