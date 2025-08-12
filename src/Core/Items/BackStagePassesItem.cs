namespace GildedRose.Core.Items
{
    public class BackStagePassesItem : IItem, IUpdatable
    {
        private const int MAXIMUM_QUALITY_THRESHOLD = 50;

        public string Name => "Backstage passes";

        public Item Update(Item item)
        {
            if (item.Quality < MAXIMUM_QUALITY_THRESHOLD)
            {
                item.Quality += CalculateQualityAccordingToSellIn(item);
            }

            CheckNegativeSellIn(item);

            return item;
        }

        private static int CalculateQualityAccordingToSellIn(Item item)
        {
            if (item.SellIn <= 0)
            {
                return -item.Quality;
            }

            if (item.SellIn > 10)
            {
                return 1;
            }

            if (item.SellIn <= 10 && item.SellIn > 5)
            {
                return item.Quality + 2 < MAXIMUM_QUALITY_THRESHOLD ? 2 : 1;
            }

            return item.Quality + 3 <= MAXIMUM_QUALITY_THRESHOLD ? 
                3 :
                item.Quality + 2 < MAXIMUM_QUALITY_THRESHOLD ? 2 : 1;
        }

        private static int  CheckNegativeSellIn(Item item)
        {
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                return item.Quality -= item.Quality;
            }

            return item.Quality;
        }
    }
}
