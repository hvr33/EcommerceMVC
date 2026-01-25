using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.review2Row;

namespace Serene3.com;

public interface Ireview2DeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class review2DeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, Ireview2DeleteHandler
{
    public review2DeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}