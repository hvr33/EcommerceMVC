using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.orderdetialsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.orderdetialsRow;

namespace Serene3.com;

public interface IorderdetialsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class orderdetialsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IorderdetialsSaveHandler
{
    public orderdetialsSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}