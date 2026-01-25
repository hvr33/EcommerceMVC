import { initFormType, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface countriesForm {
    Name: StringEditor;
}

export class countriesForm extends PrefixedContext {
    static readonly formKey = 'com.countries';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!countriesForm.init) {
            countriesForm.init = true;

            var w0 = StringEditor;

            initFormType(countriesForm, [
                'Name', w0
            ]);
        }
    }
}