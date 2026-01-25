import { fieldsProxy } from "@serenity-is/corelib";

export interface reviewRow {
    Id?: number;
    Name?: string;
    Email?: string;
    Subject?: string;
    Description?: string;
}

export abstract class reviewRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'com.review';
    static readonly deletePermission = 'review';
    static readonly insertPermission = 'review';
    static readonly readPermission = 'review';
    static readonly updatePermission = 'review';

    static readonly Fields = fieldsProxy<reviewRow>();
}