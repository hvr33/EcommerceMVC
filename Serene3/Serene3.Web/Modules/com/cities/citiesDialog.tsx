import { EntityDialog } from '@serenity-is/corelib';
import { citiesForm, citiesRow, citiesService } from '../../ServerTypes/com';

export class citiesDialog extends EntityDialog<citiesRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return citiesForm.formKey; }
    protected getRowDefinition() { return citiesRow; }
    protected getService() { return citiesService.baseUrl; }

    protected form = new citiesForm(this.idPrefix);
}