import { DecimalEditor, initFormType, IntegerEditor, PrefixedContext, ServiceLookupEditor, StringEditor } from "@serenity-is/corelib";

export interface orderdetialsForm {
    Productid: ServiceLookupEditor;
    Totalprice: DecimalEditor;
    Quantity: IntegerEditor;
    Orderid: ServiceLookupEditor;
    Price: DecimalEditor;
    Entitydata: StringEditor;
}

export class orderdetialsForm extends PrefixedContext {
    static readonly formKey = 'com.orderdetials';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!orderdetialsForm.init) {
            orderdetialsForm.init = true;

            var w0 = ServiceLookupEditor;
            var w1 = DecimalEditor;
            var w2 = IntegerEditor;
            var w3 = StringEditor;

            initFormType(orderdetialsForm, [
                'Productid', w0,
                'Totalprice', w1,
                'Quantity', w2,
                'Orderid', w0,
                'Price', w1,
                'Entitydata', w3
            ]);
        }
    }
}