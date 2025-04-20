using InternsTestModels.Models.Rabbit.Projects.Requests;
using MassTransit;
using BusinessLogic;

namespace Rabbit.Consumers.Projects
{
    public class CreateProjectConsumer : IConsumer<CreateProjectRequest>
    {
        private readonly ServiceManager serviceManager;
        public CreateProjectConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
        }
        public async Task Consume(ConsumeContext<CreateProjectRequest> context)
        {
            try
            {
                await serviceManager.Projects.CreateProjectAsync(context.Message.RequestData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
