import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { countriesRow } from "./countriesRow";

export namespace countriesService {
    export const baseUrl = 'com/countries';

    export declare function Create(request: SaveRequest<countriesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<countriesRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<countriesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<countriesRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<countriesRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<countriesRow>>;

    export const Methods = {
        Create: "com/countries/Create",
        Update: "com/countries/Update",
        Delete: "com/countries/Delete",
        Retrieve: "com/countries/Retrieve",
        List: "com/countries/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>countriesService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}