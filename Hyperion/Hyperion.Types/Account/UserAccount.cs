

using Hyperion.Types.Agent;
using System.Collections.Generic;

namespace Hyperion.Types.Account
{
    public class UserAccount
    {
        public UGUIWithName Principal = UGUIWithName.Unknown;
        public string Email = string.Empty;
        public Date Created = new Date();
        public int UserLevel = -1;
        public UserFlags UserFlags;
        public string UserTitle = string.Empty;
        public string UserBusiness;
        public string UserEmployment;
        public bool IsLocalToGrid;
        public bool IsEverLoggedIn;

        // only valid when IsLocalToGrid is set to false
        public Dictionary<string, string> ServiceURLs = new Dictionary<string, string>();

        public Date LastLogout = Date.Now;
        
        public UserRegionData LastRegion;
        public UserRegionData HomeRegion;
        
        public UserAccount()
        {
        }
        
        public UserAccount(UserAccount src)
        {
            Principal = new UGUIWithName(src.Principal);
            Email = src.Email;
            Created = src.Created;
            UserLevel = src.UserLevel;
            UserFlags = src.UserFlags;
            UserTitle = src.UserTitle;
            UserBusiness = src.UserBusiness;
            UserEmployment = src.UserEmployment;
            ServiceURLs = new Dictionary<string, string>(src.ServiceURLs);
            IsEverLoggedIn = src.IsEverLoggedIn;
            LastLogout = new Date(src.LastLogout);
            LastRegion = src.LastRegion?.Clone();
            HomeRegion = src.HomeRegion?.Clone();
        }
    }
}
