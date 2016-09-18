using Vouzamo.Grid.Core.Enums;
using Vouzamo.Grid.Core.Models.Actions;

namespace Vouzamo.Grid.Core.Models.Items
{
    public class WarpItem : Item
    {
        public ILocation WarpLocation { get; protected set; }

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
