using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.orderRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.orderRow;

namespace Serene3.com;

public interface IorderSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class orderSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IorderSaveHandler
{
    public orderSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}