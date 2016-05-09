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
using NeuronDotNet.Core.Initializers;

namespace NeuronDotNet.Core.SOM
{
    /// <summary>
    /// A Kohonen Connector is an <see cref="IConnector"/> consisting of a collection of Kohonen
    /// synapses connecting any layer to a Kohonen Layer.
    /// </summary>
    [Serializable]
    public class KohonenConnector : Connector<ILayer, KohonenLayer, KohonenSynapse>
    {
        /// <summary>
        /// Creates a new Kohonen connector between the given layers.
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
        public KohonenConnector(ILayer sourceLayer, KohonenLayer targetLayer)
            : base(sourceLayer, targetLayer, ConnectionMode.Complete)
        {
            this.initializer = new RandomFunction();

            int i = 0;
            foreach (PositionNeuron targetNeuron in targetLayer.Neurons)
            {
                foreach (INeuron sourceNeuron in sourceLayer.Neurons)
                {
                    synapses[i++] = new KohonenSynapse(sourceNeuron, targetNeuron, this);
                }
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
        public KohonenConnector(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            double[] weights = (double[])info.GetValue("weights", typeof(double[]));

            int i = 0;
            foreach (INeuron sourceNeuron in sourceLayer.Neurons)
            {
                foreach (PositionNeuron targetNeuron in targetLayer.Neurons)
                {
                    synapses[i] = new KohonenSynapse(sourceNeuron, targetNeuron, this);
                    synapses[i].Weight = weights[i];
                    i++;
                }
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
    }
}
