

namespace Hyperion.Types.Agent
{
    public sealed class UserRegionData
    {
        public UUID RegionID = UUID.Zero;
        public Vector3 Position = Vector3.Zero;
        public Vector3 LookAt = Vector3.Zero;
        public URI GatekeeperURI;

        public UserRegionData()
        {

        }

        public UserRegionData(UserRegionData src)
        {
            RegionID = src.RegionID;
            Position = src.Position;
            LookAt = src.LookAt;
            GatekeeperURI = src.GatekeeperURI;
        }

        public UserRegionData Clone() => new UserRegionData(this);
    }
}
