using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FileUploader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace FileUploader.Controllers
{
    [Route("api/[controller]")]
    public class ContainersController : Controller
    {
        private readonly IStorage storage;

        public ContainersController(IStorage storage)
        {
            this.storage = storage;
        }

        // GET /api/Containers
        // Called by the page when it's first loaded, whenever new files are uploaded, and every
        // five seconds on a timer.
        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var containers = await storage.GetContainers();

            return Ok(containers);            
        }

    }
}