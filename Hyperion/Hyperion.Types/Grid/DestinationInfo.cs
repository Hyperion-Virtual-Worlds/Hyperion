﻿/// <license>
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
    public class DestinationInfo : RegionInfo
    {
        #region Constructor

        public DestinationInfo()
        {
        }

        public DestinationInfo(RegionInfo ri) : base(ri)
        {
        }

        public void UpdateFromRegion(RegionInfo ri)
        {
            ID = ri.ID;
            Location = ri.Location;
            Size = ri.Size;
            Name = ri.Name;
            ServerIP = ri.ServerIP;
            ServerHttpPort = ri.ServerHttpPort;
            ServerURI = ri.ServerURI;
            ServerPort = ri.ServerPort;
            RegionMapTexture = ri.RegionMapTexture;
            ParcelMapTexture = ri.ParcelMapTexture;
            Access = ri.Access;
            RegionSecret = ri.RegionSecret;
            Owner = new UGUI(ri.Owner);
            Flags = ri.Flags;
        }

        #endregion

        #region Fields

        public Vector3 Position = Vector3.Zero;
        public Vector3 LookAt = Vector3.Zero;
        public TeleportFlags TeleportFlags;
        public string StartLocation = string.Empty;
        public bool LocalToGrid;

        #endregion
    }
}
