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

namespace NeuronDotNet.Core.SOM
{
    /// <summary>
    /// A Kohonen Synapse is used to connect a neuron to a Position Neuron. It propagates the data
    /// from input neuron to an output position neuron and self-organizes its weights to match the
    /// input.
    /// </summary>
    public class KohonenSynapse : ISynapse
    {
        private double weight;
        private KohonenConnector parent;
        private INeuron sourceNeuron;
        private PositionNeuron targetNeuron;

        /// <summary>
        /// Gets or sets the weight of the synapse
        /// </summary>
        /// <value>
        /// Weight of the synapse
        /// </value>
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// Gets the parent connector
        /// </summary>
        /// <value>
        /// Parent connector containing this synapse. It is never <c>null</c>.
        /// </value>
        public KohonenConnector Parent
        {
            get { return parent; }
        }

        IConnector ISynapse.Parent
        {
            get { return parent; }
        }

        INeuron ISynapse.TargetNeuron
        {
            get { return targetNeuron; }
        }

        /// <summary>
        /// Gets the source neuron
        /// </summary>
        /// <value>
        /// The source neuron of the synapse. It is never <c>null</c>.
        /// </value>
        public INeuron SourceNeuron
        {
            get { return sourceNeuron; }
        }

        /// <summary>
        /// Gets the target neuron
        /// </summary>
        /// <value>
        /// The target neuron of the synapse. It is never <c>null</c>.
        /// </value>
        public PositionNeuron TargetNeuron
        {
            get { return targetNeuron; }
        }

        /// <summary>
        /// Creates a new Kohonen Synapse connecting the given neurons
        /// </summary>
        /// <param name="sourceNeuron">
        /// The source neuron
        /// </param>
        /// <param name="targetNeuron">
        /// The target neuron
        /// </param>
        /// <param name="parent">
        /// Parent connector containing this synapse
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// If any of the arguments is <c>null</c>
        /// </exception>
        public KohonenSynapse(INeuron sourceNeuron, PositionNeuron targetNeuron, KohonenConnector parent)
        {
            Helper.ValidateNotNull(sourceNeuron, "sourceNeuron");
            Helper.ValidateNotNull(targetNeuron, "targetNeuron");
            Helper.ValidateNotNull(parent, "parent");

            this.weight = 1d;

            sourceNeuron.TargetSynapses.Add(this);
            targetNeuron.SourceSynapses.Add(this);

            this.sourceNeuron = sourceNeuron;
            this.targetNeuron = targetNeuron;
            this.parent = parent;
        }

        /// <summary>
        /// Propagates the data from source neuron to the target neuron
        /// </summary>
        public void Propagate()
        {
            double similarity = sourceNeuron.Output - weight;
            targetNeuron.value += similarity * similarity;
        }

        /// <summary>
        /// Optimizes the weight to match the input
        /// </summary>
        /// <param name="learningFactor">
        /// Effective learning factor. This is a function of training progress, learning rate and
        /// neighborhood value of target neuron.
        /// </param>
        public void OptimizeWeight(double learningFactor)
        {
            weight += learningFactor * (sourceNeuron.Output - weight);
        }

        /// <summary>
        /// Adds small random noise to weight of this synapse so that the network deviates from
        /// its local optimum position (a local equilibrium state where further learning is of
        /// no use)
        /// </summary>
        /// <param name="jitterNoiseLimit">
        /// Maximum absolute limit to the random noise added
        /// </param>
        public void Jitter(double jitterNoiseLimit)
        {
            this.weight += Helper.GetRandom(-jitterNoiseLimit, jitterNoiseLimit);
        }
    }
}
