namespace GildedRose.Core.Items;

public class ConjuredItem : IItem, IUpdatable
{
    private const int MINIMUM_QUALITY_THRESHOLD = 0;

    public string Name { get; set; } = "Conjured";

    public Item Update(Item item)
    {
        if (item.Quality > MINIMUM_QUALITY_THRESHOLD)
        {
            item.Quality -= item.SellIn <= 0 
                && item.Quality - 2 > MINIMUM_QUALITY_THRESHOLD ? 
                    2 : 
                    1;
        }

        item.SellIn -= 1;

        return item;
    }
}
