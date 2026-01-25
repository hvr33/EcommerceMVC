import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { productimageRow } from "./productimageRow";

export namespace productimageService {
    export const baseUrl = 'com/productimage';

    export declare function Create(request: SaveRequest<productimageRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<productimageRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<productimageRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<productimageRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<productimageRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<productimageRow>>;

    export const Methods = {
        Create: "com/productimage/Create",
        Update: "com/productimage/Update",
        Delete: "com/productimage/Delete",
        Retrieve: "com/productimage/Retrieve",
        List: "com/productimage/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>productimageService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}