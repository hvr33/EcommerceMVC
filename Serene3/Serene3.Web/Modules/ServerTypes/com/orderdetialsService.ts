import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { orderdetialsRow } from "./orderdetialsRow";

export namespace orderdetialsService {
    export const baseUrl = 'com/orderdetials';

    export declare function Create(request: SaveRequest<orderdetialsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<orderdetialsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<orderdetialsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<orderdetialsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<orderdetialsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<orderdetialsRow>>;

    export const Methods = {
        Create: "com/orderdetials/Create",
        Update: "com/orderdetials/Update",
        Delete: "com/orderdetials/Delete",
        Retrieve: "com/orderdetials/Retrieve",
        List: "com/orderdetials/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>orderdetialsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}