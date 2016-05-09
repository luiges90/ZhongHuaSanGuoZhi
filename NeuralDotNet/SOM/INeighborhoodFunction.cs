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

using System.Runtime.Serialization;

namespace NeuronDotNet.Core.SOM
{
    /// <summary>
    /// This interface represents a neighborhood function. A neighborhood function determines
    /// the neighborhood of every neuron with respect to winner neuron. This function depends
    /// on the the shape of the layer and also on the training progress.
    /// </summary>
    public interface INeighborhoodFunction : ISerializable
    {
        /// <summary>
        /// Determines the neighborhood of every neuron in the given Kohonen layer with respect
        /// to winner neuron.
        /// </summary>
        /// <param name="layer">
        /// The Kohonen Layer containing neurons
        /// </param>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Training Epochs
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// If <c>trainingEpochs</c> is zero or negative
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is not less than <c>trainingEpochs</c>
        /// </exception>
        void EvaluateNeighborhood(KohonenLayer layer, int currentIteration, int trainingEpochs);
    }
}
