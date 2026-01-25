using Serenity.Services;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = Serene3.com.cetogeryRow;

namespace Serene3.com;

public interface IcetogeryDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> { }

public class cetogeryDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IcetogeryDeleteHandler
{
    public cetogeryDeleteHandler(IRequestContext context)
            : base(context)
    {
    }
}