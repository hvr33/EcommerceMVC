import { fieldsProxy } from "@serenity-is/corelib";

export interface productRow {
    Id?: number;
    Name?: string;
    Description?: string;
    Price?: number;
    Ceito?: number;
    Photo?: string;
    Type?: string;
    Siplername?: string;
    Entitydata?: string;
    Reviewurl?: string;
    Productquntity?: string;
    Rating?: number;
    ReviewCount?: number;
    CeitoName?: string;
}

export abstract class productRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'com.product';
    static readonly deletePermission = 'product';
    static readonly insertPermission = 'product';
    static readonly readPermission = 'product';
    static readonly updatePermission = 'product';

    static readonly Fields = fieldsProxy<productRow>();
}