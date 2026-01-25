using Serenity.Services;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<Serene3.com.reviewRow>;
using MyRow = Serene3.com.reviewRow;

namespace Serene3.com;

public interface IreviewRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> { }

public class reviewRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IreviewRetrieveHandler
{
    public reviewRetrieveHandler(IRequestContext context)
            : base(context)
    {
    }
}