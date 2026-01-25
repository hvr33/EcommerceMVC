using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.reviewRow;

namespace Serene3.com;

public interface IreviewDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class reviewDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IreviewDeleteHandler
{
    public reviewDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}