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

using Hyperion.Types.Asset;
using System;

namespace Hyperion.Types.Inventory
{
    public class InventoryItem
    {
        #region Inventory Data

        public UUID ID { get; protected set; }
        public UUID ParentFolderID = UUID.Zero;

        public virtual void SetNewID(UUID id)
        {
            ID = id;
        }

        private string m_Name = string.Empty;

        public string Name
        {
            get { return m_Name; }

            set
            {
                // ensure that no non-printable characters manage it into our inventory
                m_Name = value.FilterToAscii7Printable().TrimToMaxLength(63);
            }
        }

        private string m_Description = string.Empty;

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value.FilterToNonControlChars().TrimToMaxLength(127); }
        }

        public InventoryType InventoryType = InventoryType.Unknown;
        public InventoryFlags Flags;
        public UGUI Owner = UGUI.Unknown;
        public UGUI LastOwner = UGUI.Unknown;

        #endregion

        #region Creator Info

        public UGUI Creator = UGUI.Unknown;
        public Date CreationDate = new Date();

        #endregion

        #region Permissions

        public readonly InventoryPermissionsData Permissions = new InventoryPermissionsData();

        public bool CheckPermissions(UGUI accessor, UGI accessorgroup, InventoryPermissionsMask wanted) => (IsGroupOwned) ?
                Permissions.CheckGroupPermissions(Creator, Group, accessor, accessorgroup, wanted) :
                Permissions.CheckAgentPermissions(Creator, Owner, Group, accessor, accessorgroup, wanted);

        public void AdjustToNextOwner()
        {
            Permissions.AdjustToNextOwner();

            if (AssetType == AssetType.Object)
            {
                Flags |= InventoryFlags.ObjectSlamPerm | InventoryFlags.ObjectSlamSale | InventoryFlags.ObjectPermOverwriteBase | InventoryFlags.ObjectPermOverwriteEveryOne | InventoryFlags.ObjectPermOverwriteGroup | InventoryFlags.ObjectPermOverwriteOwner;
            }
            else if (AssetType == AssetType.Notecard)
            {
                Flags |= InventoryFlags.NotecardSlamPerm | InventoryFlags.NotecardSlamSale;
            }
        }

        #endregion

        #region SaleInfo

        public struct SaleInfoData
        {
            public enum SaleType : byte
            {
                NoSale = 0,
                Original = 1,
                Copy = 2,
                Content = 3
            }

            public int Price;
            public SaleType Type;
            public InventoryPermissionsMask PermMask;

            #region Properties

            public string TypeName
            {
                get
                {
                    switch (Type)
                    {
                        case SaleType.NoSale:
                        default: return "not";
                        case SaleType.Original: return "orig";
                        case SaleType.Copy: return "copy";
                        case SaleType.Content: return "cntn";
                    }
                }
                set
                {
                    switch (value)
                    {
                        case "not":
                            Type = SaleType.NoSale;
                            break;
                        case "orig":
                            Type = SaleType.Original;
                            break;
                        case "copy":
                            Type = SaleType.Copy;
                            break;
                        case "cntn":
                            Type = SaleType.Content;
                            break;
                        default:
                            throw new ArgumentException("invalid type name " + value);
                    }
                }
            }

            #endregion
        }

        public SaleInfoData SaleInfo;

        #endregion

        #region Group Information

        public UGI Group = UGI.Unknown;
        public bool IsGroupOwned;

        #endregion

        #region Asset Information

        public UUID AssetID = UUID.Zero;
        public AssetType AssetType = AssetType.Unknown;

        #endregion

        #region Constructors

        public InventoryItem()
        {
            ID = UUID.Random;
        }

        public InventoryItem(UUID id)
        {
            ID = id;
        }

        public InventoryItem(InventoryItem item)
        {
            AssetID = new UUID(item.AssetID);
            AssetType = item.AssetType;
            CreationDate = new Date(item.CreationDate);
            Creator = new UGUI(item.Creator);
            Description = item.Description;
            Flags = item.Flags;
            Group = new UGI(item.Group);
            IsGroupOwned = item.IsGroupOwned;
            ID = item.ID;
            InventoryType = item.InventoryType;
            LastOwner = new UGUI(item.LastOwner);
            Name = item.Name;
            Owner = new UGUI(item.Owner);
            ParentFolderID = new UUID(item.ParentFolderID);
            Permissions = new InventoryPermissionsData(item.Permissions);
            SaleInfo = item.SaleInfo;
        }

        public InventoryItem(UUID id, InventoryItem item)
        {
            AssetID = new UUID(item.AssetID);
            AssetType = item.AssetType;
            CreationDate = new Date(item.CreationDate);
            Creator = new UGUI(item.Creator);
            Description = item.Description;
            Flags = item.Flags;
            Group = new UGI(item.Group);
            IsGroupOwned = item.IsGroupOwned;
            ID = id;
            InventoryType = item.InventoryType;
            LastOwner = new UGUI(item.LastOwner);
            Name = item.Name;
            Owner = new UGUI(item.Owner);
            ParentFolderID = new UUID(item.ParentFolderID);
            Permissions = new InventoryPermissionsData(item.Permissions);
            SaleInfo = item.SaleInfo;
        }

        #endregion

        #region Properties

        public string AssetTypeName
        {
            get { return AssetType.AssetTypeToString(); }

            set { AssetType = value.StringToAssetType(); }
        }

        public string InventoryTypeName
        {
            get { return InventoryType.InventoryTypeToString(); }

            set { InventoryType = value.StringToInventoryType(); }
        }

        #endregion
    }
}
