using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Actions
{
    public class ItemAction : IItemAction
    {
        public ActionType Type { get; protected set; }

        public ItemAction(ActionType type)
        {
            Type = type;
        }
    }
}
