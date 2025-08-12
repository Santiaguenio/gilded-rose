namespace GildedRose.Core.Items
{
    public class NormalItem : IItem, IUpdatable
    {
        private const int MINIMUM_QUALITY_THRESHOLD = 0;

        public string Name { get; set; } = default!;

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
            return item.SellIn <= 0 ? 2 : 1;
        }
    }
}
