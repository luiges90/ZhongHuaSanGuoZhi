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

namespace NeuronDotNet.Core.Backpropagation
{
    /// <summary>
    /// Activation Layer is a layer of activation neurons.
    /// </summary>
    [Serializable]
    public abstract class ActivationLayer : Layer<ActivationNeuron>
    {
        internal bool useFixedBiasValues = false;

        /// <summary>
        /// Gets or sets a boolean representing whether to use fixed neuron bias values
        /// </summary>
        /// <value>
        /// A boolean indicating whether bias values of activation neurons learn while training.
        /// </value>
        public bool UseFixedBiasValues
        {
            get { return useFixedBiasValues; }
            set { useFixedBiasValues = value; }
        }

        /// <summary>
        /// Constructs an instance of activation Layer
        /// </summary>
        /// <param name="neuronCount">
        /// The number of neurons in the layer
        /// </param>
        /// <exception cref="ArgumentException">
        /// If <c>neuronCount</c> is zero or negative
        /// </exception>
        protected ActivationLayer(int neuronCount)
            : base(neuronCount)
        {
            for (int i = 0; i < neuronCount; i++)
            {
                neurons[i] = new ActivationNeuron(this);
            }
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
        public ActivationLayer(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
            this.useFixedBiasValues = info.GetBoolean("useFixedBiasValues");

            double[] biasValues = (double[])info.GetValue("biasValues", typeof(double[]));
            for (int i = 0; i < biasValues.Length; i++)
            {
                neurons[i] = new ActivationNeuron(this);
                neurons[i].bias = biasValues[i];
            }
        }

        /// <summary>
        /// Populates the serialization info with the data needed to serialize the layer
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
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("useFixedBiasValues", useFixedBiasValues);

            double[] biasValues = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
            {
                biasValues[i] = neurons[i].bias;
            }

            info.AddValue("biasValues", biasValues, typeof(double[]));
        }

        /// <summary>
        /// Initializes all neurons and makes them ready to undergo training freshly.
        /// </summary>
        public override void Initialize()
        {
            if (initializer != null)
            {
                initializer.Initialize(this);
            }
        }

        /// <summary>
        /// Sets neuron errors as the difference between actual and expected outputs
        /// </summary>
        /// <param name="expectedOutput">
        /// Expected output vector
        /// </param>
        /// <returns>
        /// Mean squared error
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <c>expectedOutput</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If length of <c>expectedOutput</c> is different from the number of neurons
        /// </exception>
        public double SetErrors(double[] expectedOutput)
        {
            // Validate
            Helper.ValidateNotNull(expectedOutput, "expectedOutput");
            if (expectedOutput.Length != neurons.Length)
            {
                throw new ArgumentException("Length of ouput array should be same as neuron count", "expectedOutput");
            }

            // Set errors, evaluate mean squared error
            double meanSquaredError = 0d;
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].error = expectedOutput[i] - neurons[i].output;
                meanSquaredError += neurons[i].error * neurons[i].error;
            }
            return meanSquaredError;
        }

        /// <summary>
        /// Evaluate errors at all neurons in the layer
        /// </summary>
        public void EvaluateErrors()
        {
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].EvaluateError();
            }
        }

        /// <summary>
        /// Activation function used by all neurons in this layer
        /// </summary>
        /// <param name="input">
        /// Current input to the neuron
        /// </param>
        /// <param name="previousOutput">
        /// The previous output at the neuron
        /// </param>
        /// <returns>
        /// The activated value
        /// </returns>
        public abstract double Activate(double input, double previousOutput);

        /// <summary>
        /// Derivative function used by all neurons in this layer
        /// </summary>
        /// <param name="input">
        /// Current input to the neuron
        /// </param>
        /// <param name="output">
        /// Current output (activated) at the neuron
        /// </param>
        /// <returns>
        /// The result of derivative of activation function
        /// </returns>
        public abstract double Derivative(double input, double output);
    }
}
