using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.orderRow;

namespace Serene3.com;

public interface IorderDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class orderDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IorderDeleteHandler
{
    public orderDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}