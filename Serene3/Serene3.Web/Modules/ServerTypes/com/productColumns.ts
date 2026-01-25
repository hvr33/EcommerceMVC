import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { productRow } from "./productRow";

export interface productColumns {
    Id: Column<productRow>;
    Name: Column<productRow>;
    Description: Column<productRow>;
    Price: Column<productRow>;
    CeitoName: Column<productRow>;
    Photo: Column<productRow>;
    Type: Column<productRow>;
    Siplername: Column<productRow>;
    Entitydata: Column<productRow>;
    Reviewurl: Column<productRow>;
    Productquntity: Column<productRow>;
    Rating: Column<productRow>;
    ReviewCount: Column<productRow>;
}

export class productColumns extends ColumnsBase<productRow> {
    static readonly columnsKey = 'com.product';
    static readonly Fields = fieldsProxy<productColumns>();
}