using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("Cities")]
[DisplayName("Cities"), InstanceName("Cities")]
[ReadPermission("cities")]
[ModifyPermission("cities")]
[ServiceLookupPermission("cities")]
public sealed class citiesRow : Row<citiesRow.RowFields>, IIdRow, INameRow
{
    const string jState = nameof(jState);

    [DisplayName("Id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("State"), NotNull, ForeignKey(typeof(statesRow)), LeftJoin(jState), TextualField(nameof(StateName))]
    [ServiceLookupEditor(typeof(statesRow))]
    public int? StateId { get => fields.StateId[this]; set => fields.StateId[this] = value; }

    [DisplayName("State Name"), Origin(jState, nameof(statesRow.Name))]
    public string StateName { get => fields.StateName[this]; set => fields.StateName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Name;
        public Int32Field StateId;

        public StringField StateName;
    }
}