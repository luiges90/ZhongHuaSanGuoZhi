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
    /// Lattice Topology of the position neurons in a Kohonen Layer
    /// </summary>
    public enum LatticeTopology
    {
        // Arrangement of neurons in a rectangular lattice
        //
        //            0 0 0 0 0 0
        //            0 0 0 * 0 0
        //            0 0 * O * 0
        //            0 0 0 * 0 0
        //            0 0 0 0 0 0
        //
        // The four immediate neighbors of 'O' are shown as '*'

        /// <summary>
        /// Each neuron has four immediate neighbors
        /// </summary>
        Rectangular = 0,



        // Arrangement of neurons in a hexagonal lattice
        //
        //            0 0 0 0 0
        //             0 0 * * 0
        //            0 0 * O * 0
        //             0 0 * * 0 0
        //              0 0 0 0 0
        //
        // The six immediate neighbors of 'O' are shown as '*'

        /// <summary>
        /// Each neuron has six immediate neighbors
        /// </summary>
        Hexagonal = 1,
    }
}
