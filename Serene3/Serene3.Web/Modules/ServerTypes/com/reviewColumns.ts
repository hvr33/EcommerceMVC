import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { reviewRow } from "./reviewRow";

export interface reviewColumns {
    Id: Column<reviewRow>;
    Name: Column<reviewRow>;
    Email: Column<reviewRow>;
    Subject: Column<reviewRow>;
    Description: Column<reviewRow>;
}

export class reviewColumns extends ColumnsBase<reviewRow> {
    static readonly columnsKey = 'com.review';
    static readonly Fields = fieldsProxy<reviewColumns>();
}