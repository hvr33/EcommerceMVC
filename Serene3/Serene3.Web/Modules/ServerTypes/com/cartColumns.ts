import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { cartRow } from "./cartRow";

export interface cartColumns {
    Id: Column<cartRow>;
    ProductidName: Column<cartRow>;
    Userid: Column<cartRow>;
    Photo: Column<cartRow>;
    Price: Column<cartRow>;
    Quntity: Column<cartRow>;
}

export class cartColumns extends ColumnsBase<cartRow> {
    static readonly columnsKey = 'com.cart';
    static readonly Fields = fieldsProxy<cartColumns>();
}