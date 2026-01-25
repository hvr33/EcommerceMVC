import { EntityGrid } from '@serenity-is/corelib';
import { orderColumns, orderRow, orderService } from '../../ServerTypes/com';
import { orderDialog } from './orderDialog';

export class orderGrid extends EntityGrid<orderRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return orderColumns.columnsKey; }
    protected getDialogType() { return orderDialog; }
    protected getRowDefinition() { return orderRow; }
    protected getService() { return orderService.baseUrl; }
}