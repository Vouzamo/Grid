using Vouzamo.Grid.Common.Helpers;
using Vouzamo.Grid.Common.Models.Actions;
using Vouzamo.Grid.Common.Models.Fields;

namespace Vouzamo.Grid.Common.Models.ItemTypes
{
    public class WarpItemType : ItemType
    {
        public WarpItemType() : base("Warp")
        {
            Fields.Add(new TextField("grid"));
            Fields.Add(new TextField("path"));
            Fields.Add(new IntegerField("x"));
            Fields.Add(new IntegerField("y"));
            Fields.Add(new IntegerField("z"));
        }

        public override IItemAction Invoke(Location location, IItem item)
        {
            var grid = Fields.GetField<TextField>("grid").GetValue(item.Values);
            var path = Fields.GetField<TextField>("path").GetValue(item.Values);

            var x = Fields.GetField<IntegerField>("x").GetValue(item.Values);
            var y = Fields.GetField<IntegerField>("y").GetValue(item.Values);
            var z = Fields.GetField<IntegerField>("z").GetValue(item.Values);

            var position = new Point3D(x, y, z);
            var warpLocation = new Location(grid, path, position);

            return new WarpToLocationItemAction(warpLocation);
        }

        public IItem CreateItem(string name, Location location, Location warpLocation)
        {
            var item = CreateItem(name, location);

            item.Values.Add(new FieldValue("grid", warpLocation.Grid));
            item.Values.Add(new FieldValue("path", warpLocation.Path));
            item.Values.Add(new FieldValue("x", warpLocation.Position.X.ToString()));
            item.Values.Add(new FieldValue("y", warpLocation.Position.Y.ToString()));
            item.Values.Add(new FieldValue("z", warpLocation.Position.Z.ToString()));

            return item;
        }
    }
}
