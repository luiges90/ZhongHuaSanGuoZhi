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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeuronDotNet.Core.Backpropagation
{
    /// <summary>
    /// A Backpropagation Connector is an <see cref="IConnector"/> which consists of a collection of
    /// backpropagation synapses connecting two activation layers.
    /// </summary>
    [Serializable]
    public class BackpropagationConnector
        : Connector<ActivationLayer, ActivationLayer,BackpropagationSynapse>
    {
        internal double momentum = 0.07d;

        /// <summary>
        /// Gets or sets the momentum (the tendency of synapses to retain their previous deltas)
        /// </summary>
        /// <value>
        /// The tendency of synapses to retain their previous weight change.
        /// </value>
        public double Momentum
        {
            get { return momentum; }
            set { momentum = value; }
        }

        /// <summary>
        /// Creates a new complete backpropagation connector between given layers.
        /// </summary>
        /// <param name="sourceLayer">
        /// The source layer
        /// </param>
        /// <param name="targetLayer">
        /// The target layer
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>sourceLayer</c> or <c>targetLayer</c> is <c>null</c>
        /// </exception>
        public BackpropagationConnector(ActivationLayer sourceLayer, ActivationLayer targetLayer)
            : this(sourceLayer, targetLayer, ConnectionMode.Complete)
        {
        }

        /// <summary>
        /// Creates a new Backpropagation connector between the given layers using the specified
        /// connection mode.
        /// </summary>
        /// <param name="sourceLayer">
        /// The source layer
        /// </param>
        /// <param name="targetLayer">
        /// The target layer
        /// </param>
        /// <param name="connectionMode">
        /// Connection mode to use
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>sourceLayer</c> or <c>targetLayer</c> is <c>null</c>
        /// </exception>
        public BackpropagationConnector(ActivationLayer sourceLayer, ActivationLayer targetLayer, ConnectionMode connectionMode)
            : base(sourceLayer, targetLayer, connectionMode)
        {
            ConstructSynapses();
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
        public BackpropagationConnector(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ConstructSynapses();

            this.momentum = info.GetDouble("momentum");
            double[] weights = (double[])info.GetValue("weights", typeof(double[]));

            for (int i = 0; i < synapses.Length; i++)
            {
                synapses[i].Weight = weights[i];
            }
        }

        /// <summary>
        /// Populates the serialization info with the data needed to serialize the connector
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

            info.AddValue("momentum", momentum);

            double[] weights = new double[synapses.Length];
            for (int i = 0; i < synapses.Length; i++)
            {
                weights[i] = synapses[i].Weight;
            }

            info.AddValue("weights", weights, typeof(double[]));
        }

        /// <summary>
        /// Initializes all synapses in the connector and makes them ready to undergo training
        /// freshly. (Adjusts the weights of synapses using the initializer)
        /// </summary>
        public override void Initialize()
        {
            if (initializer != null)
            {
                initializer.Initialize(this);
            }
        }

        /// <summary>
        /// Private helper to construct synapses between layers
        /// </summary>
        private void ConstructSynapses()
        {
            int i = 0;
            if (connectionMode == ConnectionMode.Complete)
            {
                foreach (ActivationNeuron targetNeuron in targetLayer.Neurons)
                {
                    foreach (ActivationNeuron sourceNeuron in sourceLayer.Neurons)
                    {
                        synapses[i++] = new BackpropagationSynapse(sourceNeuron, targetNeuron, this);
                    }
                }
            }
            else
            {
                IEnumerator<ActivationNeuron> sourceEnumerator = sourceLayer.Neurons.GetEnumerator();
                IEnumerator<ActivationNeuron> targetEnumerator = targetLayer.Neurons.GetEnumerator();
                while (sourceEnumerator.MoveNext() && targetEnumerator.MoveNext())
                {
                    synapses[i++] = new BackpropagationSynapse(
                        sourceEnumerator.Current, targetEnumerator.Current, this);
                }
            }
        }
    }
}