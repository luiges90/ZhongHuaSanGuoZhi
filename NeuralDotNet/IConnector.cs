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
    /// This interface represents a connector. A connector is a collection of synapses connecting
    /// two layers in a network.
    /// </summary>
    public interface IConnector : ISerializable
    {
        /// <summary>
        /// Gets the source layer
        /// </summary>
        /// <value>
        /// The source layer. It is never <c>null</c>.
        /// </value>
        ILayer SourceLayer { get; }

        /// <summary>
        /// Gets the target layer
        /// </summary>
        /// <value>
        /// The target layer. It is never <c>null</c>.
        /// </value>
        ILayer TargetLayer { get; }

        /// <summary>
        /// Gets the number of synapses in the connector. 
        /// </summary>
        /// <value>
        /// Synapse Count. It is always positive.
        /// </value>
        int SynapseCount { get; }

        /// <summary>
        /// Exposes an enumerator to iterate over all synapses in the connector.
        /// </summary>
        /// <value>
        /// Synapses Enumerator. No synapse enumerated can be <c>null</c>.
        /// </value>
        IEnumerable<ISynapse> Synapses { get; }

        /// <summary>
        /// Gets the connection mode
        /// </summary>
        /// <value>
        /// Connection Mode
        /// </value>
        ConnectionMode ConnectionMode { get; }

        /// <summary>
        /// Gets or sets the Initializer used to initialize the connector
        /// </summary>
        /// <value>
        /// Initializer used to initialize the connector. If this value is <c>null</c>, initialization
        /// is NOT performed.
        /// </value>
        IInitializer Initializer { get; set; }

        /// <summary>
        /// Initializes all synapses in the connector and makes them ready to undergo training
        /// freshly. (Adjusts the weights of synapses using the initializer)
        /// </summary>
        void Initialize();

        /// <summary>
        /// Adds small random noise to weights of synapses so that the network deviates from its
        /// local optimum position (a local equilibrium state where further learning is of no use)
        /// </summary>
        /// <param name="jitterNoiseLimit">
        /// Maximum absolute limit to the random noise added
        /// </param>
        void Jitter(double jitterNoiseLimit);
    }
}