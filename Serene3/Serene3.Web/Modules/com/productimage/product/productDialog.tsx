import { EntityDialog } from '@serenity-is/corelib';
import { productForm, productRow, productService } from '../../ServerTypes/com';

export class productDialog extends EntityDialog<productRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return productForm.formKey; }
    protected getRowDefinition() { return productRow; }
    protected getService() { return productService.baseUrl; }

    protected form = new productForm(this.idPrefix);
}