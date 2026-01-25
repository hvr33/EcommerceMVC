using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.paymentsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.paymentsRow;

namespace Serene3.com;

public interface IpaymentsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class paymentsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IpaymentsSaveHandler
{
    public paymentsSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}