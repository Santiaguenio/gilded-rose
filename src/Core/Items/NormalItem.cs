namespace GildedRose.Core.Items;

public class NormalItem : IItem, IUpdatable
{
    private const int MINIMUM_QUALITY_THRESHOLD = 0;

    public string Name { get; set; } = default!;

    public Item Update(Item item)
    {
        if (item.Quality > MINIMUM_QUALITY_THRESHOLD)
        {
            item.Quality -= item.SellIn <= 0 ? 2 : 1;
        }

        item.SellIn -= 1;

        return item;
    }
}
