import { EntityGrid } from '@serenity-is/corelib';
import { productimageColumns, productimageRow, productimageService } from '../../ServerTypes/com';
import { productimageDialog } from './productimageDialog';

export class productimageGrid extends EntityGrid<productimageRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return productimageColumns.columnsKey; }
    protected getDialogType() { return productimageDialog; }
    protected getRowDefinition() { return productimageRow; }
    protected getService() { return productimageService.baseUrl; }
}