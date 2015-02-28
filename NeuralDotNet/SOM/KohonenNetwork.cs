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

namespace NeuronDotNet.Core.SOM
{
    /// <summary>
    /// This class extends a <see cref="Network"/> and represents a Kohonen Self-Organizing Map.
    /// </summary>
    [Serializable]
    public class KohonenNetwork : Network
    {
        /// <summary>
        /// Gets the winner neuron of the network
        /// </summary>
        /// <value>
        /// Winner Neuron
        /// </value>
        public PositionNeuron Winner
        {
            get { return (outputLayer as KohonenLayer).Winner; }
        }

        /// <summary>
        /// Creates a new Kohonen SOM, with the specified input and output layers. (You are required
        /// to connect all layers using appropriate synapses, before using the constructor. Any changes
        /// made to the structure of the network here-after, may lead to complete malfunctioning of the
        /// network)
        /// </summary>
        /// <param name="inputLayer">
        /// The input layer
        /// </param>
        /// <param name="outputLayer">
        /// The output layer
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>inputLayer</c> or <c>outputLayer</c> is <c>null</c>
        /// </exception>
        public KohonenNetwork(ILayer inputLayer, KohonenLayer outputLayer)
            : base(inputLayer, outputLayer, TrainingMethod.Unsupervised)
        {
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
        public KohonenNetwork(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// A protected helper function used to train single learning sample
        /// </summary>
        /// <param name="trainingSample">
        /// Training sample to use
        /// </param>
        /// <param name="currentIteration">
        /// Current training epoch (Assumed to be positive and less than <c>trainingEpochs</c>)
        /// </param>
        /// <param name="trainingEpochs">
        /// Number of training epochs (Assumed to be positive)
        /// </param>
        protected override void LearnSample(TrainingSample trainingSample, int currentIteration, int trainingEpochs)
        {
            // No validation here
            inputLayer.SetInput(trainingSample.InputVector);
            foreach (ILayer layer in layers)
            {
                layer.Run();
                layer.Learn(currentIteration, trainingEpochs);
            }
        }
    }
}