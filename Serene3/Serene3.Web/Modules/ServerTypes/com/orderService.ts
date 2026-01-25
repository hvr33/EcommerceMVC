import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { orderRow } from "./orderRow";

export namespace orderService {
    export const baseUrl = 'com/order';

    export declare function Create(request: SaveRequest<orderRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<orderRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<orderRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<orderRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<orderRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<orderRow>>;

    export const Methods = {
        Create: "com/order/Create",
        Update: "com/order/Update",
        Delete: "com/order/Delete",
        Retrieve: "com/order/Retrieve",
        List: "com/order/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>orderService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}