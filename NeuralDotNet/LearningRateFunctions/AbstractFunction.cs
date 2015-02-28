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

namespace NeuronDotNet.Core.LearningRateFunctions
{
    /// <summary>
    /// An abstract base class for a learning rate function.
    /// </summary>
    [Serializable]
    public abstract class AbstractFunction : ILearningRateFunction
    {
        /// <summary>
        /// Initial Learning Rate
        /// </summary>
        protected readonly double initialLearningRate;

        /// <summary>
        /// Final Learning Rate
        /// </summary>
        protected readonly double finalLearningRate;

        /// <summary>
        /// Gets the initial value of learning rate
        /// </summary>
        /// <value>
        /// Initial Learning Rate
        /// </value>
        public double InitialLearningRate
        {
            get { return initialLearningRate; }
        }

        /// <summary>
        /// Gets the final value of learning rate
        /// </summary>
        /// <value>
        /// Final Learning Rate
        /// </value>
        public double FinalLearningRate
        {
            get { return finalLearningRate; }
        }

        /// <summary>
        /// Constructs a new instance with the specified initial and final values of learning rate.
        /// </summary>
        /// <param name="initialLearningRate">
        /// Initial value learning rate
        /// </param>
        /// <param name="finalLearningRate">
        /// Final value learning rate
        /// </param>
        public AbstractFunction(double initialLearningRate, double finalLearningRate)
        {
            this.initialLearningRate = initialLearningRate;
            this.finalLearningRate = finalLearningRate;
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
        /// if <c>info</c> is <c>null</c>
        /// </exception>
        public AbstractFunction(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");

            this.initialLearningRate = info.GetDouble("initialLearningRate");
            this.finalLearningRate = info.GetDouble("finalLearningRate");
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
        /// if <c>info</c> is <c>null</c>
        /// </exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Helper.ValidateNotNull(info, "info");

            info.AddValue("initialLearningRate", initialLearningRate);
            info.AddValue("finalLearningRate", finalLearningRate);
        }

        /// <summary>
        /// Gets effective learning rate for current training iteration.
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingEpochs">
        /// Total number of training epochs
        /// </param>
        /// <returns>
        /// The effective learning rate for current training iteration
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If <c>trainingEpochs</c> is zero or negative
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <c>currentIteration</c> is negative or, if it is not less than <c>trainingEpochs</c>
        /// </exception>
        public abstract double GetLearningRate(int currentIteration, int trainingEpochs);
    }
}
