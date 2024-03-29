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

namespace Hyperion.Types.Groups
{
    public class DirGroupInfo
    {
        public UGI ID = UGI.Unknown;
        public int MemberCount;
        public float SearchOrder;
    }

    public class GroupInfo
    {
        public UGI ID = UGI.Unknown;
        public string Charter = string.Empty;
        public UUID InsigniaID = UUID.Zero;
        public UGUI Founder = UGUI.Unknown;
        public int MembershipFee;
        public bool IsOpenEnrollment;
        public bool IsShownInList;
        public bool IsAllowPublish;
        public bool IsMaturePublish;
        public UUID OwnerRoleID = UUID.Zero;

        #region Informational fields

        public int MemberCount;
        public int RoleCount;

        #endregion

        public GroupInfo()
        {
        }

        public GroupInfo(GroupInfo src)
        {
            ID = new UGI(src.ID);
            Charter = src.Charter;
            InsigniaID = src.InsigniaID;
            Founder = new UGUI(src.Founder);
            MembershipFee = src.MembershipFee;
            IsOpenEnrollment = src.IsOpenEnrollment;
            IsShownInList = src.IsShownInList;
            IsAllowPublish = src.IsAllowPublish;
            IsMaturePublish = src.IsMaturePublish;
            OwnerRoleID = src.OwnerRoleID;
            MemberCount = src.MemberCount;
            RoleCount = src.RoleCount;
        }
    }
}
