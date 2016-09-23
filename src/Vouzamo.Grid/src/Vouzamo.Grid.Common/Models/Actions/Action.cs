using Vouzamo.Grid.Common.Enums;

namespace Vouzamo.Grid.Common.Models.Actions
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
