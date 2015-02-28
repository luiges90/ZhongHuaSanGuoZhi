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

namespace NeuronDotNet.Core
{
    /// <summary>
    /// <para>
    /// An abstract base class to represent a neural network. A typical neural network consists of a
    /// set of <see cref="ILayer"/>s acyclically interconnected by various <see cref="IConnector"/>s.
    /// Input layer gets the input from the user and network output is obtained from the output layer.
    /// </para>
    /// <para>
    /// To create a neural network, follow these steps
    /// <list type="bullet">
    /// <item>Create and customize layers</item>
    /// <item>Establish connections between layers (No cycles should exist)</item>
    /// <item>Construct Network specifying the desired input and output layers</item>
    /// </list>
    /// </para>
    /// <para>
    /// There are two modes in which a neural network can be trained. In 'Batch Training', the neural
    /// network is allowed to learn by specifying a predefined training set containing various training
    /// samples. In 'Online training mode', a random training sample is generated every time (usually
    /// by another neural network, called 'teacher' network) and is used for training. Both modes are
    /// supported by overloaded <c>Learn()</c> methods. <c>Run()</c> method is used to run a neural
    /// network against a particular input.
    /// </para>
    /// </summary>
    [Serializable]
    public abstract class Network : INetwork
    {
        /// <summary>
        /// The input layer
        /// </summary>
        protected readonly ILayer inputLayer;

        /// <summary>
        /// The output layer
        /// </summary>
        protected readonly ILayer outputLayer;

        /// <summary>
        /// List of layers in the network, ordered acyclically (first layer being input layer and
        /// last one being output layer)
        /// </summary>
        protected readonly IList<ILayer> layers;

        /// <summary>
        /// A list of connectors between layers.
        /// </summary>
        protected readonly IList<IConnector> connectors;

        /// <summary>
        /// The method of training used to train the network
        /// </summary>
        protected readonly TrainingMethod trainingMethod;

        /// <summary>
        /// This event is invoked during the commencement of a new training iteration during 'Batch
        /// training' mode.
        /// </summary>
        public event TrainingEpochEventHandler BeginEpochEvent;

        /// <summary>
        /// This event is invoked whenever the network is about to learn a training sample.
        /// </summary>
        public event TrainingSampleEventHandler BeginSampleEvent;

        /// <summary>
        /// This event is invoked whenever the network has successfully completed learning a training
        /// sample.
        /// </summary>
        public event TrainingSampleEventHandler EndSampleEvent;

        /// <summary>
        /// This event is invoked whenever a training iteration is successfully completed during 'Batch
        /// training' mode.
        /// </summary>
        public event TrainingEpochEventHandler EndEpochEvent;

        /// <summary>
        /// Epoch(interval) at which Jitter operation is performed. If this value is zero, not jitter is
        /// performed.
        /// </summary>
        protected int jitterEpoch;

        /// <summary>
        /// Maximum absolute limit to the random noise added during Jitter operation
        /// </summary>
        protected double jitterNoiseLimit;

        /// <summary>
        /// This flag is set to true, whenever training needs to be stopped immmediately
        /// </summary>
        protected bool isStopping = false;

        /// <summary>
        /// Gets the input layer of the network
        /// </summary>
        /// <value>
        /// Input Layer of the network. This property is never <c>null</c>.
        /// </value>
        public ILayer InputLayer
        {
            get { return inputLayer; }
        }

        /// <summary>
        /// Gets the output layer of the network
        /// </summary>
        /// <value>
        /// Output Layer of the network. This property is never <c>null</c>.
        /// </value>
        public ILayer OutputLayer
        {
            get { return outputLayer; }
        }

        /// <summary>
        /// Gets the number of layers in the network.
        /// </summary>
        /// <value>
        /// Layer Count. This value is always positive.
        /// </value>
        public int LayerCount
        {
            // Note there can be networks (possibly in future versions) with only one layer
            get { return layers.Count; }
        }

        /// <summary>
        /// Exposes an enumerator to iterate over layers in the network.
        /// </summary>
        /// <value>
        /// Layer Enumerator. No layer in the network can be <c>null</c>.
        /// </value>
        public IEnumerable<ILayer> Layers
        {
            get
            {
                for(int i = 0; i < layers.Count; i++)
                {
                    yield return layers[i];
                }
            }
        }

        /// <summary>
        /// Layer Indexer
        /// </summary>
        /// <param name="index">
        /// The index
        /// </param>
        /// <returns>
        /// Layer at the given index
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// If the index is out of range
        /// </exception>
        public ILayer this[int index]
        {
            get { return layers[index]; }
        }

        /// <summary>
        /// Gets the number of connectors in the network.
        /// </summary>
        /// <value>
        /// Connector Count. This value is never negative.
        /// </value>
        public int ConnectorCount
        {
            get { return connectors.Count; }
        }

        /// <summary>
        /// Exposes an enumerator to iterate over connectors in the network. 
        /// </summary>
        /// <value>
        /// Connector Enumerator. No connector in a network can be <c>null</c>.
        /// </value>
        public IEnumerable<IConnector> Connectors
        {
            get
            {
                for (int i = 0; i < connectors.Count; i++)
                {
                    yield return connectors[i];
                }
            }
        }

        /// <summary>
        /// Gets or sets maximum absolute limit to the jitter noise
        /// </summary>
        /// <value>
        /// Maximum absolute limit to the random noise added while <c>Jitter</c>
        /// </value>
        public double JitterNoiseLimit
        {
            get { return jitterNoiseLimit; }
            set { jitterNoiseLimit = value; }
        }

        /// <summary>
        /// Gets or sets the jitter epoch
        /// </summary>
        /// <value>
        /// The epoch (interval) at which jitter is performed. If this value is not positive, no
        /// jitter is performed.
        /// </value>
        public int JitterEpoch
        {
            get { return jitterEpoch; }
            set { jitterEpoch = value; }
        }

        /// <summary>
        /// Creates a new neural network
        /// </summary>
        /// <param name="inputLayer">
        /// The input layer
        /// </param>
        /// <param name="outputLayer">
        /// The output layer
        /// </param>
        /// <param name="trainingMethod">
        /// Training method to use
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>inputLayer</c> or <c>outputLayer</c> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <c>trainingMethod</c> is invalid
        /// </exception>
        protected Network(ILayer inputLayer, ILayer outputLayer, TrainingMethod trainingMethod)
        {
            // Validate
            Helper.ValidateNotNull(inputLayer, "inputLayer");
            Helper.ValidateNotNull(outputLayer, "outputLayer");
            Helper.ValidateEnum(typeof(TrainingMethod), trainingMethod, "trainingMethod");
            
            // Assign arguments to corresponding variables
            this.inputLayer = inputLayer;
            this.outputLayer = inputLayer;
            this.trainingMethod = trainingMethod;
            
            // Initialize jitter parameters with default values
            this.jitterEpoch = 73;
            this.jitterNoiseLimit = 0.03d;

            // Create the list of layers and connectors
            this.layers = new List<ILayer>();
            this.connectors = new List<IConnector>();

            // Populate the lists by visiting layers topologically starting from input layer
            Stack<ILayer> stack = new Stack<ILayer>();
            stack.Push(inputLayer);

            // Indegree map
            IDictionary<ILayer, int> inDegree = new Dictionary<ILayer, int>();
            while (stack.Count > 0)
            {
                // Add 'top of stack' to list of layers
                this.outputLayer = stack.Pop();
                layers.Add(this.outputLayer);

                // Add targetConnectors to connectors list making sure that they do not lead to cycle
                foreach (IConnector connector in this.outputLayer.TargetConnectors)
                {
                    connectors.Add(connector);
                    ILayer targetLayer = connector.TargetLayer;
                    if (layers.Contains(targetLayer))
                    {
                        throw new InvalidOperationException("Cycle Exists in the network structure");
                    }

                    // Virtually remove this layer
                    inDegree[targetLayer] =
                        inDegree.ContainsKey(targetLayer)
                        ? inDegree[targetLayer] - 1
                        : targetLayer.SourceConnectors.Count - 1;

                    // Push unvisited target layer onto the stack, if its effective inDegree is zero
                    if (inDegree[targetLayer] == 0)
                    {
                        stack.Push(targetLayer);
                    }
                }
            }
            // The last layer should be same as output layer
            if (outputLayer != this.outputLayer)
            {
                throw new ArgumentException("The outputLayer is invalid", "outputLayer");
            }
            // Initialize the newly created network
            Initialize();
        }

        /// <summary>
        /// Deserialization constructor. It is assumed that the serialization info provided contains
        /// valid data.
        /// </summary>
        /// <param name="info">
        /// The serialization info to deserialize and obtain values
        /// </param>
        /// <param name="context">
        /// Serialization context
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>info</c> is <c>null</c>
        /// </exception>
        public Network(SerializationInfo info, StreamingContext context)
        {
            // Validate
            Helper.ValidateNotNull(info, "info");

            this.inputLayer = info.GetValue("inputLayer", typeof(ILayer)) as ILayer;
            this.outputLayer = info.GetValue("outputLayer", typeof(ILayer)) as ILayer;
            this.layers = info.GetValue("layers", typeof(IList<ILayer>)) as IList<ILayer>;
            this.connectors = info.GetValue("connectors", typeof(IList<IConnector>)) as IList<IConnector>;
            this.trainingMethod = (TrainingMethod)info.GetValue("trainingMethod", typeof(TrainingMethod));
            this.jitterEpoch = info.GetInt32("jitterEpoch");
            this.jitterNoiseLimit = info.GetDouble("jitterNoiseLimit");
        }

        /// <summary>
        /// Populates the serialization info with the data necessary to serialize the network.
        /// </summary>
        /// <param name="info">
        /// The info to populate serialization data with
        /// </param>
        /// <param name="context">
        /// Serialization context to use
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>info</c> is <c>null</c>
        /// </exception>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Validate
            Helper.ValidateNotNull(info, "info");

            // Populate data
            info.AddValue("inputLayer", inputLayer, typeof(ILayer));
            info.AddValue("outputLayer", outputLayer, typeof(ILayer));
            info.AddValue("layers", layers, typeof(IList<ILayer>));
            info.AddValue("connectors", connectors, typeof(IList<IConnector>));
            info.AddValue("trainingMethod", trainingMethod, typeof(TrainingMethod));
            info.AddValue("jitterNoiseLimit", jitterNoiseLimit);
            info.AddValue("jitterEpoch", jitterEpoch);
        }

        /// <summary>
        /// Invokes BeginEpochEvent
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingSet">
        /// Training set which is about to be trained
        /// </param>
        protected virtual void OnBeginEpoch(int currentIteration, TrainingSet trainingSet)
        {
            if (BeginEpochEvent != null)
            {
                BeginEpochEvent(this, new TrainingEpochEventArgs(currentIteration, trainingSet));
            }
        }

        /// <summary>
        /// Invokes EndEpochEvent
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingSet">
        /// Training set which got trained successfully this epoch
        /// </param>
        protected virtual void OnEndEpoch(int currentIteration, TrainingSet trainingSet)
        {
            if (EndEpochEvent != null)
            {
                EndEpochEvent(this, new TrainingEpochEventArgs(currentIteration, trainingSet));
            }
        }

        /// <summary>
        /// Invokes BeginSampleEvent
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="currentSample">
        /// Current sample which is about to be trained
        /// </param>
        protected virtual void OnBeginSample(int currentIteration, TrainingSample currentSample)
        {
            if (BeginSampleEvent != null)
            {
                BeginSampleEvent(this, new TrainingSampleEventArgs(currentIteration, currentSample));
            }
        }

        /// <summary>
        /// Invokes BeginSampleEvent
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="currentSample">
        /// Current sample which got trained successfully
        /// </param>
        protected virtual void OnEndSample(int currentIteration, TrainingSample currentSample)
        {
            if (EndSampleEvent != null)
            {
                EndSampleEvent(this, new TrainingSampleEventArgs(currentIteration, currentSample));
            }
        }

        /// <summary>
        /// Sets the learning rate to the given value. All layers in the network will use this constant
        /// value as learning rate during the learning process.
        /// </summary>
        /// <param name="learningRate">
        /// The learning rate
        /// </param>
        public void SetLearningRate(double learningRate)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].SetLearningRate(learningRate);
            }
        }

        /// <summary>
        /// Sets the initial and final values for learning rate. During the learning process, all
        /// layers in the network will use an efeective learning rate which varies uniformly from
        /// the initial value to the final value.
        /// </summary>
        /// <param name="initialLearningRate">
        /// Initial value of learning rate
        /// </param>
        /// <param name="finalLearningRate">
        /// Final value of learning rate
        /// </param>
        public void SetLearningRate(double initialLearningRate, double finalLearningRate)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].SetLearningRate(initialLearningRate, finalLearningRate);
            }
        }

        /// <summary>
        /// Sets the learning rate function.
        /// </summary>
        /// <param name="learningRateFunction">
        /// Learning rate function to use.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>learningRateFunction</c> is <c>null</c>
        /// </exception>
        public void SetLearningRate(ILearningRateFunction learningRateFunction)
        {
            // Validation is delegated
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].SetLearningRate(learningRateFunction);
            }
        }

        /// <summary>
        /// Initializes all layers and connectors and makes them ready to undergo fresh training.
        /// </summary>
        public virtual void Initialize()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].Initialize();
                foreach (IConnector connector in layers[i].TargetConnectors)
                {
                    connector.Initialize();
                }
            }
        }

        /// <summary>
        /// Runs the neural network against the given input
        /// </summary>
        /// <param name="input">
        /// Input to the network
        /// </param>
        /// <returns>
        /// The output of the network
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <c>input</c> is <c>null</c>
        /// </exception>
        public virtual double[] Run(double[] input)
        {
            // Validation is delegated
            inputLayer.SetInput(input);
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].Run();
            }
            return outputLayer.GetOutput();
        }

        /// <summary>
        /// Trains the neural network for the given training set (Batch Training)
        /// </summary>
        /// <param name="trainingSet">
        /// The training set to use
        /// </param>
        /// <param name="trainingEpochs">
        /// Number of training epochs. (All samples are trained in some random order, in every
        /// training epoch)
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// if <c>trainingSet</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// if <c>trainingEpochs</c> is zero or negative
        /// </exception>
        public virtual void Learn(TrainingSet trainingSet, int trainingEpochs)
        {
            // Validate
            Helper.ValidateNotNull(trainingSet, "trainingSet");
            Helper.ValidatePositive(trainingEpochs, "trainingEpochs");
            if ((trainingSet.InputVectorLength != inputLayer.NeuronCount)
                || (trainingMethod == TrainingMethod.Supervised && trainingSet.OutputVectorLength != outputLayer.NeuronCount)
                || (trainingMethod == TrainingMethod.Unsupervised && trainingSet.OutputVectorLength != 0))
            {
                throw new ArgumentException("Invalid training set");
            }

            // Reset isStopping
            isStopping = false;

            // Re-Initialize the network
            Initialize();
            for (int currentIteration = 0; currentIteration < trainingEpochs; currentIteration++)
            {
                int[] randomOrder = Helper.GetRandomOrder(trainingSet.TrainingSampleCount);
                // Beginning a new training epoch
                OnBeginEpoch(currentIteration, trainingSet);

                // Check for Jitter Epoch
                if (jitterEpoch > 0 && currentIteration % jitterEpoch == 0)
                {
                    for (int i = 0; i < connectors.Count; i++)
                    {
                        connectors[i].Jitter(jitterNoiseLimit);
                    }
                }
                for (int index = 0; index < trainingSet.TrainingSampleCount; index++)
                {
                    TrainingSample randomSample = trainingSet[randomOrder[index]];

                    // Learn a random training sample
                    OnBeginSample(currentIteration, randomSample);
                    LearnSample(trainingSet[randomOrder[index]], currentIteration, trainingEpochs);
                    OnEndSample(currentIteration, randomSample);

                    // Check if we need to stop
                    if (isStopping) { isStopping = false; return; }
                }

                // Training Epoch successfully complete
                OnEndEpoch(currentIteration, trainingSet);

                // Check if we need to stop
                if (isStopping) { isStopping = false; return; }
            }
        }

        /// <summary>
        /// Trains the network for the given training sample (Online training mode). Note that this
        /// method trains the sample only once, irrespective of what current epoch is. The arguments
        /// are just used to find out training progress and adjust parameters depending on it.
        /// </summary>
        /// <param name="trainingSample">
        /// Training sample to use
        /// </param>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Number of training epochs
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>trainingSample</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <c>trainingEpochs</c> is not positive
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is not less than <c>trainingEpochs</c>
        /// </exception>
        public virtual void Learn(TrainingSample trainingSample, int currentIteration, int trainingEpochs)
        {
            Helper.ValidateNotNull(trainingSample, "trainingSample");
            Helper.ValidatePositive(trainingEpochs, "trainingEpochs");
            Helper.ValidateWithinRange(currentIteration, 0, trainingEpochs - 1, "currentIteration");

            OnBeginSample(currentIteration, trainingSample);
            LearnSample(trainingSample, currentIteration, trainingEpochs);
            OnEndSample(currentIteration, trainingSample);
        }

        /// <summary>
        /// If the network is currently learning, this method stops the learning.
        /// </summary>
        public void StopLearning()
        {
            isStopping = true;
        }

        /// <summary>
        /// A protected helper function used to train single learning sample
        /// </summary>
        /// <param name="trainingSample">
        /// Training sample to use
        /// </param>
        /// <param name="currentIteration">
        /// Current training epoch (Assumed to be positive and less than <c>trainingEpochs</c>)
        /// </param>
        /// <param name="trainingEpochs">
        /// Number of training epochs (Assumed to be positive)
        /// </param>
        protected abstract void LearnSample(TrainingSample trainingSample, int currentIteration, int trainingEpochs);
    }
}