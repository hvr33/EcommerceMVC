import { fieldsProxy } from "@serenity-is/corelib";

export interface citiesRow {
    Id?: number;
    Name?: string;
    StateId?: number;
    StateName?: string;
}

export abstract class citiesRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'com.cities';
    static readonly deletePermission = 'cities';
    static readonly insertPermission = 'cities';
    static readonly readPermission = 'cities';
    static readonly updatePermission = 'cities';

    static readonly Fields = fieldsProxy<citiesRow>();
}