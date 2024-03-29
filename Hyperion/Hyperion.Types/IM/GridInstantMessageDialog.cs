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

using System;

namespace Hyperion.Types.IM
{
    public enum GridInstantMessageDialog : sbyte
    {
        MessageFromAgent = 0,
        MessageBox = 1,
        GroupInvitation = 3,
        InventoryOffered = 4,
        InventoryAccepted = 5,
        InventoryDeclined = 6,
        GroupVote = 7,
        TaskInventoryOffered = 9,
        TaskInventoryAccepted = 10,
        TaskInventoryDeclined = 11,
        NewUserDefault = 12,
        SessionAdd = 13,
        SessionOfflineAdd = 14,
        SessionGroupStart = 15,
        SessionConferenceStart = 16,
        SessionSend = 17,
        SessionLeave = 18,
        MessageFromObject = 19,
        BusyAutoResponse = 20,
        ConsoleAndChatHistory = 21,
        LureUser = 22,
        LureAccepted = 23,
        LureDeclined = 24,
        GodlikeLureUser = 25,
        TeleportRequest = 26,
        GotoUrl = 28,
        [Obsolete]
        Session911Start = 29,
        [Obsolete]
        Lure911 = 30,
        FromTaskAsAlert = 31,
        GroupNotice = 32,
        GroupNoticeInventoryAccepted = 33,
        GroupNoticeInventoryDeclined = 34,
        GroupInvitationAccept = 35,
        GroupInvitationDecline = 36,
        GroupNoticeRequested = 37,
        FriendshipOffered = 38,
        FriendshipAccepted = 39,
        FriendshipDeclined = 40,
        StartTyping = 41,
        StopTyping = 42,
        EjectedFromGroup = -46,
        OfferCallingCard = -45
    }
}