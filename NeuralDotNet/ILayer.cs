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

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeuronDotNet.Core
{
    /// <summary>
    /// This interface represents a Layer in a neural network. A layer is a container for similar
    /// neurons. No two neurons within a layer can be connected to each other.
    /// </summary>
    public interface ILayer : ISerializable
    {
        /// <summary>
        /// Gets the neuron count
        /// </summary>
        /// <value>
        /// Number of neurons in the layer. It is always positive.
        /// </value>
        int NeuronCount { get; }

        /// <summary>
        /// Exposes an enumerator to iterate over all neurons in the layer
        /// </summary>
        /// <value>
        /// Neurons Enumerator. No neuron enumerated can be <c>null</c>.
        /// </value>
        IEnumerable<INeuron> Neurons { get; }

        /// <summary>
        /// Neuron Indexer
        /// </summary>
        /// <param name="index">
        /// Index
        /// </param>
        /// <returns>
        /// Neuron at the given index
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// If index is out of range
        /// </exception>
        INeuron this[int index] { get; }

        /// <summary>
        /// Gets the list of source connectors
        /// </summary>
        /// <value>
        /// The list of source connectors associated with this layer. It is neither <c>null</c>,
        /// nor contains <c>null</c> elements.
        /// </value>
        IList<IConnector> SourceConnectors { get; }

        /// <summary>
        /// Gets the list of target connectors
        /// </summary>
        /// <value>
        /// The list of target connectors associated with this layer. It is neither <c>null</c>,
        /// nor contains <c>null</c> elements.
        /// </value>
        IList<IConnector> TargetConnectors { get; }

        /// <summary>
        /// Gets or sets the Initializer used to initialize the layer
        /// </summary>
        /// <value>
        /// Initializer used to initialize the layer. If this value is <c>null</c>, initialization
        /// is NOT performed.
        /// </value>
        IInitializer Initializer { get; set; }

        /// <summary>
        /// Gets the initial value of learning rate
        /// </summary>
        /// <value>
        /// Initial value of learning rate.
        /// </value>
        double LearningRate { get; }

        /// <summary>
        /// Gets the learning rate function
        /// </summary>
        /// <value>
        /// Learning Rate Function used while training. It is never <c>null</c>
        /// </value>
        ILearningRateFunction LearningRateFunction { get; }

        /// <summary>
        /// Initializes all neurons and makes them ready to undergo training freshly.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Sets the learning rate to the given value. The layer will use this constant value
        /// as learning rate throughout the learning process
        /// </summary>
        /// <param name="learningRate">
        /// The learning rate
        /// </param>
        void SetLearningRate(double learningRate);

        /// <summary>
        /// Sets the initial and final values for learning rate. During the learning process, the
        /// effective learning rate uniformly changes from its initial value to final value
        /// </summary>
        /// <param name="initialLearningRate">
        /// Initial value of learning rate
        /// </param>
        /// <param name="finalLearningRate">
        /// Final value of learning rate
        /// </param>
        void SetLearningRate(double initialLearningRate, double finalLearningRate);

        /// <summary>
        /// Sets the learning rate function.
        /// </summary>
        /// <param name="learningRateFunction">
        /// Learning rate function to use.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// If <c>learningRateFunction</c> is <c>null</c>
        /// </exception>
        void SetLearningRate(ILearningRateFunction learningRateFunction);

        /// <summary>
        /// Sets neuron inputs to the values specified by the given array
        /// </summary>
        /// <param name="input">
        /// The input array
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// If <c>input</c> is <c>null</c>
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// If length of <c>input</c> array is different from number of neurons
        /// </exception>
        void SetInput(double[] input);

        /// <summary>
        /// Gets the neuron outputs as an array
        /// </summary>
        /// <returns>
        /// Array of double values representing neuron outputs
        /// </returns>
        double[] GetOutput();

        /// <summary>
        /// Runs all neurons in the layer.
        /// </summary>
        void Run();

        /// <summary>
        /// All neurons and their are source connectors are allowed to learn. This method assumes a
        /// learning environment where inputs, outputs and other parameters (if any) are appropriate.
        /// </summary>
        /// <param name="currentIteration">
        /// Current learning iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Total number of training epochs
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// If <c>trainingEpochs</c> is zero or negative
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is greater than <c>trainingEpochs</c>
        /// </exception>
        void Learn(int currentIteration, int trainingEpochs);
    }
}