namespace GildedRose.Core.Items
{
    public interface IUpdatable : IItem
    {
        Item Update(Item item);
    }
}