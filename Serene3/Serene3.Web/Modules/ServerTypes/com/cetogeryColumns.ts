import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { cetogeryRow } from "./cetogeryRow";

export interface cetogeryColumns {
    Id: Column<cetogeryRow>;
    Name: Column<cetogeryRow>;
    Photos: Column<cetogeryRow>;
    Description: Column<cetogeryRow>;
}

export class cetogeryColumns extends ColumnsBase<cetogeryRow> {
    static readonly columnsKey = 'com.cetogery';
    static readonly Fields = fieldsProxy<cetogeryColumns>();
}