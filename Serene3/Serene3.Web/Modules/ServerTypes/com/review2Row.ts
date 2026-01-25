import { fieldsProxy } from "@serenity-is/corelib";

export interface review2Row {
    Id?: number;
    ProductId?: number;
    Name?: string;
    Email?: string;
    Subject?: string;
    Description?: string;
    Rating?: number;
    CreatedAt?: string;
    ProductName?: string;
}

export abstract class review2Row {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'com.review2';
    static readonly deletePermission = 'review2';
    static readonly insertPermission = 'review2';
    static readonly readPermission = 'review2';
    static readonly updatePermission = 'review2';

    static readonly Fields = fieldsProxy<review2Row>();
}