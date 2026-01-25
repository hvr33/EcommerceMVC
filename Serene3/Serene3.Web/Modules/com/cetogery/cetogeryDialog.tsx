import { EntityDialog } from '@serenity-is/corelib';
import { cetogeryForm, cetogeryRow, cetogeryService } from '../../ServerTypes/com';

export class cetogeryDialog extends EntityDialog<cetogeryRow, any> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getFormKey() { return cetogeryForm.formKey; }
    protected getRowDefinition() { return cetogeryRow; }
    protected getService() { return cetogeryService.baseUrl; }

    protected form = new cetogeryForm(this.idPrefix);
}