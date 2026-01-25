import { EntityDialog } from '@serenity-is/corelib';
import { countriesForm, countriesRow, countriesService } from '../../ServerTypes/com';

export class countriesDialog extends EntityDialog<countriesRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return countriesForm.formKey; }
    protected getRowDefinition() { return countriesRow; }
    protected getService() { return countriesService.baseUrl; }

    protected form = new countriesForm(this.idPrefix);
}