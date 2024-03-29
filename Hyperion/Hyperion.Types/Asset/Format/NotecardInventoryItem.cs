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

using Hyperion.Types.Inventory;

namespace Hyperion.Types.Asset.Format
{
    public class NotecardInventoryItem : InventoryItem
    {
        public uint ExtCharIndex;

        public NotecardInventoryItem()
        {
        }

        public NotecardInventoryItem(UUID id)
        {
            ID = id;
        }

        public NotecardInventoryItem(InventoryItem item)
        {
            AssetID = item.AssetID;
            AssetType = item.AssetType;
            CreationDate = item.CreationDate;
            Creator = new UGUI(item.Creator);
            Description = item.Description;
            Flags = item.Flags;
            Group = new UGI(item.Group);
            IsGroupOwned = item.IsGroupOwned;
            InventoryType = item.InventoryType;
            LastOwner = new UGUI(item.LastOwner);
            Name = item.Name;
            Owner = new UGUI(item.Owner);
            ParentFolderID = item.ParentFolderID;
            Permissions.Base = item.Permissions.Base;
            Permissions.Current = item.Permissions.Current;
            Permissions.EveryOne = item.Permissions.EveryOne;
            Permissions.Group = item.Permissions.Group;
            Permissions.NextOwner = item.Permissions.NextOwner;
            SaleInfo = item.SaleInfo;
        }
    }
}