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
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.SOM;

namespace NeuronDotNet.Core.Initializers
{
    /// <summary>
    /// An <see cref="IInitializer"/> using Nguyen Widrow function.
    /// </summary>
    [Serializable]
    public class NguyenWidrowFunction : IInitializer
    {
        private readonly double outputRange;

        /// <summary>
        /// Gets the output range
        /// </summary>
        /// <value>
        /// The range of values, that network output takes
        /// </value>
        public double OutputRange
        {
            get { return outputRange; }
        }

        /// <summary>
        /// Creates a new NGuyen Widrow Initialization function
        /// </summary>
        public NguyenWidrowFunction()
            : this(1d)
        {
        }

        /// <summary>
        /// Creates a new NGuyen Widrow function using the given output range
        /// </summary>
        /// <param name="outputRange">
        /// the range of values, that output of a neuron can take (i.e. maximum minus minimum)
        /// </param>
        public NguyenWidrowFunction(double outputRange)
        {
            this.outputRange = outputRange;
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
        public NguyenWidrowFunction(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");
            this.outputRange = info.GetDouble("outputRange");
        }

        /// <summary>
        /// Populates the serialization info with the data needed to serialize the initializer
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
            info.AddValue("outputRange", outputRange);
        }

        /// <summary>
        /// Initializes bias values of activation neurons in the activation layer.
        /// </summary>
        /// <param name="activationLayer">
        /// The activation layer to initialize
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>activationLayer</c> is <c>null</c>
        /// </exception>
        public void Initialize(ActivationLayer activationLayer)
        {
            Helper.ValidateNotNull(activationLayer, "activationLayer");

            int hiddenNeuronCount = 0;
            foreach (IConnector targetConnector in activationLayer.TargetConnectors)
            {
                    hiddenNeuronCount += targetConnector.TargetLayer.NeuronCount;
            }

            double nGuyenWidrowFactor = NGuyenWidrowFactor(activationLayer.NeuronCount, hiddenNeuronCount);

            foreach (ActivationNeuron neuron in activationLayer.Neurons)
            {
                neuron.bias = Helper.GetRandom(-nGuyenWidrowFactor, nGuyenWidrowFactor);
            }
        }

        /// <summary>
        /// Initializes weights of all backpropagation synapses in the backpropagation connector.
        /// </summary>
        /// <param name="connector">
        /// The backpropagation connector to initialize.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>connector</c> is <c>null</c>
        /// </exception>
        public void Initialize(BackpropagationConnector connector)
        {
            Helper.ValidateNotNull(connector, "connector");
            
            double nGuyenWidrowFactor = NGuyenWidrowFactor(
                connector.SourceLayer.NeuronCount, connector.TargetLayer.NeuronCount);

            int synapsesPerNeuron = connector.SynapseCount / connector.TargetLayer.NeuronCount;

            foreach (INeuron neuron in connector.TargetLayer.Neurons)
            {
                int i = 0;
                double[] normalizedVector = Helper.GetRandomVector(synapsesPerNeuron, nGuyenWidrowFactor);
                foreach (BackpropagationSynapse synapse in connector.GetSourceSynapses(neuron))
                {
                    synapse.Weight = normalizedVector[i++];
                }
            }
        }

        /// <summary>
        /// Initializes weights of all spatial synapses in a Kohonen connector.
        /// </summary>
        /// <param name="connector">
        /// The Kohonen connector to initialize.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>connector</c> is <c>null</c>
        /// </exception>
        public void Initialize(KohonenConnector connector)
        {
            Helper.ValidateNotNull(connector, "connector");
            double nGuyenWidrowFactor = NGuyenWidrowFactor(
                connector.SourceLayer.NeuronCount, connector.TargetLayer.NeuronCount);

            int synapsesPerNeuron = connector.SynapseCount / connector.TargetLayer.NeuronCount;

            foreach (INeuron neuron in connector.TargetLayer.Neurons)
            {
                int i = 0;
                double[] normalizedVector = Helper.GetRandomVector(synapsesPerNeuron, nGuyenWidrowFactor);
                foreach (KohonenSynapse synapse in connector.GetSourceSynapses(neuron))
                {
                    synapse.Weight = normalizedVector[i++];
                }
            }
        }

        /// <summary>
        /// Private helper method to calculate Nguyen-Widrow factor
        /// </summary>
        /// <param name="inputNeuronCount">
        /// Number of input neurons
        /// </param>
        /// <param name="hiddenNeuronCount">
        /// Number of hidden neurons
        /// </param>
        /// <returns>
        /// The Nguyen-Widrow factor
        /// </returns>
        private double NGuyenWidrowFactor(int inputNeuronCount, int hiddenNeuronCount)
        {
            return 0.7d * Math.Pow(hiddenNeuronCount, (1d / inputNeuronCount)) / outputRange;
        }
    }
}