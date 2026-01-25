import { fieldsProxy } from "@serenity-is/corelib";

export interface paymentsRow {
    Id?: number;
    OrderId?: number;
    Provider?: string;
    ProviderPaymentId?: string;
    Amount?: number;
    Currency?: string;
    Status?: string;
    RawResponse?: string;
    CreatedAt?: string;
    UpdatedAt?: string;
    OrderUserid?: string;
}

export abstract class paymentsRow {
    static readonly idProperty = 'Id';
    static readonly nameProperty = 'Provider';
    static readonly localTextPrefix = 'com.payments';
    static readonly deletePermission = 'payments';
    static readonly insertPermission = 'payments';
    static readonly readPermission = 'payments';
    static readonly updatePermission = 'payments';

    static readonly Fields = fieldsProxy<paymentsRow>();
}