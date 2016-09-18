using Microsoft.AspNetCore.Mvc;
using Vouzamo.Grid.Core.Models;
using Vouzamo.Grid.Core.Services;

namespace Vouzamo.Grid.Web.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        protected IGridService GridService { get; set; }

        public ApiController(IGridService gridService)
        {
            GridService = gridService;
        }

        [Route("items/{grid}/{path}/{x},{y},{z}/{range}")]
        public IActionResult GetItems(string grid, string path, double x, double y, double z, double range)
        {
            var location = new Location(grid, path, new Point3D(x, y, z));

            var items = GridService.GetItems(location, range);

            return new ObjectResult(items);
        }
    }
}
