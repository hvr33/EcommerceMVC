import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { cetogeryRow } from "./cetogeryRow";

export namespace cetogeryService {
    export const baseUrl = 'com/cetogery';

    export declare function Create(request: SaveRequest<cetogeryRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<cetogeryRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<cetogeryRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<cetogeryRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<cetogeryRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<cetogeryRow>>;

    export const Methods = {
        Create: "com/cetogery/Create",
        Update: "com/cetogery/Update",
        Delete: "com/cetogery/Delete",
        Retrieve: "com/cetogery/Retrieve",
        List: "com/cetogery/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>cetogeryService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}