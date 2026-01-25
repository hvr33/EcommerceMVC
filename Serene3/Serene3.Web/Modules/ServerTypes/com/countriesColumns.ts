import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { countriesRow } from "./countriesRow";

export interface countriesColumns {
    Id: Column<countriesRow>;
    Name: Column<countriesRow>;
}

export class countriesColumns extends ColumnsBase<countriesRow> {
    static readonly columnsKey = 'com.countries';
    static readonly Fields = fieldsProxy<countriesColumns>();
}