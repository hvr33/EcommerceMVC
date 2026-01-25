import { DateEditor, initFormType, IntegerEditor, PrefixedContext, ServiceLookupEditor, StringEditor } from "@serenity-is/corelib";

export interface review2Form {
    ProductId: ServiceLookupEditor;
    Name: StringEditor;
    Email: StringEditor;
    Subject: StringEditor;
    Description: StringEditor;
    Rating: IntegerEditor;
    CreatedAt: DateEditor;
}

export class review2Form extends PrefixedContext {
    static readonly formKey = 'com.review2';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!review2Form.init) {
            review2Form.init = true;

            var w0 = ServiceLookupEditor;
            var w1 = StringEditor;
            var w2 = IntegerEditor;
            var w3 = DateEditor;

            initFormType(review2Form, [
                'ProductId', w0,
                'Name', w1,
                'Email', w1,
                'Subject', w1,
                'Description', w1,
                'Rating', w2,
                'CreatedAt', w3
            ]);
        }
    }
}