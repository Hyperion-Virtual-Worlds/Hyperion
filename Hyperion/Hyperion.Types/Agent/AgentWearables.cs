

using Hyperion.Threading;
using Hyperion.Types.Asset.Format;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Hyperion.Types.Agent
{
    public class AgentWearables
    {
        public struct WearableInfo
        {
            public UUID ItemID;
            public UUID AssetID;

            public WearableInfo(UUID itemID, UUID assetID)
            {
                ItemID = itemID;
                AssetID = assetID;
            }
        }

        private readonly ReaderWriterLock m_WearablesUpdateLock = new ReaderWriterLock();
        private readonly Dictionary<WearableType, List<WearableInfo>> m_Wearables = new Dictionary<WearableType, List<WearableInfo>>();

        public AgentWearables()
        {
            for (var type = WearableType.Shape; type < WearableType.NumWearables; ++type)
            {
                m_Wearables[type] = new List<WearableInfo>();
            }
        }

        public void Add(WearableType type, WearableInfo w)
        {
            m_WearablesUpdateLock.AcquireWriterLock(() =>
            {
                if (m_Wearables[type].Count >= 5)
                {
                    throw new ArgumentException("Too many elements in list");
                }

                m_Wearables[type].Add(w);
            });
        }

        #region Wearable type accessor

        public List<WearableInfo> this[WearableType type]
        {
            get
            {
                return m_WearablesUpdateLock.AcquireReaderLock(() =>
                {
                    // do not give access to our internal data via references
                    List<WearableInfo> s = m_Wearables[type];
                    var l = new List<WearableInfo>();

                    foreach (var i in s)
                    {
                        l.Add(i);
                    }

                    return l;
                });
            }

            set
            {
                var nl = new List<WearableInfo>();

                if (value.Count > 5)
                {
                    throw new ArgumentException("Too many elements in list");
                }

                // do not give access to our internal data
                foreach (var wi in value)
                {
                    nl.Add(wi);
                }

                if (nl.Count > 5)
                {
                    throw new ArgumentException("Too many elements in list");
                }

                m_WearablesUpdateLock.AcquireWriterLock(() =>
                {
                    m_Wearables[type] = nl;
                });
            }
        }

        #endregion

        #region Wearable, index accessor

        public WearableInfo this[WearableType type, uint index]
        {
            get
            {
                if (index >= 5)
                {
                    throw new KeyNotFoundException();
                }

                return m_WearablesUpdateLock.AcquireReaderLock(() => m_Wearables[type][(int)index]);
            }

            set
            {
                m_WearablesUpdateLock.AcquireWriterLock(() =>
                {
                    var wearableList = m_Wearables[type];

                    if (wearableList.Count <= index)
                    {
                        if (index >= 5)
                        {
                            throw new KeyNotFoundException();
                        }

                        wearableList.Add(value);
                    }
                    else
                    {
                        wearableList[(int)index] = value;
                    }
                });
            }
        }

        #endregion

        #region Replacement accessor

        public static implicit operator Dictionary<WearableType, List<WearableInfo>>(AgentWearables aw) => aw.All;

        public Dictionary<WearableType, List<WearableInfo>> All
        {
            get
            {
                return m_WearablesUpdateLock.AcquireReaderLock(() =>
                {
                    var od = new Dictionary<WearableType, List<WearableInfo>>();

                    foreach (var kvp in m_Wearables)
                    {
                        od.Add(kvp.Key, new List<WearableInfo>(kvp.Value));
                    }

                    return od;
                });
            }
            set
            {
                m_WearablesUpdateLock.AcquireWriterLock(() =>
                {
                    foreach (var lwi in m_Wearables.Values)
                    {
                        lwi.Clear();
                    }

                    foreach (var kvp in value)
                    {
                        if (kvp.Key < WearableType.NumWearables)
                        {
                            m_Wearables[kvp.Key] = new List<WearableInfo>(kvp.Value);
                        }
                    }
                });
            }
        }

        #endregion
    }
}
