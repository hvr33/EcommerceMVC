import { initFormType, PrefixedContext, ServiceLookupEditor, StringEditor } from "@serenity-is/corelib";

export interface statesForm {
    Name: StringEditor;
    CountryId: ServiceLookupEditor;
}

export class statesForm extends PrefixedContext {
    static readonly formKey = 'com.states';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!statesForm.init) {
            statesForm.init = true;

            var w0 = StringEditor;
            var w1 = ServiceLookupEditor;

            initFormType(statesForm, [
                'Name', w0,
                'CountryId', w1
            ]);
        }
    }
}