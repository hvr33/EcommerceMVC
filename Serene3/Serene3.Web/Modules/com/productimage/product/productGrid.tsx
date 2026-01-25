import { EntityGrid } from '@serenity-is/corelib';
import { productColumns, productRow, productService } from '../../ServerTypes/com';
import { productDialog } from './productDialog';
import { ExcelExportHelper, PdfExportHelper } from '@serenity-is/extensions';

export class productGrid extends EntityGrid<productRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return productColumns.columnsKey; }
    protected getDialogType() { return productDialog; }
    protected getRowDefinition() { return productRow; }
    protected getService() { return productService.baseUrl; }
    protected getButtons() {
        let buttons = super.getButtons();

        // زر Excel
        buttons.push(ExcelExportHelper.createToolButton({
            grid: this,
            service: productService.baseUrl + '/ListExcel',
            onViewSubmit: () => this.onViewSubmit()
        }));

        // زر PDF
        buttons.push(PdfExportHelper.createToolButton({
            grid: this,
            onViewSubmit: () => this.onViewSubmit()
        }));

        return buttons;
    }

}