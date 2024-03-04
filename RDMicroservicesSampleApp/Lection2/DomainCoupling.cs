namespace RDMicroservicesSampleApp.Lection2.DomainCoupling
{
    public class Project
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Task> Tasks { get; set; } = [];

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; }

        public void CompleteTask()
        {
            IsCompleted = true;
        }
    }

    public class ProjectService
    {
        private readonly List<Project> _projects = new List<Project>();

        public void CreateProject(string projectName)
        {
            Project project = new() { Id = GenerateProjectId(), Name = projectName };
            _projects.Add(project);
        }

        public void AddTaskToProject(int projectId, Task task)
        {
            var project = _projects.FirstOrDefault(p => p.Id == projectId);
            project?.AddTask(task);
        }

        private int GenerateProjectId()
        {
            // Генерація унікального ID для проекту
            return _projects.Count + 1;
        }
    }
}
