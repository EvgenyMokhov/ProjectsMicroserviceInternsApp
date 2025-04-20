using InternsTestModels.Models.Rabbit.Projects.Requests;
using MassTransit;
using BusinessLogic;

namespace Rabbit.Consumers.Projects
{
    public class UpdateProjectConsumer : IConsumer<UpdateProjectRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public UpdateProjectConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
            serviceProvider = provider;
        }

        public async Task Consume(ConsumeContext<UpdateProjectRequest> context)
        {
            try
            {
                await serviceManager.Projects.UpdateProjectAsync(context.Message.RequestData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
