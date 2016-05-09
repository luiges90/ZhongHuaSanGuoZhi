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

namespace NeuronDotNet.Core.Backpropagation
{
    /// <summary>
    /// Activation Neuron is a buiding block of a back-propagation neural network.
    /// </summary>
    public class ActivationNeuron : INeuron
    {
        internal double input;
        internal double output;
        internal double error;
        internal double bias;

        private readonly IList<ISynapse> sourceSynapses = new List<ISynapse>();
        private readonly IList<ISynapse> targetSynapses = new List<ISynapse>();

        private ActivationLayer parent;

        /// <summary>
        /// Gets or sets the neuron input.
        /// </summary>
        /// <value>
        /// Input to the neuron. For input neurons, this value is specified by user, whereas other
        /// neurons will have their inputs updated when the source synapses propagate
        /// </value>
        public double Input
        {
            get { return input; }
            set { input = value; }
        }

        /// <summary>
        /// Gets the output of the neuron.
        /// </summary>
        /// <value>
        /// Neuron Output
        /// </value>
        public double Output
        {
            get { return output; }
        }

        /// <summary>
        /// Gets the neuron error
        /// </summary>
        /// <value>
        /// Neuron Error
        /// </value>
        public double Error
        {
            get { return error; }
        }

        /// <summary>
        /// Gets the neuron bias
        /// </summary>
        /// <value>
        /// The current value of neuron bias
        /// </value>
        public double Bias
        {
            get { return bias; }
        }

        /// <summary>
        /// Gets the list of source synapses associated with this neuron
        /// </summary>
        /// <value>
        /// A list of source synapses. It can neither be <c>null</c>, nor contain <c>null</c> elements.
        /// </value>
        public IList<ISynapse> SourceSynapses
        {
            get { return sourceSynapses; }
        }

        /// <summary>
        /// Gets the list of target synapses associated with this neuron
        /// </summary>
        /// <value>
        /// A list of target synapses. It can neither be <c>null</c>, nor contains <c>null</c> elements.
        /// </value>
        public IList<ISynapse> TargetSynapses
        {
            get { return targetSynapses; }
        }

        /// <summary>
        /// Gets the parent layer containing this neuron
        /// </summary>
        /// <value>
        /// The parent layer containing this neuron. It is never <c>null</c>
        /// </value>
        public ActivationLayer Parent
        {
            get { return parent; }
        }

        ILayer INeuron.Parent
        {
            get { return parent; }
        }

        /// <summary>
        /// Create a new activation neuron
        /// </summary>
        /// <param name="parent">
        /// The parent layer containing this neuron
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// If <c>parent</c> is <c>null</c>
        /// </exception>
        public ActivationNeuron(ActivationLayer parent)
        {
            Helper.ValidateNotNull(parent, "parent");

            this.input = 0d;
            this.output = 0d;
            this.error = 0d;
            this.bias = 0d;
            this.parent = parent;
        }

        /// <summary>
        /// Obtains input from source synapses and activates to update the output
        /// </summary>
        public void Run()
        {
            if (sourceSynapses.Count > 0)
            {
                input = 0d;
                for (int i = 0; i < sourceSynapses.Count; i++)
                {
                    sourceSynapses[i].Propagate();
                }
            }
            output = parent.Activate(bias + input, output);
        }

        /// <summary>
        /// Backpropagates the target synapses and evaluates the error
        /// </summary>
        public void EvaluateError()
        {
            if (targetSynapses.Count > 0)
            {
                error = 0d;
                foreach (BackpropagationSynapse synapse in targetSynapses)
                {
                    synapse.Backpropagate();
                }
            }
            error *= parent.Derivative(input, output);
        }

        /// <summary>
        /// Optimizes the bias value (if not <c>UseFixedBiasValues</c>) and the weights of all the
        /// source synapses using back propagation algorithm
        /// </summary>
        /// <param name="learningRate">
        /// The current learning rate (this depends on training progress as well)
        /// </param>
        public void Learn(double learningRate)
        {
            if (!parent.useFixedBiasValues)
            {
                bias += learningRate * error;
            }
            for (int i = 0; i < sourceSynapses.Count; i++)
            {
                sourceSynapses[i].OptimizeWeight(learningRate);
            }
        }
    }
}
