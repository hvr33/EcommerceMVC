import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { reviewRow } from "./reviewRow";

export namespace reviewService {
    export const baseUrl = 'com/review';

    export declare function Create(request: SaveRequest<reviewRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<reviewRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<reviewRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<reviewRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<reviewRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<reviewRow>>;

    export const Methods = {
        Create: "com/review/Create",
        Update: "com/review/Update",
        Delete: "com/review/Delete",
        Retrieve: "com/review/Retrieve",
        List: "com/review/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>reviewService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}