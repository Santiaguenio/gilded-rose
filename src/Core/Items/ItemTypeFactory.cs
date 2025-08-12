using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Core.Items
{
    public class ItemTypeFactory(IEnumerable<IUpdatable> knownItems)
    {
        public IUpdatable Build(string itemName)
        {
            return knownItems.FirstOrDefault(
                _ => !string.IsNullOrWhiteSpace(_.Name)
                    && itemName.Contains(_.Name, System.StringComparison.InvariantCultureIgnoreCase),
                new NormalItem());
        }
    }
}
