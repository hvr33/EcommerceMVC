using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.review2Row>;
using MyRow = Serene3.com.review2Row;

namespace Serene3.com;

public interface Ireview2RetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class review2RetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, Ireview2RetrieveHandler
{
    public review2RetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}