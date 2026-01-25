import { DecimalEditor, initFormType, IntegerEditor, PrefixedContext, ServiceLookupEditor, StringEditor } from "@serenity-is/corelib";

export interface cartForm {
    Productid: ServiceLookupEditor;
    Userid: StringEditor;
    Photo: StringEditor;
    Price: DecimalEditor;
    Quntity: IntegerEditor;
}

export class cartForm extends PrefixedContext {
    static readonly formKey = 'com.cart';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!cartForm.init) {
            cartForm.init = true;

            var w0 = ServiceLookupEditor;
            var w1 = StringEditor;
            var w2 = DecimalEditor;
            var w3 = IntegerEditor;

            initFormType(cartForm, [
                'Productid', w0,
                'Userid', w1,
                'Photo', w1,
                'Price', w2,
                'Quntity', w3
            ]);
        }
    }
}