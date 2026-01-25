using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.statesRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.statesRow;

namespace Serene3.com;

public interface IstatesSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class statesSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IstatesSaveHandler
{
    public statesSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}