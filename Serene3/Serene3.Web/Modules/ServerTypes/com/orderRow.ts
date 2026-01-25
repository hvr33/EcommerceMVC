import { fieldsProxy } from "@serenity-is/corelib";

export interface orderRow {
    Userid?: string;
    Name?: string;
    Phone?: string;
    Email?: string;
    Onlinepaid?: boolean;
    EntityDate?: string;
    CustomerName?: string;
    CountryId?: number;
    StateId?: number;
    CityId?: number;
    Address?: string;
    OrderDate?: string;
    Id?: number;
    Productid?: number;
    CountryName?: string;
    StateName?: string;
    CityName?: string;
}

export abstract class orderRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Userid';
    static readonly localTextPrefix = 'com.order';
    static readonly deletePermission = 'order';
    static readonly insertPermission = 'order';
    static readonly readPermission = 'order';
    static readonly updatePermission = 'order';

    static readonly Fields = fieldsProxy<orderRow>();
}