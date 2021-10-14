

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