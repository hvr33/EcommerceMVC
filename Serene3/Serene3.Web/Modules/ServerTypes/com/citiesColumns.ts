import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { citiesRow } from "./citiesRow";

export interface citiesColumns {
    Id: Column<citiesRow>;
    Name: Column<citiesRow>;
    StateName: Column<citiesRow>;
}

export class citiesColumns extends ColumnsBase<citiesRow> {
    static readonly columnsKey = 'com.cities';
    static readonly Fields = fieldsProxy<citiesColumns>();
}