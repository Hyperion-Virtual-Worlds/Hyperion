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
    public class GroupMembership
    {
        public UGI Group = UGI.Unknown;
        public UGUI Principal = UGUI.Unknown;
        public GroupPowers GroupPowers = GroupPowers.None;
        public bool IsAcceptNotices;
        public UUID GroupInsigniaID = UUID.Zero;
        public int Contribution;
        public string GroupTitle = string.Empty;
        public bool IsListInProfile;
        public bool IsAllowPublish;
        public string Charter;
        public UUID ActiveRoleID;
        public UGUI Founder = UGUI.Unknown;
        public string AccessToken;
        public bool IsMaturePublish;
        public bool IsOpenEnrollment;
        public int MembershipFee;
        public bool IsShownInList;

        public GroupMembership()
        {

        }

        public GroupMembership(GroupInfo info, GroupMember mem, GroupRole role, UUID activeRoleID)
        {
            Group = info.ID;
            Principal = mem.Principal;
            GroupPowers = role.Powers;
            IsAcceptNotices = mem.IsAcceptNotices;
            GroupInsigniaID = info.InsigniaID;
            Contribution = mem.Contribution;
            GroupTitle = role.Title;
            IsListInProfile = mem.IsListInProfile;
            IsAllowPublish = info.IsAllowPublish;
            Charter = info.Charter;
            ActiveRoleID = activeRoleID;
            Founder = info.Founder;
            AccessToken = mem.AccessToken;
            IsMaturePublish = info.IsMaturePublish;
            IsOpenEnrollment = info.IsOpenEnrollment;
            MembershipFee = info.MembershipFee;
            IsShownInList = info.IsShownInList;
        }
    }
}
