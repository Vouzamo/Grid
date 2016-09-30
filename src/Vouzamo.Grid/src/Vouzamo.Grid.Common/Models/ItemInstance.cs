namespace Vouzamo.Grid.Common.Models
{
    public class ItemInstance
    {
        public ILocation Location { get; set; }
        public IItem Item { get; set; }

        public ItemInstance(ILocation location, IItem item)
        {
            Location = location;
            Item = item;
        }

        public IItemAction Invoke()
        {
            return Item.Type.Invoke(this);
        }
    }
}
