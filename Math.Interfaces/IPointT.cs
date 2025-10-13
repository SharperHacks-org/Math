// Copyright and trademark notices at bottom of file.

using System.Collections.Immutable;
using System.Numerics;

namespace SharperHacks.CoreLibs.Math.Interfaces;

/// <summary>
/// A generic point interface
/// </summary>
/// <typeparam name="T">The numeric type used to specify locations</typeparam>
public interface IPoint<T> where T : INumber<T>
{
    /// <summary>
    /// Get the dimensionality associated with this point.
    /// </summary>
    /// <remarks>
    /// Must be a non-zero positive value.
    /// </remarks>
    public int Dimensions { get; }

    /// <summary>
    /// Get a list of points on each axis.
    /// </summary>
    public ImmutableList<T> Coordinates { get; }
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
