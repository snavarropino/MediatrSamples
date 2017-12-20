using System.Diagnostics;
using System.Threading.Tasks;
using Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using site.Models;

namespace site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _mediator.Send(new Comando1("sergius"));
            await _mediator.Send(new Comando2());
            await _mediator.Send(new Comando3(){ Name = "dsds"});
            var res2 = await _mediator.Send(new Comando4("sergius"));
            await _mediator.Send(new Comando5(){Name="sergius"});

            await _mediator.Publish(new Event1());
            await _mediator.Publish(new Event2());

            await _mediator.Send(new Comando6(){Name="sergius"});
            await _mediator.Send(new Comando7(){Name="sergius"});

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
