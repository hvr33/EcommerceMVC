import { EntityGrid } from '@serenity-is/corelib';
import { review2Columns, review2Row, review2Service } from '../../ServerTypes/com';
import { review2Dialog } from './review2Dialog';

export class review2Grid extends EntityGrid<review2Row> {
    static [Symbol.typeInfo] = this.registerClass("Serene3.com.");

    protected getColumnsKey() { return review2Columns.columnsKey; }
    protected getDialogType() { return review2Dialog; }
    protected getRowDefinition() { return review2Row; }
    protected getService() { return review2Service.baseUrl; }
}