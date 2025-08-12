namespace GildedRose.Core.Items
{
    internal class AgedBrieItem : IItem, IUpdatable
    {
        private const int MAXIMUM_QUALITY_THRESHOLD = 50;

        public string Name => "Aged Brie";

        public Item Update(Item item)
        {
            if (item.Quality < MAXIMUM_QUALITY_THRESHOLD)
            {
                item.Quality += item.SellIn <= 0 ? 2 : 1;
            }

            item.SellIn -= 1;

            return item;
        }
    }
}
