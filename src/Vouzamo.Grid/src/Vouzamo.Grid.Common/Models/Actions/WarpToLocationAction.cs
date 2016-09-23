using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Actions
{
    public class WarpToLocationAction : Action
    {
        public ILocation WarpLocation { get; protected set; }

        public WarpToLocationAction(ILocation warpLocation) : base(ActionType.WarpToLocation)
        {
            WarpLocation = warpLocation;
        }
    }
}
