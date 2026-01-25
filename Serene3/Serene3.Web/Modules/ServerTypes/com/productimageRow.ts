import { fieldsProxy } from "@serenity-is/corelib";

export interface productimageRow {
    Id?: number;
    Productid?: number;
    Image?: string;
    ProductidName?: string;
}

export abstract class productimageRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Image';
    static readonly localTextPrefix = 'com.productimage';
    static readonly deletePermission = 'productimage';
    static readonly insertPermission = 'productimage';
    static readonly readPermission = 'productimage';
    static readonly updatePermission = 'productimage';

    static readonly Fields = fieldsProxy<productimageRow>();
}