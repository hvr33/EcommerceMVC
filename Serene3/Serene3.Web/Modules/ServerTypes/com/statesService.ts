import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { statesRow } from "./statesRow";

export namespace statesService {
    export const baseUrl = 'com/states';

    export declare function Create(request: SaveRequest<statesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<statesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<statesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<statesRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<statesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<statesRow>>;

    export const Methods = {
        Create: "com/states/Create",
        Update: "com/states/Update",
        Delete: "com/states/Delete",
        Retrieve: "com/states/Retrieve",
        List: "com/states/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>statesService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}