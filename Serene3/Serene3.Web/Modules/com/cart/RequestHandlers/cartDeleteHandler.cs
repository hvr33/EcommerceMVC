using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.cartRow;

namespace Serene3.com;

public interface IcartDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class cartDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IcartDeleteHandler
{
    public cartDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}