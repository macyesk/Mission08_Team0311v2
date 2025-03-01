namespace Mission08_Team0311v2.Models;

public interface ITaskRepository
{
    List<TaskItem> Tasks { get; }
    List<Category> Categories { get; }
    void AddTask(TaskItem task);
    void UpdateTask(TaskItem task);
    void DeleteTask(int id);
}