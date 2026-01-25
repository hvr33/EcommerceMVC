import { fieldsProxy } from "@serenity-is/corelib";

export interface orderdetialsRow {
    Id?: number;
    Productid?: number;
    Totalprice?: number;
    Quantity?: number;
    Orderid?: number;
    Price?: number;
    Entitydata?: string;
    ProductidName?: string;
    OrderidUserid?: string;
}

export abstract class orderdetialsRow {
    static readonly idProperty = 'Id';
    static readonly localTextPrefix = 'com.orderdetials';
    static readonly deletePermission = 'orderdetiaals';
    static readonly insertPermission = 'orderdetiaals';
    static readonly readPermission = 'orderdetiaals';
    static readonly updatePermission = 'orderdetiaals';

    static readonly Fields = fieldsProxy<orderdetialsRow>();
}