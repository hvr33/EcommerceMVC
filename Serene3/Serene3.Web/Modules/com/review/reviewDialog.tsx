import { EntityDialog } from '@serenity-is/corelib';
import { reviewForm, reviewRow, reviewService } from '../../ServerTypes/com';

export class reviewDialog extends EntityDialog<reviewRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return reviewForm.formKey; }
    protected getRowDefinition() { return reviewRow; }
    protected getService() { return reviewService.baseUrl; }

    protected form = new reviewForm(this.idPrefix);
}