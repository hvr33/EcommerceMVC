import { EntityGrid } from '@serenity-is/corelib';
import { reviewColumns, reviewRow, reviewService } from '../../ServerTypes/com';
import { reviewDialog } from './reviewDialog';

export class reviewGrid extends EntityGrid<reviewRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return reviewColumns.columnsKey; }
    protected getDialogType() { return reviewDialog; }
    protected getRowDefinition() { return reviewRow; }
    protected getService() { return reviewService.baseUrl; }
}