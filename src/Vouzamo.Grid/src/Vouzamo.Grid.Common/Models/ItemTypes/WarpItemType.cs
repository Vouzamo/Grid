using System.Linq;
using Vouzamo.Grid.Common.Enums;
using Vouzamo.Grid.Common.Models.Actions;

namespace Vouzamo.Grid.Common.Models.ItemTypes
{
    public class WarpItemType : ItemType
    {
        public WarpItemType() : base("Warp")
        {
            Fields.Add(new ItemField("grid"));
            Fields.Add(new ItemField("path"));
            Fields.Add(new ItemField("positionX", FieldType.Integer));
            Fields.Add(new ItemField("positionY", FieldType.Integer));
            Fields.Add(new ItemField("positionZ", FieldType.Integer));
        }

        public override IItemAction Invoke(ItemInstance itemInstance)
        {
            // todo: replace this garbage with a service or helper
            var x = itemInstance.Item.Values.SingleOrDefault(z =>
            {
                var firstOrDefault = Fields.FirstOrDefault(y => y.Name == "positionX");
                return firstOrDefault != null && z.FieldId == firstOrDefault.Id;
            });

            var position = new Point3D(x, y, z);
            var location = new Location(grid, path, position);

            return new WarpToLocationItemAction(location);
        }
    }
}
