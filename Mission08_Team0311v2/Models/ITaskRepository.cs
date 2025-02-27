namespace Mission08_Team0311v2.Models;

public interface ITaskRepository
{
    List<TaskItem> Tasks { get; }
    void AddTask(TaskItem task);
}