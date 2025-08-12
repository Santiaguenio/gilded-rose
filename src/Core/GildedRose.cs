using GildedRose.Core.Items;
using System.Collections.Generic;

namespace GildedRose.Core;

public class GildedRose(
    IList<Item> items,
    ItemTypeFactory itemBuilder)
{
    public void UpdateQuality()
    {
        for (var i = 0; i < items.Count; i++)
        {
            var builtItem = itemBuilder.Build(items[i].Name);
            items[i] = builtItem.Update(items[i]);
        }
    }
}