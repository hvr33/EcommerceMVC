using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("Countries")]
[DisplayName("Countries"), InstanceName("Countries")]
[ReadPermission("countries")]
[ModifyPermission("countries")]
[ServiceLookupPermission("countries")]
public sealed class countriesRow : Row<countriesRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Name;

    }
}