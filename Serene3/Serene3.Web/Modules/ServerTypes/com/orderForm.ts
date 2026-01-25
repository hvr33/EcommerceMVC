import { BooleanEditor, DateEditor, initFormType, IntegerEditor, PrefixedContext, ServiceLookupEditor, StringEditor } from "@serenity-is/corelib";

export interface orderForm {
    Userid: StringEditor;
    Name: StringEditor;
    Phone: StringEditor;
    Email: StringEditor;
    Onlinepaid: BooleanEditor;
    EntityDate: StringEditor;
    CustomerName: StringEditor;
    CountryId: ServiceLookupEditor;
    StateId: ServiceLookupEditor;
    CityId: ServiceLookupEditor;
    Address: StringEditor;
    OrderDate: DateEditor;
    Productid: IntegerEditor;
}

export class orderForm extends PrefixedContext {
    static readonly formKey = 'com.order';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!orderForm.init) {
            orderForm.init = true;

            var w0 = StringEditor;
            var w1 = BooleanEditor;
            var w2 = ServiceLookupEditor;
            var w3 = DateEditor;
            var w4 = IntegerEditor;

            initFormType(orderForm, [
                'Userid', w0,
                'Name', w0,
                'Phone', w0,
                'Email', w0,
                'Onlinepaid', w1,
                'EntityDate', w0,
                'CustomerName', w0,
                'CountryId', w2,
                'StateId', w2,
                'CityId', w2,
                'Address', w0,
                'OrderDate', w3,
                'Productid', w4
            ]);
        }
    }
}