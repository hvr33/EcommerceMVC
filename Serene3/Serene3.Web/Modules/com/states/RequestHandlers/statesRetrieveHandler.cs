using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.statesRow>;
using MyRow = Serene3.com.statesRow;

namespace Serene3.com;

public interface IstatesRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class statesRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IstatesRetrieveHandler
{
    public statesRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}