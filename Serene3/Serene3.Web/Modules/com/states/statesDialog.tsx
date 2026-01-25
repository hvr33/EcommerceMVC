import { EntityDialog } from '@serenity-is/corelib';
import { statesForm, statesRow, statesService } from '../../ServerTypes/com';

export class statesDialog extends EntityDialog<statesRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return statesForm.formKey; }
    protected getRowDefinition() { return statesRow; }
    protected getService() { return statesService.baseUrl; }

    protected form = new statesForm(this.idPrefix);
}