using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleTaskManager.Api.Controllers;

[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
public abstract class SimpleTaskManagerController(ISender sender) : ControllerBase
{
    protected ISender Sender => sender;
}
