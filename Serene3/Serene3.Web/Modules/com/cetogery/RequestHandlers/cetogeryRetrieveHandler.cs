using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.cetogeryRow>;
using MyRow = Serene3.com.cetogeryRow;

namespace Serene3.com;

public interface IcetogeryRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class cetogeryRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IcetogeryRetrieveHandler
{
    public cetogeryRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}