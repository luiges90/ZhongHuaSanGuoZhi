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
    /// Mode of connection between layers.
    /// </summary>
    public enum ConnectionMode
    {
        /// <summary>
        /// A connection mode where all neurons of source layer are connected to all neurons of
        /// target layer
        /// </summary>
        Complete = 0,

        /// <summary>
        /// A connection mode where each neuron in source layer is connected to a single distinct
        /// neuron in the target layer. The source and target layers should have same number of
        /// neurons.
        /// </summary>
        OneOne = 1
    }
}
