using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.statesRow;

namespace Serene3.com;

public interface IstatesDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class statesDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IstatesDeleteHandler
{
    public statesDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}