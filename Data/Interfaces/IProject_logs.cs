using InternsTestModels.Models.Data.Projects;

namespace Data.Interfaces
{
    public interface IProject_logs
    {
        public Task LogAsync(Project_log log);
    }
}
