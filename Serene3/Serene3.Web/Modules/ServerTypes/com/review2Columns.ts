import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { review2Row } from "./review2Row";

export interface review2Columns {
    Id: Column<review2Row>;
    ProductName: Column<review2Row>;
    Name: Column<review2Row>;
    Email: Column<review2Row>;
    Subject: Column<review2Row>;
    Description: Column<review2Row>;
    Rating: Column<review2Row>;
    CreatedAt: Column<review2Row>;
}

export class review2Columns extends ColumnsBase<review2Row> {
    static readonly columnsKey = 'com.review2';
    static readonly Fields = fieldsProxy<review2Columns>();
}