import { fieldsProxy } from "@serenity-is/corelib";

export interface statesRow {
    Id?: number;
    Name?: string;
    CountryId?: number;
    CountryName?: string;
}

export abstract class statesRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'com.states';
    static readonly deletePermission = 'states';
    static readonly insertPermission = 'states';
    static readonly readPermission = 'states';
    static readonly updatePermission = 'states';

    static readonly Fields = fieldsProxy<statesRow>();
}