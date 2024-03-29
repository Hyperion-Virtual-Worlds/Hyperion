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

namespace Hyperion.Types.Groups
{
    public class GroupNotice
    {
        public UGI Group = UGI.Unknown;
        public UUID ID = UUID.Zero;
        public Date Timestamp = new Date();
        public string FromName = string.Empty;
        public string Subject = string.Empty;
        public string Message = string.Empty;
        public bool HasAttachment;
        public AssetType AttachmentType;
        public string AttachmentName = string.Empty;
        public UUID AttachmentItemID = UUID.Zero;
        public UGUI AttachmentOwner = UGUI.Unknown;

        public GroupNotice()
        {
        }

        public GroupNotice(GroupNotice src)
        {
            Group = new UGI(src.Group);
            ID = src.ID;
            Timestamp = new Date(src.Timestamp);
            FromName = src.FromName;
            Subject = src.Subject;
            Message = src.Message;
            HasAttachment = src.HasAttachment;
            AttachmentType = src.AttachmentType;
            AttachmentName = src.AttachmentName;
            AttachmentItemID = src.AttachmentItemID;
            AttachmentOwner = new UGUI(src.AttachmentOwner);
        }
    }
}