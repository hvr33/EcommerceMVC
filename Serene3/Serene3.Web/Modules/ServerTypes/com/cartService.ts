import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { cartRow } from "./cartRow";

export namespace cartService {
    export const baseUrl = 'com/cart';

    export declare function Create(request: SaveRequest<cartRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<cartRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<cartRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<cartRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<cartRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<cartRow>>;

    export const Methods = {
        Create: "com/cart/Create",
        Update: "com/cart/Update",
        Delete: "com/cart/Delete",
        Retrieve: "com/cart/Retrieve",
        List: "com/cart/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>cartService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}