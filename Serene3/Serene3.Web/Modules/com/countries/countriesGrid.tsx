import { EntityGrid } from '@serenity-is/corelib';
import { countriesColumns, countriesRow, countriesService } from '../../ServerTypes/com';
import { countriesDialog } from './countriesDialog';

export class countriesGrid extends EntityGrid<countriesRow> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return countriesColumns.columnsKey; }
    protected getDialogType() { return countriesDialog; }
    protected getRowDefinition() { return countriesRow; }
    protected getService() { return countriesService.baseUrl; }
}