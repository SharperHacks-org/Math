// Copyright and trademark notices at bottom of file.


using SharperHacks.CoreLibs.Constraints;
using SharperHacks.CoreLibs.Math.Interfaces;

using System.Collections.Immutable;
using System.Numerics;

namespace SharperHacks.CoreLibs.Math;

/// <summary>
/// Implements IPoint{T} with minimal cartesian coordinate operators.
/// </summary>
/// <typeparam name="T"></typeparam>
public readonly record struct ImmutableCartesianPoint<T>
    : IPoint<T> where T : INumber<T>
{
    private readonly ImmutablePoint<T> _point;

    #region IPoint{T}

    /// <inheritdoc cref="IPoint{T}.Dimensions"/>
    public int Dimensions => _point.Dimensions;

    /// <inheritdoc cref="IPoint{T}.Coordinates"/>
    public ImmutableList<T> Coordinates => _point.Coordinates;

    #endregion IPoint{T}

    #region Constructors

    /// <summary>
    /// constructor taking coordinate value array.
    /// </summary>
    /// <param name="coordinates"></param>
    public ImmutableCartesianPoint(params T[] coordinates)
    {
        Verify.IsNotNull(coordinates);
        Verify.IsGreaterThan(coordinates.Length, 0, "Coordinate values must not be empty.");

        _point = new ImmutablePoint<T>(coordinates);
    }

    /// <summary>
    /// Constructor for standard 2D geometry.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public ImmutableCartesianPoint(T x, T y) => 
        _point = new ImmutablePoint<T>(x, y);

    /// <summary>
    /// Constructor for standard 3D geometry.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public ImmutableCartesianPoint(T x, T y, T z) =>
        _point = new ImmutablePoint<T>(x, y,z);

    /// <summary>
    /// Constructor taking List{T}
    /// </summary>
    /// <param name="coordinates"></param>
    public ImmutableCartesianPoint(List<T> coordinates)
    {
        Verify.IsNotNull(coordinates);
        Verify.IsGreaterThan(coordinates.Count, 0, "Coordinate values must not be empty.");

        _point = new ImmutablePoint<T>(coordinates);
    }

    #endregion Constructors

    #region Object Overrides and special methods

    /// <inheritdoc/>
    public bool Equals(ImmutableCartesianPoint<T> other) =>
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
    /// Get component at the specified index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T this[int index] => Coordinates[index];

    /// <summary>
    /// Sum two IPoint{T}'s.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ImmutableCartesianPoint<T> 
        operator +(ImmutableCartesianPoint<T> left, IPoint<T> right) 
        => Sum(left, right);

    /// <summary>
    /// Subtract right operand from left.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ImmutableCartesianPoint<T>
        operator -(ImmutableCartesianPoint<T> left, IPoint<T> right)
        => Diff(left, right);

    /// <summary>
    /// Multiply the point by the scale factor.
    /// </summary>
    /// <param name="p"></param>
    /// <param name="scaleFactor"></param>
    /// <returns>
    /// New ImmutableCartesionPoint{T}.
    /// </returns>
    public static ImmutableCartesianPoint<T>
        operator *(ImmutableCartesianPoint<T> p, T scaleFactor)
    {
        var results = new List<T>();

        foreach (var component in p.Coordinates)
        {
            checked
            {
                results.Add(component * scaleFactor);
            }
        }

        return new ImmutableCartesianPoint<T>(results);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <param name="scaleFactor"></param>
    /// <returns></returns>
    public static ImmutableCartesianPoint<T> 
        operator /(ImmutableCartesianPoint<T> p, T scaleFactor)
    {
        var results = new List<T>();

        foreach(var component in p.Coordinates)
        {
            checked
            {
                results.Add(component / scaleFactor);
            }
        }

        return new ImmutableCartesianPoint<T>(results);
    }

    private static ImmutableCartesianPoint<T> Sum(ImmutableCartesianPoint<T> left, IPoint<T> right)
    {
        Verify.IsNotNull(left);
        Verify.IsNotNull(right);
        Verify.AreEqual(left.Dimensions, right.Dimensions,
            "Left and right operands, must have same number of dimensions.");

        var results = new List<T>();

        for (var idx = 0; idx < left.Dimensions; idx++)
        {
            checked
            {
                results.Add(left[idx] + right[idx]);
            }
        }

        return new(results);
    }

    private static ImmutableCartesianPoint<T> Diff(ImmutableCartesianPoint<T> left, IPoint<T> right)
    {
        Verify.IsNotNull(left);
        Verify.IsNotNull(right);
        Verify.AreEqual(left.Dimensions, right.Dimensions,
            "Left and right operands, must have same number of dimensions.");

        var results = new List<T>();

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
