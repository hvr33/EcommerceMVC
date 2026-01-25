import { fieldsProxy } from "@serenity-is/corelib";

export interface cartRow {
    Id?: number;
    Productid?: number;
    Userid?: string;
    Photo?: string;
    Price?: number;
    Quntity?: number;
    ProductidName?: string;
}

export abstract class cartRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Userid';
    static readonly localTextPrefix = 'com.cart';
    static readonly deletePermission = 'cart';
    static readonly insertPermission = 'cart';
    static readonly readPermission = 'cart';
    static readonly updatePermission = 'cart';

    static readonly Fields = fieldsProxy<cartRow>();
}