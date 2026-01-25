import { ImageUploadEditor, initFormType, PrefixedContext, ServiceLookupEditor } from "@serenity-is/corelib";

export interface productimageForm {
    Productid: ServiceLookupEditor;
    Image: ImageUploadEditor;
}

export class productimageForm extends PrefixedContext {
    static readonly formKey = 'com.productimage';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!productimageForm.init) {
            productimageForm.init = true;

            var w0 = ServiceLookupEditor;
            var w1 = ImageUploadEditor;

            initFormType(productimageForm, [
                'Productid', w0,
                'Image', w1
            ]);
        }
    }
}