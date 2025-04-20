using InternsTestModels.Models.Enums;
using InternsTestModels.Models.Rabbit.Projects.Requests;
using InternsTestModels.Models.Rabbit.Projects.Responses;
using MassTransit;
using BusinessLogic;

namespace Rabbit.Consumers.Projects
{
    public class GetAllProjectsConsumer : IConsumer<GetAllProjectsRequest>
    {
        private readonly ServiceManager serviceManager;
        private readonly IServiceProvider serviceProvider;
        public GetAllProjectsConsumer(IServiceProvider provider)
        {
            serviceManager = new(provider);
            serviceProvider = provider;
        }

        public async Task Consume(ConsumeContext<GetAllProjectsRequest> context)
        {
            try
            {
                GetAllProjectsResponse response = new() { ResponseData = await serviceManager.Projects.GetAllProjectAsync() };
                await context.RespondAsync(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
