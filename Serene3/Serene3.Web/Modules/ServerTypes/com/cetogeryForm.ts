import { ImageUploadEditor, initFormType, PrefixedContext, StringEditor } from "@serenity-is/corelib";

export interface cetogeryForm {
    Name: StringEditor;
    Photos: ImageUploadEditor;
    Description: StringEditor;
}

export class cetogeryForm extends PrefixedContext {
    static readonly formKey = 'com.cetogery';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!cetogeryForm.init) {
            cetogeryForm.init = true;

            var w0 = StringEditor;
            var w1 = ImageUploadEditor;

            initFormType(cetogeryForm, [
                'Name', w0,
                'Photos', w1,
                'Description', w0
            ]);
        }
    }
}