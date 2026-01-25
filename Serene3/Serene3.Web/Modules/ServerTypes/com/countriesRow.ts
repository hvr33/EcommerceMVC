import { fieldsProxy } from "@serenity-is/corelib";

export interface countriesRow {
    Id?: number;
    Name?: string;
}

export abstract class countriesRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'com.countries';
    static readonly deletePermission = 'countries';
    static readonly insertPermission = 'countries';
    static readonly readPermission = 'countries';
    static readonly updatePermission = 'countries';

    static readonly Fields = fieldsProxy<countriesRow>();
}