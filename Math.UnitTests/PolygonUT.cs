// Copyright and trademark notices at bottom of file.

using SharperHacks.CoreLibs.Math;
using SharperHacks.CoreLibs.Math.Interfaces;
using SharperHacks.CoreLibs.Math.UnitTests;

using System.Collections.Immutable;

namespace SharperHacks.CoreLibs.Math.UnitTests;

[TestClass]
public class PolygonUT
{
    private readonly ImmutablePoint<int>[] _box =
    {
        new(1,1),
        new(1,2),
        new(2,2),
        new(2,1)
    };

    [TestMethod]
    public void SmokeIt()
    {
        var polygon1 = new ImmutablePolygon<int>(
            new ImmutablePoint<int>(1, 1),
            new ImmutablePoint<int>(1, 2),
            new ImmutablePoint<int>(2, 2),
            new ImmutablePoint<int>(2, 1));

            Console.WriteLine(polygon1.ToString(true));
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
