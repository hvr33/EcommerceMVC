import { EntityGrid } from '@serenity-is/corelib';
import { orderdetialsColumns, orderdetialsRow, orderdetialsService } from '../../ServerTypes/com';
import { orderdetialsDialog } from './orderdetialsDialog';
import { ExcelExportHelper, PdfExportHelper } from '@serenity-is/extensions';

export class orderdetialsGrid extends EntityGrid<orderdetialsRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return orderdetialsColumns.columnsKey; }
    protected getDialogType() { return orderdetialsDialog; }
    protected getRowDefinition() { return orderdetialsRow; }
    protected getService() { return orderdetialsService.baseUrl; }

    protected getButtons() {
        let buttons = super.getButtons();

        // زر Excel
        buttons.push(ExcelExportHelper.createToolButton({
            grid: this,
            service: orderdetialsService.baseUrl + '/ListExcel',
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