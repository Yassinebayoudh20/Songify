using projects.Application.TodoLists.Queries.ExportTodos;

namespace projects.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
