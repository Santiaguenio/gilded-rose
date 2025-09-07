using GildedRose.Core.Items;
using System.Collections.Generic;

namespace GildedRose.Core;

public class GildedRose(
    IList<Item> items,
    ItemTypeFactory itemTypeFactory)
{
    public void UpdateQuality()
    {
        for (var i = 0; i < items.Count; i++)
        {
            var itemType = itemTypeFactory.Build(items[i].Name);
            items[i] = itemType.Update(items[i]);
        }
    }
}