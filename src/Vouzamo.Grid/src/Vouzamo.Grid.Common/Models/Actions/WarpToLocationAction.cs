using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Actions
{
    public class WarpToLocationItemAction : ItemAction
    {
        public ILocation WarpLocation { get; protected set; }

        public WarpToLocationItemAction(ILocation warpLocation) : base(ActionType.WarpToLocation)
        {
            WarpLocation = warpLocation;
        }
    }
}
