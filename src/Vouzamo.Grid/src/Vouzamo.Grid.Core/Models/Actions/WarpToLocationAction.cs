using Vouzamo.Grid.Core.Enums;

namespace Vouzamo.Grid.Core.Models.Actions
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
