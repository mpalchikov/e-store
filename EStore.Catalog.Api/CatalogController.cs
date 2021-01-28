using Microsoft.AspNetCore.Mvc;
using System;

namespace EStore.Catalog.Api
{
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
