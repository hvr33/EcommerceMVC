import { fieldsProxy } from "@serenity-is/corelib";

export interface cetogeryRow {
    Id?: number;
    Name?: string;
    Photos?: string;
    Description?: string;
}

export abstract class cetogeryRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'com.cetogery';
    static readonly deletePermission = 'cetogery';
    static readonly insertPermission = 'cetogery';
    static readonly readPermission = 'cetogery';
    static readonly updatePermission = 'cetogery';

    static readonly Fields = fieldsProxy<cetogeryRow>();
}