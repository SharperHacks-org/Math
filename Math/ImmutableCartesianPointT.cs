// Copyright and trademark notices at bottom of file.


using SharperHacks.CoreLibs.Constraints;
using SharperHacks.CoreLibs.Math.Interfaces;

using System.Collections.Immutable;
using System.Drawing;
using System.Numerics;

namespace SharperHacks.CoreLibs.Math;

/// <summary>
/// Implements IPoint{T} with minimal cartesian coordinate operators.
/// </summary>
/// <typeparam name="TNumeric"></typeparam>
public readonly record struct ImmutableCartesianPoint<TNumeric> :
    IPoint<TNumeric>
    where TNumeric : INumber<TNumeric>
{
    private readonly ImmutablePoint<TNumeric> _point;

    #region IPoint{TNumber}

    /// <inheritdoc cref="IPoint{TNumber}.Dimensions"/>
    public int Dimensions => _point.Dimensions;

    /// <inheritdoc cref="IPoint{TNumber}.Coordinates"/>
    public ImmutableList<TNumeric> Coordinates => _point.Coordinates;

    TNumeric this[int index] => Coordinates[index];

#endregion IPoint{T}

    #region Constructors

    /// <summary>
    /// constructor taking coordinate value array.
    /// </summary>
    /// <param name="coordinates"></param>
    public ImmutableCartesianPoint(params TNumeric[] coordinates)
    {
        Verify.IsNotNull(coordinates);
        Verify.IsGreaterThan(coordinates.Length, 0, "Coordinate values must not be empty.");

        _point = new ImmutablePoint<TNumeric>(coordinates);
    }

    /// <summary>
    /// Constructor for standard 2D geometry.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public ImmutableCartesianPoint(TNumeric x, TNumeric y) =>
        _point = new ImmutablePoint<TNumeric>(x, y);

    /// <summary>
    /// Constructor for standard 3D geometry.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public ImmutableCartesianPoint(TNumeric x, TNumeric y, TNumeric z) =>
        _point = new ImmutablePoint<TNumeric>(x, y, z);

    /// <summary>
    /// Constructor taking List{T}
    /// </summary>
    /// <param name="coordinates"></param>
    public ImmutableCartesianPoint(List<TNumeric> coordinates)
    {
        Verify.IsNotNull(coordinates);
        Verify.IsGreaterThan(coordinates.Count, 0, "Coordinate values must not be empty.");

        _point = new ImmutablePoint<TNumeric>(coordinates);
    }

    #endregion Constructors

    #region Object Overrides and special methods

    /// <inheritdoc/>
    public bool Equals(ImmutableCartesianPoint<TNumeric> other) =>
        _point.Equals(other._point);

    /// <inheritdoc/>
    public override int GetHashCode() => _point.GetHashCode();

    /// <inheritdoc cref="object.ToString"/>
    public override string ToString() => _point.ToString();

    /// <inheritdoc cref="ImmutablePoint{T}.ToString(bool)"/>
    public string ToString(bool diagnostic) => _point.ToString(diagnostic);

    #endregion Object Overrides and special methods

    #region Operators

    /// <summary>
    /// Add the right operands components to those of the left and
    /// return a new ImmutableCartesianPoint{T}.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="VerifyException">
    /// Throws VerifyException if either of the arguments is null, or
    /// the number of coordinate components do not match.
    /// </exception>
    public static ImmutableCartesianPoint<TNumeric> operator +
        (ImmutableCartesianPoint<TNumeric> left, 
        IPoint<TNumeric> right) => Sum(left, right);

    /// <summary>
    /// Subtract the right operands components from those of the left and
    /// return a new ImmutableCartesianPoint{T}.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="VerifyException">
    /// Throws VerifyException if either of the arguments is null, or
    /// the number of coordinate components do not match.
    /// </exception>
    public static ImmutableCartesianPoint<TNumeric> operator -
        (ImmutableCartesianPoint<TNumeric> left, 
        IPoint<TNumeric> right) => Diff(left, right);

    /// <summary>
    /// Multiply each of the components on the left, by the 
    /// scaleFactor on the right.
    /// </summary>
    /// <param name="point"></param>
    /// <param name="scaleFactor"></param>
    /// <returns></returns>
    /// <exception cref="VerifyException">
    /// Throws VerifyException if either of the arguments is null, or
    /// the <paramref name="scaleFactor"/> is null.
    /// </exception>
    public static ImmutableCartesianPoint<TNumeric> operator *
        (ImmutableCartesianPoint<TNumeric> point, TNumeric scaleFactor)
    {
        Verify.IsNotNull(point, nameof(point));
        Verify.IsNotNull(scaleFactor, nameof(scaleFactor));

        var results = new List<TNumeric>();

        foreach (var component in point.Coordinates)
        {
            checked
            {
                results.Add(component * scaleFactor);
            }
        }

        return new ImmutableCartesianPoint<TNumeric>(results);
    }

    /// <summary>
    /// Divide each of the components on the left, by the 
    /// scaleFactor on the right.
    /// </summary>
    /// <param name="point"></param>
    /// <param name="scaleFactor"></param>
    /// <returns></returns>
    /// <exception cref="VerifyException">
    /// Throws VerifyException if either of the arguments is null, or
    /// the <paramref name="scaleFactor"/> is null.
    /// </exception>
    public static ImmutableCartesianPoint<TNumeric> operator /
        (ImmutableCartesianPoint<TNumeric> point, TNumeric scaleFactor)
    {
        Verify.IsNotNull(point, nameof(point));
        Verify.IsNotNull(scaleFactor, nameof(scaleFactor))  ;
        Verify.AreNotEqual(TNumeric.Zero, scaleFactor);
        
        var results = new List<TNumeric>();

        foreach (var component in point.Coordinates)
        {
            checked
            {
                results.Add(component / scaleFactor);
            }
        }

        return new ImmutableCartesianPoint<TNumeric>(results);
    }

    private static ImmutableCartesianPoint<TNumeric> Sum
        (ImmutableCartesianPoint<TNumeric> left,
        IPoint<TNumeric> right)
    {
        Verify.IsNotNull(left);
        Verify.IsNotNull(right);
        Verify.AreEqual(left.Dimensions, right.Dimensions,
            "Left and right operands, must have same number of dimensions.");

        var results = new List<TNumeric>();

        for (var idx = 0; idx < left.Dimensions; idx++)
        {
            checked
            {
                results.Add(left[idx] + right[idx]);
            }
        }

        return new(results);
    }

    private static ImmutableCartesianPoint<TNumeric> Diff
        (ImmutableCartesianPoint<TNumeric> left,
        IPoint<TNumeric> right)
    {
        Verify.IsNotNull(left);
        Verify.IsNotNull(right);
        Verify.AreEqual(left.Dimensions, right.Dimensions,
            "Left and right operands, must have same number of dimensions.");

        var results = new List<TNumeric>();

        for (var idx = 0; idx < left.Dimensions; idx++)
        {
            checked
            {
                results.Add(left[idx] - right[idx]);
            }
        }

        return new(results);
    }
    
    #endregion Operators

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
