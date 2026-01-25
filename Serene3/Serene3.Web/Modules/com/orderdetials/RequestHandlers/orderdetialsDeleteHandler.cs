using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.orderdetialsRow;

namespace Serene3.com;

public interface IorderdetialsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class orderdetialsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IorderdetialsDeleteHandler
{
    public orderdetialsDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}