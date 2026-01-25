import { EntityGrid } from '@serenity-is/corelib';
import { statesColumns, statesRow, statesService } from '../../ServerTypes/com';
import { statesDialog } from './statesDialog';

export class statesGrid extends EntityGrid<statesRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return statesColumns.columnsKey; }
    protected getDialogType() { return statesDialog; }
    protected getRowDefinition() { return statesRow; }
    protected getService() { return statesService.baseUrl; }
}