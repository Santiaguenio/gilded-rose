namespace GildedRose.Core.Items
{
    public class SulfurasItem : IItem, IUpdatable
    {
        public string Name => "Sulfuras";

        public Item Update(Item item)
        {
            return item;
        }
    }
}
