import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { productimageRow } from "./productimageRow";

export interface productimageColumns {
    Id: Column<productimageRow>;
    ProductidName: Column<productimageRow>;
    Image: Column<productimageRow>;
}

export class productimageColumns extends ColumnsBase<productimageRow> {
    static readonly columnsKey = 'com.productimage';
    static readonly Fields = fieldsProxy<productimageColumns>();
}