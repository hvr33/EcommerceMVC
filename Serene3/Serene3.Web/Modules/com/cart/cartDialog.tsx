import { EntityDialog } from '@serenity-is/corelib';
import { cartForm, cartRow, cartService } from '../../ServerTypes/com';

export class cartDialog extends EntityDialog<cartRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return cartForm.formKey; }
    protected getRowDefinition() { return cartRow; }
    protected getService() { return cartService.baseUrl; }

    protected form = new cartForm(this.idPrefix);
}