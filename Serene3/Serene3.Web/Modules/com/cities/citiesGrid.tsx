import { EntityGrid } from '@serenity-is/corelib';
import { citiesColumns, citiesRow, citiesService } from '../../ServerTypes/com';
import { citiesDialog } from './citiesDialog';

export class citiesGrid extends EntityGrid<citiesRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return citiesColumns.columnsKey; }
    protected getDialogType() { return citiesDialog; }
    protected getRowDefinition() { return citiesRow; }
    protected getService() { return citiesService.baseUrl; }
}