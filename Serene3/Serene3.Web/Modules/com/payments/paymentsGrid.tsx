import { EntityGrid } from '@serenity-is/corelib';
import { paymentsColumns, paymentsRow, paymentsService } from '../../ServerTypes/com';
import { paymentsDialog } from './paymentsDialog';

export class paymentsGrid extends EntityGrid<paymentsRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return paymentsColumns.columnsKey; }
    protected getDialogType() { return paymentsDialog; }
    protected getRowDefinition() { return paymentsRow; }
    protected getService() { return paymentsService.baseUrl; }
}