using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.productimageRow;

namespace Serene3.com;

public interface IproductimageDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class productimageDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IproductimageDeleteHandler
{
    public productimageDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}