using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("cetogery")]
[DisplayName("Cetogery"), InstanceName("Cetogery")]
[ReadPermission("cetogery")]
[ModifyPermission("cetogery")]
[ServiceLookupPermission("cetogery")]
public sealed class cetogeryRow : Row<cetogeryRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Name"), Column("name"), QuickSearch, NameProperty]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("Photos"), Column("photos"),ImageUploadEditor,MultipleImageUploadEditor]
    public string Photos { get => fields.Photos[this]; set => fields.Photos[this] = value; }

    [DisplayName("Description"), Column("description")]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Name;
        public StringField Photos;
        public StringField Description;

    }
}