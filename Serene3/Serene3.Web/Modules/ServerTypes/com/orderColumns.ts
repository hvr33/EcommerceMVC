import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { orderRow } from "./orderRow";

export interface orderColumns {
    Userid: Column<orderRow>;
    Name: Column<orderRow>;
    Phone: Column<orderRow>;
    Email: Column<orderRow>;
    Onlinepaid: Column<orderRow>;
    EntityDate: Column<orderRow>;
    CustomerName: Column<orderRow>;
    CountryName: Column<orderRow>;
    StateName: Column<orderRow>;
    CityName: Column<orderRow>;
    Address: Column<orderRow>;
    OrderDate: Column<orderRow>;
    Id: Column<orderRow>;
    Productid: Column<orderRow>;
}

export class orderColumns extends ColumnsBase<orderRow> {
    static readonly columnsKey = 'com.order';
    static readonly Fields = fieldsProxy<orderColumns>();
}