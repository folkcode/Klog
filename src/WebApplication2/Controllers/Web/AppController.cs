using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Klog.Controllers.Web {
    public class AppController : Controller {
        private ILogger<AppController> _logger;

        public AppController(ILogger<AppController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
          //  _logger.LogCritical("CRITICAL LOG");
            return View();
        }
    }
}
