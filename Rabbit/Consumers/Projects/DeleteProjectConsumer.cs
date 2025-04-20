using InternsTestModels.Models.Enums;
using InternsTestModels.Models.Rabbit.Projects.Requests;
using MassTransit;
using BusinessLogic;

namespace Rabbit.Consumers.Projects
{
    public class DeleteProjectConsumer : IConsumer<DeleteProjectRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public DeleteProjectConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
            serviceProvider = provider;
        }
        public async Task Consume(ConsumeContext<DeleteProjectRequest> context)
        {
            try
            {
                await serviceManager.Projects.DeleteProjectAsync(context.Message.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
