﻿using Microsoft.AspNetCore.Mvc;
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

        [Route("items/{range}"), HttpPost]
        public IActionResult GetItems([FromBody]Location location, double range)
        {
            var items = GridService.GetItems(location, range);

            return new ObjectResult(items);
        }
    }
}
