import { EntityDialog } from '@serenity-is/corelib';
import { orderdetialsForm, orderdetialsRow, orderdetialsService } from '../../ServerTypes/com';

export class orderdetialsDialog extends EntityDialog<orderdetialsRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return orderdetialsForm.formKey; }
    protected getRowDefinition() { return orderdetialsRow; }
    protected getService() { return orderdetialsService.baseUrl; }

    protected form = new orderdetialsForm(this.idPrefix);
}