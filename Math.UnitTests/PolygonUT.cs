// Copyright and trademark notices at bottom of file.

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

    ImmutablePolygon<int> _polygon1 = new(
        new ImmutablePoint<int>(1, 1),
        new ImmutablePoint<int>(1, 2),
        new ImmutablePoint<int>(2, 2),
        new ImmutablePoint<int>(2, 1));

    [TestMethod]
    public void SmokeIt()
    {
        Assert.AreEqual(4, _polygon1.VertexCount);
    }

    [TestMethod]
    public void TestToString()
    {
        const string expectedEnabled = "ImmutablePolygon { VertexCount = 4, Vertices = [(1,1),(1,2),(2,2),(2,1)] }";
        const string expectedDisabled = "[(1,1),(1,2),(2,2),(2,1)]";
        const string expectedNormal = "[(1,1),(1,2),(2,2),(2,1)]";

        string diagnosticEnabled = _polygon1.ToString(true);
        string diagnosticDisabled = _polygon1.ToString(false) ;
        string normalForm = _polygon1.ToString();

        Console.WriteLine($"ToString(true) == {diagnosticEnabled}");
        Console.WriteLine($"ToString(false) == {diagnosticDisabled}");
        Console.WriteLine($"ToString() == {normalForm}");

        Assert.AreEqual(expectedEnabled, diagnosticEnabled );
        Assert.AreEqual(expectedDisabled, diagnosticDisabled );
        Assert.AreEqual(expectedNormal, normalForm );
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
