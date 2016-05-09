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
using System.Runtime.Serialization;

namespace NeuronDotNet.Core.SOM.NeighborhoodFunctions
{
    /// <summary>
    /// Gaussian Neighborhood Function. It is a continuous bell shaped curve centered at winner neuron.
    /// </summary>
    [Serializable]
    public sealed class GaussianFunction : INeighborhoodFunction
    {
        /* 
         *  Gaussian function = a * Exp( - ((x-b)square) / 2 (c square))
         *
         *  The parameter 'a' is the height of the curve's peak, 'b' is the position of the center of
         *  the peak, and 'c' controls the width of the bell shape.
         *
         *  For a Gaussian Neighborhood function,
         *  a = unity (the neighborhood at the winner)
         *  b = winner position
         *  c = depends on training progress.
         *
         *  Initial value of c is obtained from the user (as learning radius)
         *  Note that, (x-b)square denotes the euclidean distance between winner neuron 'b' and neuron 'x' 
         *
         *                     _._
         *                    /   \
         *                   |     |
         *                  /       \
         *             ___-           -___
         *                      .
         *                Winner Position
         */

        private readonly double sigma = 0d;

        /// <summary>
        /// Gets the initial value of sigma
        /// </summary>
        /// <value>
        /// Initial value of sigma
        /// </value>
        public double Sigma
        {
            get { return sigma; }
        }

        /// <summary>
        /// Creates a new Gaussian Neighborhood Function
        /// </summary>
        /// <param name="learningRadius">
        /// Initial Learning Radius
        /// </param>
        public GaussianFunction(int learningRadius)
        {
            // Full Width at Half Maximum for a Gaussian curve 
            //        = sigma * Math.Sqrt(2 * ln(2)) = sigma * 2.35482

            // Full Width at Half Maximum (FWHM) is nothing but learning diameter
            // so, learning radius = 1.17741 * sigma

            this.sigma = learningRadius / 1.17741d;
        }

        /// <summary>
        /// Deserialization Constructor
        /// </summary>
        /// <param name="info">
        /// Serialization information to deserialize and obtain the data
        /// </param>
        /// <param name="context">
        /// Serialization context to use
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>info</c> is <c>null</c>
        /// </exception>
        public GaussianFunction(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");
            this.sigma = info.GetDouble("sigma");
        }

        /// <summary>
        /// Populates the serialization info with the data needed to serialize the neighborhood function
        /// </summary>
        /// <param name="info">
        /// The serialization info to populate the data with
        /// </param>
        /// <param name="context">
        /// The serialization context to use
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>info</c> is <c>null</c>
        /// </exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");
            info.AddValue("sigma", sigma);
        }

        /// <summary>
        /// Determines the neighborhood of every neuron in the given Kohonen layer with respect to
        /// winner neuron using Gaussian function
        /// </summary>
        /// <param name="layer">
        /// The Kohonen Layer containing neurons
        /// </param>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Total number of training epochs
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>layer</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <c>trainingEpochs</c> is zero or negative
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is not less than <c>trainingEpochs</c>
        /// </exception>
        public void EvaluateNeighborhood(KohonenLayer layer, int currentIteration, int trainingEpochs)
        {
            Helper.ValidateNotNull(layer, "layer");
            Helper.ValidatePositive(trainingEpochs, "trainingEpochs");
            Helper.ValidateWithinRange(currentIteration, 0, trainingEpochs - 1, "currentIteration");

            // Winner co-ordinates
            int winnerX = layer.Winner.Coordinate.X;
            int winnerY = layer.Winner.Coordinate.Y;

            // Layer width and height
            int layerWidth = layer.Size.Width;
            int layerHeight = layer.Size.Height;

            // Sigma value uniformly decreases to zero as training progresses
            double currentSigma = sigma - ((sigma * currentIteration) / trainingEpochs);

            // Optimization measure: Pre-calculated 2-Sigma-Square
            double twoSigmaSquare = 2 * currentSigma * currentSigma;
            
            // Evaluate and update neighborhood value of each neuron
            foreach (PositionNeuron neuron in layer.Neurons)
            {
                int dx = Math.Abs(winnerX - neuron.Coordinate.X);
                int dy = Math.Abs(winnerY - neuron.Coordinate.Y);

                if (layer.IsRowCircular)
                {
                    dx = Math.Min(dx, layerWidth - dx);
                }
                if (layer.IsColumnCircular)
                {
                    dy = Math.Min(dy, layerHeight - dy);
                }
                
                double dxSquare = dx * dx;
                double dySquare = dy * dy;
                if (layer.Topology == LatticeTopology.Hexagonal)
                {
                    if (dy % 2 == 1)
                    {
                        dxSquare += 0.25 + (((neuron.Coordinate.X > winnerX )== (winnerY % 2 ==0))? dx: -dx);
                    }
                    dySquare *= 0.75;
                }
                neuron.neighborhoodValue = Math.Exp(-(dxSquare + dySquare) / twoSigmaSquare);
            }
        }
    }
}