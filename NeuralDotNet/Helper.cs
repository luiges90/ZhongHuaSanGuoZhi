/***********************************************************************************************
 COPYRIGHT 2008 Vijeth D

 This file is part of NeuronDotNet.
 (Project Website : http://neurondotnet.freehostia.com)

 NeuronDotNet is a free software. You can redistribute it and/or modify it under the terms of
 the GNU General Public License as published by the Free Software Foundation, either version 3
 of the License, or (at your option) any later version.

 NeuronDotNet is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 See the GNU General Public License for more details.

 You should have received a copy of the GNU General Public License along with NeuronDotNet.
 If not, see <http://www.gnu.org/licenses/>.

***********************************************************************************************/

using System;

namespace NeuronDotNet.Core
{
    /// <summary>
    /// This static class contains all helper functions used in this project.
    /// </summary>
    internal static class Helper
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// Validates that a value is not <c>null</c>.
        /// </summary>
        /// <param name="value">
        /// The value to validate
        /// </param>
        /// <param name="name">
        /// The name of the argument
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>value</c> is <c>null</c>
        /// </exception>
        internal static void ValidateNotNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Validates that an enum instance is defined
        /// </summary>
        /// <param name="value">
        /// The value to validate
        /// </param>
        /// <param name="enumType">
        /// Type of the enum
        /// </param>
        /// <param name="name">
        /// The name of the enum object
        /// </param>
        /// <exception cref="ArgumentException">
        /// If value is not defined
        /// </exception>
        internal static void ValidateEnum(Type enumType, object value, string name)
        {
            if (!Enum.IsDefined(enumType, value))
            {
                throw new ArgumentException("The argument should be a valid enumerator", name);
            }
        }

        /// <summary>
        /// Validates that a numerical argument is not negative
        /// </summary>
        /// <param name="value">
        /// The numerical value to validate
        /// </param>
        /// <param name="name">
        /// The name of the argument
        /// </param>
        /// <exception cref="ArgumentException">
        /// If the value is negative
        /// </exception>
        internal static void ValidateNotNegative(double value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentException("The argument should be non-negative", name);
            }
        }

        /// <summary>
        /// Validates that a numerical argument is positive
        /// </summary>
        /// <param name="value">
        /// The numerical value to validate
        /// </param>
        /// <param name="name">
        /// The name of the argument
        /// </param>
        /// <exception cref="ArgumentException">
        /// If value is zero or negative
        /// </exception>
        internal static void ValidatePositive(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentException("The argument should be non-zero positive", name);
            }
        }

        /// <summary>
        /// Validates that a numerical argument is within the given range
        /// </summary>
        /// <param name="value">
        /// The value to validate
        /// </param>
        /// <param name="min">
        /// Minimum acceptable value
        /// </param>
        /// <param name="max">
        /// Maximum acceptable value
        /// </param>
        /// <param name="name">
        /// The name of the argument
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the <c>value</c> does not lie within the specified range
        /// </exception>
        internal static void ValidateWithinRange(double value, double min, double max, string name)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(name);
            }
        }

        /// <summary>
        /// Random Generator. Returns a random double between 0 and 1
        /// </summary>
        /// <returns>
        /// A random double between 0 and 1
        /// </returns>
        internal static double GetRandom()
        {
            return random.NextDouble();
        }

        /// <summary>
        /// Random Generator. Returns a random double between specified minimum and maximum values
        /// </summary>
        /// <returns>
        /// A random double between <c>min</c> and <c>max</c>
        /// </returns>
        internal static double GetRandom(double min, double max)
        {
            if (min > max)
            {
                return GetRandom(max, min);
            }
            return (min + (max - min) * random.NextDouble());
        }

        /// <summary>
        /// Generates an array of given size containing integers from 0 to 'size - 1' in random order
        /// </summary>
        /// <param name="size">
        /// Size of the array to generate.
        /// </param>
        /// <returns>
        /// The generated array.
        /// </returns>
        internal static int[] GetRandomOrder(int size)
        {
            int[] randomOrder = new int[size];

            //Initialize the array serially
            for (int i = 0; i < size; i++)
            {
                randomOrder[i] = i;
            }

            //Swap ith element with random elements for all position i.
            for (int i = 0; i < size; i++)
            {
                int randomPosition = random.Next(size);
                int temp = randomOrder[i];
                randomOrder[i] = randomOrder[randomPosition];
                randomOrder[randomPosition] = temp;
            }
            return randomOrder;
        }

        /// <summary>
        /// Normalizes a vector of doubles
        /// </summary>
        /// <param name="vector">
        /// The vector to normalize. This array is not modified by the function.
        /// </param>
        /// <returns>
        /// The normalized output
        /// </returns>
        internal static double[] Normalize(double[] vector)
        {
            return Normalize(vector, 1d);
        }

        /// <summary>
        /// Normalizes a vector of doubles
        /// </summary>
        /// <param name="vector">
        /// The vector to normalize. This array is not modified by the function.
        /// </param>
        /// <param name="magnitude">
        /// Magnitude
        /// </param>
        /// <returns>
        /// The normalized output
        /// </returns>
        internal static double[] Normalize(double[] vector, double magnitude)
        {
            // Calculate the root of sum of squares
            double factor = 0d;
            for (int i = 0; i < vector.Length; i++)
            {
                factor += vector[i] * vector[i];
            }

            // Divide each value with the root of sum of squares
            double[] normalizedVector = new double[vector.Length];
            if (factor != 0)
            {
                factor = Math.Sqrt(magnitude / factor);
                for (int i = 0; i < normalizedVector.Length; i++)
                {
                    normalizedVector[i] = vector[i] * factor;
                }
            }
            return normalizedVector;
        }

        /// <summary>
        /// Helper to obtain random normal values
        /// </summary>
        /// <param name="count">
        /// Number of values to get
        /// </param>
        /// <param name="magnitude">
        /// Magnitude of the vector
        /// </param>
        /// <returns>
        /// An array containing specified number of normalized random doubles
        /// </returns>
        internal static double[] GetRandomVector(int count, double magnitude)
        {
            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = Helper.GetRandom();
            }
            return Normalize(result, magnitude);
        }
    }
}