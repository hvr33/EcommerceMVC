import { DateEditor, DecimalEditor, initFormType, PrefixedContext, ServiceLookupEditor, StringEditor } from "@serenity-is/corelib";

export interface paymentsForm {
    OrderId: ServiceLookupEditor;
    Provider: StringEditor;
    ProviderPaymentId: StringEditor;
    Amount: DecimalEditor;
    Currency: StringEditor;
    Status: StringEditor;
    RawResponse: StringEditor;
    CreatedAt: DateEditor;
    UpdatedAt: DateEditor;
}

export class paymentsForm extends PrefixedContext {
    static readonly formKey = 'com.payments';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!paymentsForm.init) {
            paymentsForm.init = true;

            var w0 = ServiceLookupEditor;
            var w1 = StringEditor;
            var w2 = DecimalEditor;
            var w3 = DateEditor;

            initFormType(paymentsForm, [
                'OrderId', w0,
                'Provider', w1,
                'ProviderPaymentId', w1,
                'Amount', w2,
                'Currency', w1,
                'Status', w1,
                'RawResponse', w1,
                'CreatedAt', w3,
                'UpdatedAt', w3
            ]);
        }
    }
}