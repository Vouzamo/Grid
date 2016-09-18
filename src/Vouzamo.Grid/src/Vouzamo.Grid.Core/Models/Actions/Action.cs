using Vouzamo.Grid.Core.Enums;

namespace Vouzamo.Grid.Core.Models.Actions
{
    public class Action : IAction
    {
        public ActionType Type { get; protected set; }

        public Action(ActionType type)
        {
            Type = type;
        }
    }
}
