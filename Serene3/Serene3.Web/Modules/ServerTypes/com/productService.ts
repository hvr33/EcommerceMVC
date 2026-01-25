import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { productRow } from "./productRow";

export namespace productService {
    export const baseUrl = 'com/product';

    export declare function Create(request: SaveRequest<productRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<productRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<productRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<productRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<productRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<productRow>>;

    export const Methods = {
        Create: "com/product/Create",
        Update: "com/product/Update",
        Delete: "com/product/Delete",
        Retrieve: "com/product/Retrieve",
        List: "com/product/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>productService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}