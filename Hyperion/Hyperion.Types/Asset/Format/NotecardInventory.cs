

using Hyperion.Threading;
using System.Collections.Generic;

namespace Hyperion.Types.Asset.Format
{
    public class NotecardInventory : RwLockedDictionary<UUID, NotecardInventoryItem>
    {
        #region ExtCharIndex Access

        public NotecardInventoryItem this[uint extCharIndex]
        {
            get
            {
                try
                {
                    foreach (NotecardInventoryItem item in Values)
                    {
                        if (item.ExtCharIndex == extCharIndex)
                        {
                            throw new ReturnValueException<NotecardInventoryItem>(item);
                        }
                    }
                }
                catch (ReturnValueException<NotecardInventoryItem> e)
                {
                    return e.Value;
                }

                throw new KeyNotFoundException("ExtCharIndex " + extCharIndex.ToString() + " not found");
            }
        }

        #endregion
    }
}