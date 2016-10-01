using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Actions
{
    public class WarpToLocationItemAction : ItemAction
    {
        public Location WarpLocation { get; protected set; }

        public WarpToLocationItemAction(Location warpLocation) : base(ActionType.WarpToLocation)
        {
            WarpLocation = warpLocation;
        }
    }
}
