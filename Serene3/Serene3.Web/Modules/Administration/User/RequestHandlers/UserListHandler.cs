using MyRequest = Serene3.Administration.UserListRequest;
using MyResponse = Serenity.Services.ListResponse<Serene3.Administration.UserRow>;
using MyRow = Serene3.Administration.UserRow;

namespace Serene3.Administration;
public interface IUserListHandler : IListHandler<MyRow, MyRequest, MyResponse> { }

public class UserListHandler(IRequestContext context)
    : ListRequestHandler<MyRow, MyRequest, MyResponse>(context), IUserListHandler
{
}