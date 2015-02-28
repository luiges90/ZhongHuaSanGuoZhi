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

namespace NeuronDotNet.Core
{
    /// <summary>
    /// This interface represents a synapse in a network. A Synapse is responsible for communication
    /// between neurons. A typical neural network consists of millions of synapses. The functioning
    /// of a neural network significantly depends on the <c>Weight</c>s of these synpases.
    /// </summary>
    public interface ISynapse
    {
        /// <summary>
        /// Gets or sets the weight of the synapse
        /// </summary>
        /// <value>
        /// Weight of the synapse
        /// </value>
        double Weight { get; set; }

        /// <summary>
        /// Gets the parent connector
        /// </summary>
        /// <value>
        /// Parent connector containing this synapse. It is never <c>null</c>.
        /// </value>
        IConnector Parent { get; }

        /// <summary>
        /// Gets the source neuron
        /// </summary>
        /// <value>
        /// The source neuron of the synapse. It is never <c>null</c>.
        /// </value>
        INeuron SourceNeuron { get; }

        /// <summary>
        /// Gets the target neuron
        /// </summary>
        /// <value>
        /// The target neuron of the synapse. It is never <c>null</c>.
        /// </value>
        INeuron TargetNeuron { get; }

        /// <summary>
        /// Propagates the information from source neuron to the target neuron
        /// </summary>
        void Propagate();

        /// <summary>
        /// Optimizes weight of this synapse
        /// </summary>
        /// <param name="learningFactor">
        /// Effective learning factor. This is mainly a function of training progress and learning
        /// rate. It can also depend on other factors like neighborhood function in Kohonen networks.
        /// </param>
        void OptimizeWeight(double learningFactor);

        /// <summary>
        /// Adds small random noise to weight of this synapse so that the network deviates from
        /// its local optimum position (a local equilibrium state where further learning is of
        /// no use)
        /// </summary>
        /// <param name="jitterNoiseLimit">
        /// Maximum absolute limit to the random noise added
        /// </param>
        void Jitter(double jitterNoiseLimit);
    }
}