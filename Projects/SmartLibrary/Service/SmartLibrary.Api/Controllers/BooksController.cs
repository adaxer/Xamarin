using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartLibrary.Models;

namespace SmartLibrary.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IHubContext<BooksHub> _context;

        public BooksController(ILogger<BooksController> logger, IHubContext<BooksHub> context)
        {
            _logger = logger;
            this._context = context;
        }

        [HttpPost, Route("[action]")]
        public ActionResult Save(SavedBook book)
        {
            string json = JsonConvert.SerializeObject(book);
            _context.Clients.All.SendAsync("BookShared", json);
            return Ok();
        }
    }
}
