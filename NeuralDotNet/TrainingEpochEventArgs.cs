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

namespace NeuronDotNet.Core
{
    /// <summary>
    /// Training Epoch Event Handler. This delegate handles events invoked whenever a training epoch
    /// starts or ends
    /// </summary>
    /// <param name="sender">
    /// The sender invoking the event
    /// </param>
    /// <param name="e">
    /// Event Arguments
    /// </param>
    public delegate void TrainingEpochEventHandler(object sender, TrainingEpochEventArgs e);

    /// <summary>
    /// Training Epoch Event Arguments
    /// </summary>
    public class TrainingEpochEventArgs : EventArgs
    {
        private int trainingIteration;
        private TrainingSet trainingSet;

        /// <summary>
        /// Gets the current training iteration
        /// </summary>
        /// <value>
        /// Current Training Iteration.
        /// </value>
        public int TrainingIteration
        {
            get { return trainingIteration; }
        }

        /// <summary>
        /// Gets the training set associated
        /// </summary>
        /// <value>
        /// Training set associated with the event
        /// </value>
        public TrainingSet TrainingSet
        {
            get { return trainingSet; }
        }

        /// <summary>
        /// Creates a new instance of training epoch event arguments
        /// </summary>
        /// <param name="trainingIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingSet">
        /// The training set associated with the event
        /// </param>
        public TrainingEpochEventArgs(int trainingIteration, TrainingSet trainingSet)
        {
            this.trainingSet = trainingSet;
            this.trainingIteration = trainingIteration;
        }
    }
}
