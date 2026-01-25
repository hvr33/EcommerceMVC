import { EntityDialog } from '@serenity-is/corelib';
import { review2Form, review2Row, review2Service } from '../../ServerTypes/com';

export class review2Dialog extends EntityDialog<review2Row, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return review2Form.formKey; }
    protected getRowDefinition() { return review2Row; }
    protected getService() { return review2Service.baseUrl; }

    protected form = new review2Form(this.idPrefix);
}