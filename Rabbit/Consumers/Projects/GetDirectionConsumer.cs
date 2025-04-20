using InternsTestModels.Models.Rabbit.Projects.Requests;
using InternsTestModels.Models.Rabbit.Projects.Responses;
using MassTransit;
using BusinessLogic;
namespace Rabbit.Consumers.Projects
{
    public class GetProjectConsumer : IConsumer<GetProjectRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public GetProjectConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
            serviceProvider = provider;
        }

        public async Task Consume(ConsumeContext<GetProjectRequest> context)
        {
            try
            {
                GetProjectResponse response = new() { ResponseData = await serviceManager.Projects.GetProjectAsync(context.Message.Id) };
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
