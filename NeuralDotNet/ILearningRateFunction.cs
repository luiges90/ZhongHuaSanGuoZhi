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

namespace NeuronDotNet.Core
{
    /// <summary>
    /// Learning Rate Function interface. This interface defines the way in which learning rate
    /// changes from its initial value to its final value as the training progresses.
    /// </summary>
    public interface ILearningRateFunction : ISerializable
    {
        /// <summary>
        /// Gets the initial value of learning rate
        /// </summary>
        /// <value>
        /// Initial Learning Rate
        /// </value>
        double InitialLearningRate { get; }

        /// <summary>
        /// Gets the final value of learning rate
        /// </summary>
        /// <value>
        /// Final Learning Rate
        /// </value>
        double FinalLearningRate { get; }

        /// <summary>
        /// Gets effective learning rate for current training iteration. No validation is performed
        /// on the arguments.
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Total number of training epochs
        /// </param>
        /// <returns>
        /// The effective learning rate for current training iteration
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// If <c>trainingEpochs</c> is zero or negative
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is not less than <c>trainingEpochs</c>
        /// </exception>
        double GetLearningRate(int currentIteration, int trainingEpochs);
    }
}