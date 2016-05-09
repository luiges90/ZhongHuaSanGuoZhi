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

using System.Runtime.Serialization;
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.SOM;

namespace NeuronDotNet.Core
{
    /// <summary>
    /// Initializer interface. An initializer should define initialization methods for all concrete
    /// initializable layers and connectors.
    /// </summary>
    public interface IInitializer : ISerializable
    {
        /// <summary>
        /// Initializes bias values of activation neurons in an activation layer.
        /// </summary>
        /// <param name="activationLayer">
        /// The activation layer to initialize
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// If <c>activationLayer</c> is <c>null</c>
        /// </exception>
        void Initialize(ActivationLayer activationLayer);

        /// <summary>
        /// Initializes weights of all backpropagation synapses in a backpropagation connector.
        /// </summary>
        /// <param name="connector">
        /// The backpropagation connector to initialize.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// If <c>connector</c> is <c>null</c>
        /// </exception>
        void Initialize(BackpropagationConnector connector);

        /// <summary>
        /// Initializes weights of all spatial synapses in a Kohonen connector.
        /// </summary>
        /// <param name="connector">
        /// The Kohonen connector to initialize.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// If <c>connector</c> is <c>null</c>
        /// </exception>
        void Initialize(KohonenConnector connector);
    }
}