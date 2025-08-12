namespace GildedRose.Core.Items
{
    public class ConjuredItem : IItem, IUpdatable
    {
        private const int MINIMUM_QUALITY_THRESHOLD = 0;

        public string Name { get; set; } = "Conjured";

        public Item Update(Item item)
        {
            if (item.Quality > MINIMUM_QUALITY_THRESHOLD)
            {
                item.Quality -= CalculateQualityAccordingToSellin(item);
            }

            item.SellIn -= 1;

            return item;
        }

        private static int CalculateQualityAccordingToSellin(Item item)
        {
            return item.SellIn <= 0 && item.Quality - 2 > MINIMUM_QUALITY_THRESHOLD ? 2 : 1;
        }
    }
}
