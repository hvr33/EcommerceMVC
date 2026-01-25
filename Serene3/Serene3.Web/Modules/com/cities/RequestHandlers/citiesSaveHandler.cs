using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene3.com.citiesRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene3.com.citiesRow;

namespace Serene3.com;

public interface IcitiesSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class citiesSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IcitiesSaveHandler
{
    public citiesSaveHandler(IRequestContext context)
            : base(context)
    {
    }
}