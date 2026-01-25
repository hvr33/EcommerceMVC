import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { paymentsRow } from "./paymentsRow";

export interface paymentsColumns {
    Id: Column<paymentsRow>;
    OrderUserid: Column<paymentsRow>;
    Provider: Column<paymentsRow>;
    ProviderPaymentId: Column<paymentsRow>;
    Amount: Column<paymentsRow>;
    Currency: Column<paymentsRow>;
    Status: Column<paymentsRow>;
    RawResponse: Column<paymentsRow>;
    CreatedAt: Column<paymentsRow>;
    UpdatedAt: Column<paymentsRow>;
}

export class paymentsColumns extends ColumnsBase<paymentsRow> {
    static readonly columnsKey = 'com.payments';
    static readonly Fields = fieldsProxy<paymentsColumns>();
}