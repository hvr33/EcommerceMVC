using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.productRow;

namespace Serene3.com;

public interface IproductDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class productDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IproductDeleteHandler
{
    public productDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}