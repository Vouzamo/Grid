using Vouzamo.Grid.Common.Enums;
using Vouzamo.Grid.Common.Models.Actions;

namespace Vouzamo.Grid.Common.Models.Items
{
    public class WarpItem : Item
    {
        public ILocation WarpLocation { get; protected set; }

        protected WarpItem() : base(string.Empty, ItemType.Warp)
        {
            
        }

        public WarpItem(string name, ILocation warpLocation) : base(name, ItemType.Warp)
        {
            WarpLocation = warpLocation;
        }

        public override IAction Invoke(ILocation location)
        {
            return new WarpToLocationAction(WarpLocation);
        }
    }
}
