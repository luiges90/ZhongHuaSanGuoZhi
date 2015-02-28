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
    /// An <see cref="IInitializer"/> using random function
    /// </summary>
    [Serializable]
    public class RandomFunction : IInitializer
    {
        private readonly double minLimit;
        private readonly double maxLimit;

        /// <summary>
        /// Gets the minimum random limit
        /// </summary>
        /// <value>
        /// Minimum limit to the random initial values
        /// </value>
        public double MinLimit
        {
            get { return minLimit; }
        }

        /// <summary>
        /// Gets the maximum random limit
        /// </summary>
        /// <value>
        /// Maximum limit to the random initial values
        /// </value>
        public double MaxLimit
        {
            get { return maxLimit; }
        }

        /// <summary>
        /// Creates a new random initialization function which uses random values from 0 to 1
        /// </summary>
        public RandomFunction()
            : this(0, 1)
        {
        }

        /// <summary>
        /// Creates a new random initialization function using random values between the specified
        /// limits.
        /// </summary>
        /// <param name="minLimit">
        /// The minimum limit
        /// </param>
        /// <param name="maxLimit">
        /// The maximum limit
        /// </param>
        public RandomFunction(double minLimit, double maxLimit)
        {
            this.minLimit = minLimit;
            this.maxLimit = maxLimit;
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
        public RandomFunction(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");

            this.minLimit = info.GetDouble("minLimit");
            this.maxLimit = info.GetDouble("maxLimit");
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
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");

            info.AddValue("minLimit", minLimit);
            info.AddValue("maxLimit", maxLimit);
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
            Helper.ValidateNotNull(activationLayer, "layer");
            foreach (ActivationNeuron neuron in activationLayer.Neurons)
            {
                neuron.bias = Helper.GetRandom(minLimit, maxLimit);
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
            foreach (BackpropagationSynapse synapse in connector.Synapses)
            {
                synapse.Weight = Helper.GetRandom(minLimit, maxLimit);
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
            foreach (KohonenSynapse synapse in connector.Synapses)
            {
                synapse.Weight = Helper.GetRandom(minLimit, maxLimit);
            }
        }
    }
}
