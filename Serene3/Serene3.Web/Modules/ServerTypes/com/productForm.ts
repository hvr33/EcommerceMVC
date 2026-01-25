import { DecimalEditor, ImageUploadEditor, initFormType, IntegerEditor, PrefixedContext, ServiceLookupEditor, StringEditor } from "@serenity-is/corelib";

export interface productForm {
    Name: StringEditor;
    Description: StringEditor;
    Price: DecimalEditor;
    Ceito: ServiceLookupEditor;
    Photo: ImageUploadEditor;
    Type: StringEditor;
    Siplername: StringEditor;
    Entitydata: StringEditor;
    Reviewurl: StringEditor;
    Productquntity: StringEditor;
    Rating: DecimalEditor;
    ReviewCount: IntegerEditor;
}

export class productForm extends PrefixedContext {
    static readonly formKey = 'com.product';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!productForm.init) {
            productForm.init = true;

            var w0 = StringEditor;
            var w1 = DecimalEditor;
            var w2 = ServiceLookupEditor;
            var w3 = ImageUploadEditor;
            var w4 = IntegerEditor;

            initFormType(productForm, [
                'Name', w0,
                'Description', w0,
                'Price', w1,
                'Ceito', w2,
                'Photo', w3,
                'Type', w0,
                'Siplername', w0,
                'Entitydata', w0,
                'Reviewurl', w0,
                'Productquntity', w0,
                'Rating', w1,
                'ReviewCount', w4
            ]);
        }
    }
}