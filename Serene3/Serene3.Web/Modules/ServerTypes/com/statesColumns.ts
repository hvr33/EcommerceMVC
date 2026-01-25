import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { statesRow } from "./statesRow";

export interface statesColumns {
    Id: Column<statesRow>;
    Name: Column<statesRow>;
    CountryName: Column<statesRow>;
}

export class statesColumns extends ColumnsBase<statesRow> {
    static readonly columnsKey = 'com.states';
    static readonly Fields = fieldsProxy<statesColumns>();
}