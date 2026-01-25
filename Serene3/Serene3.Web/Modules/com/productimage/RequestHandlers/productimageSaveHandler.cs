using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.productimageRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.productimageRow;

namespace Serene3.com;

public interface IproductimageSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class productimageSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IproductimageSaveHandler
{
    public productimageSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}