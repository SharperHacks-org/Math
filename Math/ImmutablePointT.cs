// Copyright and trademark notices at bottom of file.

using SharperHacks.CoreLibs.Constraints;
using SharperHacks.CoreLibs.Math.Interfaces;

using System.Collections.Immutable;
using System.Numerics;
using System.Text;

namespace SharperHacks.CoreLibsMath;

/// <summary>
/// An immutable implementation of IPoint.
/// </summary>
public readonly record struct ImmutablePoint<T> : IPoint<T> where T: INumber<T>
{
    /// <inheritdoc cref="IPoint{T}.Dimensions"/>
    public int Dimensions { get; init; }

    /// <inheritdoc cref="IPoint{T}.Coordinates"/>
    public ImmutableList<T> Coordinates { get; init; }

    /// <summary>
    /// constructor taking coordinate value array.
    /// </summary>
    /// <param name="coordinates"></param>
    public ImmutablePoint(params T[] coordinates)
    {
        Verify.IsNotNull(coordinates);
        Verify.IsGreaterThan(coordinates.Length, 0, "Coordinate values must not be empty.");

        Dimensions = coordinates.Length;
        Coordinates = ImmutableList.Create(coordinates);
    }

    /// <summary>
    /// Constructor for standard 2D geometry.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public ImmutablePoint(T x, T y)
    {
        Dimensions = 2;
        Coordinates = ImmutableList.Create(x, y);
    }

    /// <summary>
    /// Constructor for standard 3D geometry.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public ImmutablePoint(T x, T y, T z)
    {
        Dimensions = 3;
        Coordinates = ImmutableList.Create(x, y, z);
    }

    /// <inheritdoc/>
    public override string ToString() => ToString(false);

    /// <summary>
    /// Provides a more readable string, in either diagnostic or point coordinate form.
    /// </summary>
    /// <param name="diagnostic"></param>
    /// <returns></returns>
    public string ToString(bool diagnostic)
    {
        var sb = new StringBuilder();

        if (diagnostic)
        {
            sb.Append("ImmutablePoint { Dimensions = ")
              .Append(Dimensions)
              .Append(", Coordinates = ");
        }

        sb.Append('(');

        var downCounter = Dimensions;
        foreach (var item in Coordinates)
        {
            sb.Append(item);
            downCounter--;
            if (downCounter != 0) sb.Append(',');
        }

        sb.Append(')');

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
