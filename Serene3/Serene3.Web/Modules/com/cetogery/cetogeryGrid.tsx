import { EntityGrid } from '@serenity-is/corelib';
import { cetogeryColumns, cetogeryRow, cetogeryService } from '../../ServerTypes/com';
import { cetogeryDialog } from './cetogeryDialog';
import { ExcelExportHelper, PdfExportHelper } from '@serenity-is/extensions';

export class cetogeryGrid extends EntityGrid<cetogeryRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return cetogeryColumns.columnsKey; }
    protected getDialogType() { return cetogeryDialog; }
    protected getRowDefinition() { return cetogeryRow; }
    protected getService() { return cetogeryService.baseUrl; }
    protected getButtons() {
        let buttons = super.getButtons();

        // زر Excel
        buttons.push(ExcelExportHelper.createToolButton({
            grid: this,
            service: cetogeryService.baseUrl + '/ListExcel',
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
