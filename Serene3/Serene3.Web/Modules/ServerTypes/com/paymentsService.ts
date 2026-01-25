import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { paymentsRow } from "./paymentsRow";

export namespace paymentsService {
    export const baseUrl = 'com/payments';

    export declare function Create(request: SaveRequest<paymentsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<paymentsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<paymentsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<paymentsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<paymentsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<paymentsRow>>;

    export const Methods = {
        Create: "com/payments/Create",
        Update: "com/payments/Update",
        Delete: "com/payments/Delete",
        Retrieve: "com/payments/Retrieve",
        List: "com/payments/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>paymentsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}