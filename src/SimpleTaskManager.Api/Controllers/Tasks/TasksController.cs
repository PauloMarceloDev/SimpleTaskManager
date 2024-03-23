using MediatR;
using Microsoft.AspNetCore.Mvc;
using PWSoftware.BaseDomain.Abstractions;
using SimpleTaskManager.Application.Tasks;
using SimpleTaskManager.Application.Tasks.CreateTask;
using SimpleTaskManager.Application.Tasks.DeleteTask;
using SimpleTaskManager.Application.Tasks.GetAllTasks;
using SimpleTaskManager.Application.Tasks.GetTaskById;
using SimpleTaskManager.Application.Tasks.UpdateTask;
using Swashbuckle.AspNetCore.Annotations;

namespace SimpleTaskManager.Api.Controllers.Tasks;

[Route("tasks")]
public class TasksController(ISender sender) : SimpleTaskManagerController(sender)
{
    [HttpGet]
    [SwaggerOperation(Summary = "Listar Tarefas", Description = "Retorna uma lista de todas as tarefas criadas.")]
    [ProducesResponseType(typeof(IEnumerable<TaskResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<TaskResponse>>> GetAll(CancellationToken cancellationToken)
    {
        Result<IEnumerable<TaskResponse>> result = await Sender.Send(new GetAllTasksQuery(), cancellationToken);
        
        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value);
    }
    
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Visualizar Tarefa", Description = "Retorna a tarefa com o ID especificado.")]
    [ProducesResponseType(typeof(TaskResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<TaskResponse>> GetById([SwaggerParameter(Description = "ID da tarefa")]int id, CancellationToken cancellationToken)
    {
        Result<TaskResponse> result = await Sender.Send(new GetTaskByIdQuery(id), cancellationToken);
        
        return result.IsFailure ? NotFound(result.Error) : Ok(result.Value);
    }
    
    [HttpPost]
    [SwaggerOperation(Summary = "Criar Tarefa", Description = "Cria uma nova tarefa.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateTaskCommand(
            request.Title,
            request.Description,
            request.Priority,
            request.DeadlineOnUtc);

        Result<TaskResponse> result = await Sender.Send(command, cancellationToken);

        return  result.IsFailure 
            ? BadRequest(result.Error) 
            : CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
    }
    
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Editar Tarefa", Description = "Atualiza as informações da tarefa com o ID especificado.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update([SwaggerParameter(Description = "ID da tarefa")]int id, UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateTaskCommand(
            id,
            request.Title,
            request.Description,
            request.Priority,
            request.DeadlineOnUtc,
            request.Status);

        Result result = await Sender.Send(command, cancellationToken);

        return  result.IsFailure 
            ? BadRequest(result.Error) 
            : NoContent();
    }
    
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Excluir Tarefa", Description = "Exclui a tarefa com o ID especificado.")]
    
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete([SwaggerParameter(Description = "ID da tarefa")]int id, CancellationToken cancellationToken)
    {
        var command = new DeleteTaskCommand(id);

        Result result = await Sender.Send(command, cancellationToken);

        return  result.IsFailure 
            ? BadRequest(result.Error) 
            : NoContent();
    }
}
