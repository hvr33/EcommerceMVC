import { EntityDialog } from '@serenity-is/corelib';
import { orderForm, orderRow, orderService } from '../../ServerTypes/com';

export class orderDialog extends EntityDialog<orderRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return orderForm.formKey; }
    protected getRowDefinition() { return orderRow; }
    protected getService() { return orderService.baseUrl; }

    protected form = new orderForm(this.idPrefix);
}