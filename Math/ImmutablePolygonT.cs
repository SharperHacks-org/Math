// Copyright and trademark notices at bottom of file.

using SharperHacks.CoreLibs.Math.Interfaces;

using System.Collections.Immutable;
using System.Numerics;
using System.Text;

namespace SharperHacks.CoreLibs.Math;

/// <summary>
/// An implementation of IPolygon{T}
/// </summary>
/// <typeparam name="T">The numeric type used to specify locations</typeparam>
public class ImmutablePolygon<T> : IPolygon<T> where T : INumber<T>
{
    /// <inheritdoc cref="IPolygon{T}.VertexCount"/>
    public int VertexCount { get; }

    /// <inheritdoc cref="IPolygon{T}.Vertices"/>
    public ImmutableList<IPoint<T>> Vertices { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vertices"></param>
    public ImmutablePolygon(params IPoint<T>[] vertices)
    {
        VertexCount = vertices.Length;
        Vertices = ImmutableList.Create(vertices);
    }

    /// <inheritdoc/>
    public override string ToString() => ToString(false);

    /// <summary>
    /// Provides a more readable string, in either diagnostic or point coordinate form.
    /// </summary>
    /// <param name="diagnostic"></param>
    /// <returns>string</returns>
    public string ToString(bool diagnostic)
    {
        var sb = new StringBuilder();

        if (diagnostic)
        {
            sb.Append("ImmutablePolygon { VertexCount = ")
              .Append(VertexCount)
              .Append(", Vertices = ");
        }

        sb.Append('[');

        var downCounter = VertexCount;
        foreach(var item in Vertices)
        {
            sb.Append(item);
            downCounter--;
            if (downCounter > 0) sb.Append(',');
        }
        sb.Append(']');

        if (diagnostic) sb.Append(" }");

        return sb.ToString();
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
