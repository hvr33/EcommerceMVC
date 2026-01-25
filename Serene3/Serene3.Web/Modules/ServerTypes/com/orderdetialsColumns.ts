import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { orderdetialsRow } from "./orderdetialsRow";

export interface orderdetialsColumns {
    Id: Column<orderdetialsRow>;
    ProductidName: Column<orderdetialsRow>;
    Totalprice: Column<orderdetialsRow>;
    Quantity: Column<orderdetialsRow>;
    OrderidUserid: Column<orderdetialsRow>;
    Price: Column<orderdetialsRow>;
    Entitydata: Column<orderdetialsRow>;
}

export class orderdetialsColumns extends ColumnsBase<orderdetialsRow> {
    static readonly columnsKey = 'com.orderdetials';
    static readonly Fields = fieldsProxy<orderdetialsColumns>();
}