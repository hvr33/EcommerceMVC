using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.countriesRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.countriesRow;

namespace Serene3.com;

public interface IcountriesSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class countriesSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IcountriesSaveHandler
{
    public countriesSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}