/// <license>
/// Hyperion Virtual Worlds https://hyperionvirtual.com
/// is distributed under the terms of the
/// GNU Affero General Public License v3 with
/// the following clarification and special exception.
/// 
/// Linking this library statically or dynamically with other modules is
/// making a combined work based on this library. Thus, the terms and
/// conditions of the GNU Affero General Public License cover the whole
/// combination.
/// 
/// As a special exception, the copyright holders of this library give you
/// permission to link this library with independent modules to produce an
/// executable, regardless of the license terms of these independent
/// modules, and to copy and distribute the resulting executable under
/// terms of your choice, provided that you also meet, for each linked
/// independent module, the terms and conditions of the license of that
/// module. An independent module is a module which is not derived from
/// or based on this library. If you modify this library, you may extend
/// this exception to your version of the library, but you are not
/// obligated to do so. If you do not wish to do so, delete this
/// exception statement from your version.
/// </license>

namespace Hyperion.Types.Grid
{
    /*
    /// <summary>
    /// Secondlife actually uses
    /// this for how they handle maturity
    /// ratings for their regions.  It does
    /// not appear there is a rhyme or reason
    /// to how they did the numbering for
    /// the bytes in the bitmask for this.
    /// </summary>
    public enum RegionAccess : byte
    {
        Unknown = 0,
        PG = 13,
        Mature = 21,
        Adult = 42,
        Down = 254,
        NonExistent = 255
    }
    */

    /// <sumamry>
    /// In A Galaxy Beyond and Hyperion
    /// Virtual Worlds, our Maturity ratings
    /// also include additional ratings that
    /// Secondlife does not have.  Ideally
    /// We really should be doing the byte number
    /// sequence in the bitmask this way.
    /// </sumamry>
    public enum RegionAccess : byte
    {
        Unknown = 0,
        PG = 1,
        Business = 2,
        Charity = 3,
        Government = 4,
        Mature = 5,
        Adult = 6,
        AdultRP = 7,
        Down = 254,
        NonExistent = 255
    }
}
