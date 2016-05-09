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
using System.Drawing;

namespace NeuronDotNet.Core.SOM
{
    /// <summary>
    /// Position Neuron is a neuron in a two-dimensional space used in Kohonen networks.
    /// </summary>
    public class PositionNeuron : INeuron
    {
        private readonly KohonenLayer parent;
        private readonly Point coordinate;
        private readonly IList<ISynapse> sourceSynapses = new List<ISynapse>();
        private readonly IList<ISynapse> targetSynapses = new List<ISynapse>();

        internal double value;
        internal double neighborhoodValue;

        /// <summary>
        /// Gets the parent layer containing this neuron
        /// </summary>
        /// <value>
        /// The parent layer containing this neuron. It is never <c>null</c>
        /// </value>
        public KohonenLayer Parent
        {
            get { return parent; }
        }

        /// <summary>
        /// Gets the neuron value
        /// </summary>
        /// <value>
        /// Neuron Value
        /// </value>
        public double Value
        {
            get { return value; }
        }

        double INeuron.Input
        {
            get { return value; }
            set { this.value = value; }
        }

        double INeuron.Output
        {
            get { return value; }
        }

        ILayer INeuron.Parent
        {
            get { return parent; }
        }

        /// <summary>
        /// Gets the position of the neuron
        /// </summary>
        /// <value>
        /// Neuron Co-ordinate
        /// </value>
        public Point Coordinate
        {
            get { return coordinate; }
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
        /// Gets the neighborhood of this neuron with respect to the winner neuron in this layer
        /// </summary>
        /// <value>
        /// Neighborhood Value
        /// </value>
        public double NeighborhoodValue
        {
            get { return neighborhoodValue; }
        }

        /// <summary>
        /// Creates new position neuron
        /// </summary>
        /// <param name="x">
        /// X-Coordinate of the neuron positon
        /// </param>
        /// <param name="y">
        /// Y-Coordinate of the neuron position
        /// </param>
        /// <param name="parent">
        /// Parent layer containing this neuron
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>parent</c> is <c>null</c>
        /// </exception>
        public PositionNeuron(int x, int y, KohonenLayer parent)
            : this(new Point(x, y), parent)
        {
        }

        /// <summary>
        /// Creates new positon neuron
        /// </summary>
        /// <param name="coordinate">
        /// Neuron Position
        /// </param>
        /// <param name="parent">
        /// Parent neuron containing this neuron
        /// </param>
        /// <value>
        /// If <c>parent</c> is <c>null</c>
        /// </value>
        public PositionNeuron(Point coordinate, KohonenLayer parent)
        {
            Helper.ValidateNotNull(parent, "parent");

            this.coordinate = coordinate;
            this.parent = parent;
            this.value = 0d;
        }

        /// <summary>
        /// Runs the neuron. (Propagates the source synapses and update input and output values)
        /// </summary>
        public void Run()
        {
            if (sourceSynapses.Count > 0)
            {
                value = 0d;
                for (int i = 0; i < sourceSynapses.Count; i++)
                {
                    sourceSynapses[i].Propagate();
                }
                value = Math.Sqrt(value);
            }
        }

        /// <summary>
        /// Trains weights of associated source synapses.
        /// </summary>
        /// <param name="learningRate">
        /// The current learning rate (this depends on training progress as well)
        /// </param>
        public void Learn(double learningRate)
        {
            double learningFactor = learningRate * neighborhoodValue;
            for (int i = 0; i < sourceSynapses.Count; i++)
            {
                sourceSynapses[i].OptimizeWeight(learningFactor);
            }
        }
    }
}