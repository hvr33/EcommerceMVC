using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("review")]
[DisplayName("Review"), InstanceName("Review")]
[ReadPermission("review")]
[ModifyPermission("review")]
[ServiceLookupPermission("review")]
public sealed class reviewRow : Row<reviewRow.RowFields>, IIdRow, INameRow
{
    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Name"), Column("name"), QuickSearch, NameProperty]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("Email"), Column("email")]
    public string Email { get => fields.Email[this]; set => fields.Email[this] = value; }

    [DisplayName("Subject"), Column("subject")]
    public string Subject { get => fields.Subject[this]; set => fields.Subject[this] = value; }

    [DisplayName("Description"), Column("description")]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Name;
        public StringField Email;
        public StringField Subject;
        public StringField Description;

    }
}