import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { citiesRow } from "./citiesRow";

export namespace citiesService {
    export const baseUrl = 'com/cities';

    export declare function Create(request: SaveRequest<citiesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<citiesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<citiesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<citiesRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<citiesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<citiesRow>>;

    export const Methods = {
        Create: "com/cities/Create",
        Update: "com/cities/Update",
        Delete: "com/cities/Delete",
        Retrieve: "com/cities/Retrieve",
        List: "com/cities/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>citiesService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}