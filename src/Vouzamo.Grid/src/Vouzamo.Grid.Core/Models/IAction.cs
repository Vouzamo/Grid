using Vouzamo.Grid.Core.Enums;

namespace Vouzamo.Grid.Core.Models
{
    public interface IAction
    {
        ActionType Type { get; }
    }
}
