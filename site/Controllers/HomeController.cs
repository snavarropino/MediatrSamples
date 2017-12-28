using System.Diagnostics;
using System.Threading.Tasks;
using Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using site.Models;

namespace site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMediator mediator, ILogger<HomeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Starting index");

            await SendCommand();
            await SendCommandWithNoResponse();
            await SendComandHandledWithNoCancelToken();
            await SendCommandThatIsHandledByTwoHandlers();
            await SendCommandThatIsHandledBySynchronousHandler();

            await SendEventThatIsManagedByTwoHandlers();
            await SendEventThatIsManagedBySpecialHandlers();

            await SendCommand6(); // For pipeline behaviours
            await SendCommand7(); // For pipeline behaviours

            return View();
        }

        private async Task SendCommand()
        {
            _logger.LogInformation("1. Sending command...");
            var response = await _mediator.Send(new MyCommand("sergius"));
            _logger.LogInformation("Response received: {response}", response.Id);
        }

        private async Task SendCommandWithNoResponse()
        {
            _logger.LogInformation("2. Sending command that has no response");
            await _mediator.Send(new MyCommand2());
        }

        private async Task SendComandHandledWithNoCancelToken()
        {
            _logger.LogInformation("3. Sending command, there is no cancellation token...");
            await _mediator.Send(new MyCommand3() { Name = "No cancellation command" });
        }

        private async Task SendCommandThatIsHandledByTwoHandlers()
        {
            _logger.LogInformation("4. Sending command... there are 2 handlers, hope just one is invoked");
            var result = await _mediator.Send(new Command4("sergius"));
            _logger.LogInformation("Response received: {response}", result.Id);
        }

        private async Task SendCommandThatIsHandledBySynchronousHandler()
        {
            _logger.LogInformation("5. Sending command, it will be managed by a synchronous handler");
            await _mediator.Send(new Command5() { Name = "sergius" });
        }

        private async Task SendEventThatIsManagedByTwoHandlers()
        {
            _logger.LogInformation("6. Sending event, it will be managed by two handlers");
            await _mediator.Publish(new Event1() {Source = "mySource"});
        }

        private async Task SendEventThatIsManagedBySpecialHandlers()
        {
            _logger.LogInformation("7. Sending event, it will be managed by a handler that has no cacellation token and by another one that works in a synchronous way");
            await _mediator.Publish(new Event2() { Source = "mySource2" });
        }

        private async Task SendCommand6()
        {
            _logger.LogInformation("9. Sending comand 6");
            await _mediator.Send(new Command6() { Name = "sergius" });
        }

        private async Task SendCommand7()
        {
            _logger.LogInformation("9 bis. Sending comand 7");
            await _mediator.Send(new Command7() { Name = "sergius" });
        }

        #region "Other actions"
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
        #endregion
    }
}
