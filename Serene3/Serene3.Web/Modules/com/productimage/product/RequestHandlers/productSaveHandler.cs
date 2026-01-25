using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.productRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.productRow;

namespace Serene3.com;

public interface IproductSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class productSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IproductSaveHandler
{
    public productSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}