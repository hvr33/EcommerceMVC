import { EntityDialog } from '@serenity-is/corelib';
import { paymentsForm, paymentsRow, paymentsService } from '../../ServerTypes/com';

export class paymentsDialog extends EntityDialog<paymentsRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return paymentsForm.formKey; }
    protected getRowDefinition() { return paymentsRow; }
    protected getService() { return paymentsService.baseUrl; }

    protected form = new paymentsForm(this.idPrefix);
}