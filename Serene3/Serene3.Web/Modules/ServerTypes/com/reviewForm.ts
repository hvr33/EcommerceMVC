import { initFormType, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface reviewForm {
    Name: StringEditor;
    Email: StringEditor;
    Subject: StringEditor;
    Description: StringEditor;
}

export class reviewForm extends PrefixedContext {
    static readonly formKey = 'com.review';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!reviewForm.init) {
            reviewForm.init = true;

            var w0 = StringEditor;

            initFormType(reviewForm, [
                'Name', w0,
                'Email', w0,
                'Subject', w0,
                'Description', w0
            ]);
        }
    }
}