import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { review2Row } from "./review2Row";

export namespace review2Service {
    export const baseUrl = 'com/review2';

    export declare function Create(request: SaveRequest<review2Row>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<review2Row>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<review2Row>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<review2Row>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<review2Row>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<review2Row>>;

    export const Methods = {
        Create: "com/review2/Create",
        Update: "com/review2/Update",
        Delete: "com/review2/Delete",
        Retrieve: "com/review2/Retrieve",
        List: "com/review2/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>review2Service)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}