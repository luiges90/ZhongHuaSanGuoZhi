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
using System.Drawing;
using System.Runtime.Serialization;
using NeuronDotNet.Core.SOM.NeighborhoodFunctions;

namespace NeuronDotNet.Core.SOM
{
    /// <summary>
    /// Kohonen Layer is a layer containing position neurons.
    /// </summary>
    [Serializable]
    public class KohonenLayer : Layer<PositionNeuron>
    {
        private readonly Size size;
        private readonly LatticeTopology topology;
        private bool isRowCircular;
        private bool isColumnCircular;
        private PositionNeuron winner;
        private INeighborhoodFunction neighborhoodFunction;

        /// <summary>
        /// Gets the layer size
        /// </summary>
        /// <value>
        /// Size of the layer (Width is number of columns, and Height is number of rows) (In other
        /// words, width is number of neurons in a row and height is number of neurons in a column)
        /// </value>
        public Size Size
        {
            get { return size; }
        }

        /// <summary>
        /// Gets the lattice topology
        /// </summary>
        /// <value>
        /// Lattice topology of neurons in the layer
        /// </value>
        public LatticeTopology Topology
        {
            get { return topology; }
        }

        /// <summary>
        /// Gets or sets a boolean representing whether the neuron rows are circular
        /// </summary>
        /// <value>
        /// A boolean representing whether the neuron rows are circular
        /// </value>
        public bool IsRowCircular
        {
            get { return isRowCircular; }
            set { isRowCircular = value; }
        }

        /// <summary>
        /// Gets or sets a boolean representing whether the neuron columns are circular
        /// </summary>
        /// <value>
        /// A boolean representing whether the neuron columns are circular
        /// </value>
        public bool IsColumnCircular
        {
            get { return isColumnCircular; }
            set { isColumnCircular = value; }
        }

        /// <summary>
        /// Gets the winner neuron of the layer
        /// </summary>
        /// <value>
        /// Winner Neuron
        /// </value>
        public PositionNeuron Winner
        {
            get { return winner; }
        }

        /// <summary>
        /// Gets or sets the neighborhood function
        /// </summary>
        /// <value>
        /// Neighborhood Function
        /// </value>
        public INeighborhoodFunction NeighborhoodFunction
        {
            get { return neighborhoodFunction; }
            set { neighborhoodFunction = value; }
        }

        /// <summary>
        /// Position Neuron indexer
        /// </summary>
        /// <param name="x">
        /// X-Coordinate of the neuron
        /// </param>
        /// <param name="y">
        /// Y-Coordinate of the neuron
        /// </param>
        /// <returns>
        /// The neuron at given co-ordinates
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// If any of the indices are out of range
        /// </exception>
        public PositionNeuron this[int x, int y]
        {
            get { return neurons[x + y * size.Width]; }
        }

        /// <summary>
        /// Creates a linear Kohonen layer
        /// </summary>
        /// <param name="neuronCount">
        /// Number of neurons in the layer
        /// </param>
        /// <exception cref="ArgumentException">
        /// If <c>neuronCount</c> is zero or negative
        /// </exception>
        public KohonenLayer(int neuronCount)
            : this(new Size(neuronCount, 1))
        {
        }

        /// <summary>
        /// Creates a linear Kohonen layer with the given neighborhood function.
        /// </summary>
        /// <param name="neuronCount">
        /// Number of neurons in the layer
        /// </param>
        /// <param name="neighborhoodFunction">
        /// The neighborhood function
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>neighborhoodFunction</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <c>neuronCount</c> is zero or negative
        /// </exception>
        public KohonenLayer(int neuronCount, INeighborhoodFunction neighborhoodFunction)
            : this(new Size(neuronCount, 1), neighborhoodFunction)
        {
        }

        /// <summary>
        /// Creates a Kohonen Layer with the given size
        /// </summary>
        /// <param name="size">
        /// Size of the layer
        /// </param>
        /// <exception cref="ArgumentException">
        /// If layer width or layer height is not positive
        /// </exception>
        public KohonenLayer(Size size)
            : this(size, new GaussianFunction(Math.Max(size.Width, size.Height) / 2))
        {
        }

        /// <summary>
        /// Creates a Kohonen layer with the specified size and neighborhood function
        /// </summary>
        /// <param name="size">
        /// Size of the layer
        /// </param>
        /// <param name="neighborhoodFunction">
        /// Neighborhood function to use
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>neighborhoodFunction</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If layer width or layer height is not positive
        /// </exception>
        public KohonenLayer(Size size, INeighborhoodFunction neighborhoodFunction)
            : this(size, neighborhoodFunction, LatticeTopology.Rectangular)
        {
        }

        /// <summary>
        /// Creates a Kohonen layer with the specified size and topology
        /// </summary>
        /// <param name="size">
        /// Size of the layer
        /// </param>
        /// <param name="topology">
        /// Lattice topology of neurons
        /// </param>
        /// <exception cref="ArgumentException">
        /// If layer width or layer height is not positive, or if <c>topology</c> is invalid
        /// </exception>
        public KohonenLayer(Size size, LatticeTopology topology)
            : this(size, new GaussianFunction(Math.Max(size.Width, size.Height) / 2), topology)
        {
        }

        /// <summary>
        /// Creates a Kohonen layer with the specified size, topology and neighborhood function
        /// </summary>
        /// <param name="size">
        /// Size of the layer
        /// </param>
        /// <param name="neighborhoodFunction">
        /// Neighborhood function to use
        /// </param>
        /// <param name="topology">
        /// Lattice topology of neurons
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>neighborhoodFunction</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If layer width or layer height is not positive, or if <c>topology</c> is invalid
        /// </exception>
        public KohonenLayer(Size size, INeighborhoodFunction neighborhoodFunction, LatticeTopology topology)
            : base(size.Width * size.Height)
        {
            // The product can be positive when both width and height are negative. So, we need to check one.
            Helper.ValidatePositive(size.Width, "size.Width");

            Helper.ValidateNotNull(neighborhoodFunction, "neighborhoodFunction");
            Helper.ValidateEnum(typeof(LatticeTopology), topology, "topology");
            
            this.size = size;
            this.neighborhoodFunction = neighborhoodFunction;
            this.topology = topology;

            int k = 0;
            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    neurons[k++] = new PositionNeuron(new Point(x, y), this);
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
        public KohonenLayer(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.size.Height = info.GetInt32("size.Height");
            this.size.Width = info.GetInt32("size.Width");

            this.topology = (LatticeTopology)info.GetValue("topology", typeof(LatticeTopology));
            
            this.neighborhoodFunction
                = info.GetValue("neighborhoodFunction", typeof(INeighborhoodFunction))
                as INeighborhoodFunction;

            this.isRowCircular = info.GetBoolean("isRowCircular");
            this.isColumnCircular = info.GetBoolean("isColumnCircular");
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

            info.AddValue("topology", topology);
            info.AddValue("size.Height", size.Height);
            info.AddValue("size.Width", size.Width);
            info.AddValue("neighborhoodFunction", neighborhoodFunction, typeof(INeighborhoodFunction));
            info.AddValue("isRowCircular", isRowCircular);
            info.AddValue("isColumnCircular", isColumnCircular);
        }

        /// <summary>
        /// Initializes all neurons and makes them ready to undergo fresh training.
        /// </summary>
        public override void Initialize()
        {
            //Since there are no initializable parameters in this layer, this is a do-nothing function
        }

        /// <summary>
        /// Runs all neurons in the layer and finds the winner
        /// </summary>
        public override void Run()
        {
            this.winner = neurons[0];
            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i].Run();
                if (neurons[i].value < winner.value)
                {
                    winner = neurons[i];
                }
            }
        }

        /// <summary>
        /// All neurons and their are source connectors are allowed to learn. This method assumes a
        /// learning environment where inputs, outputs and other parameters (if any) are appropriate.
        /// </summary>
        /// <param name="currentIteration">
        /// Current learning iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Total number of training epochs
        /// </param>
        /// <exception cref="ArgumentException">
        /// If <c>trainingEpochs</c> is zero or negative
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is not less than <c>trainingEpochs</c>
        /// </exception>
        public override void Learn(int currentIteration, int trainingEpochs)
        {
            // Validation Delegated
            neighborhoodFunction.EvaluateNeighborhood(this, currentIteration, trainingEpochs);
            base.Learn(currentIteration, trainingEpochs);
        }
    }
}