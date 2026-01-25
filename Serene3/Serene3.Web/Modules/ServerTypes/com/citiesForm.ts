import { initFormType, PrefixedContext, ServiceLookupEditor, StringEditor } from "@serenity-is/corelib";

export interface citiesForm {
    Name: StringEditor;
    StateId: ServiceLookupEditor;
}

export class citiesForm extends PrefixedContext {
    static readonly formKey = 'com.cities';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!citiesForm.init) {
            citiesForm.init = true;

            var w0 = StringEditor;
            var w1 = ServiceLookupEditor;

            initFormType(citiesForm, [
                'Name', w0,
                'StateId', w1
            ]);
        }
    }
}