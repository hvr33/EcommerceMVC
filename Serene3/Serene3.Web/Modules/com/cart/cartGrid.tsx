import { EntityGrid } from '@serenity-is/corelib';
import { cartColumns, cartRow, cartService } from '../../ServerTypes/com';
import { cartDialog } from './cartDialog';

export class cartGrid extends EntityGrid<cartRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return cartColumns.columnsKey; }
    protected getDialogType() { return cartDialog; }
    protected getRowDefinition() { return cartRow; }
    protected getService() { return cartService.baseUrl; }
}