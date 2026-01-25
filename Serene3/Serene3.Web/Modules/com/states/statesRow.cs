using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("States")]
[DisplayName("States"), InstanceName("States")]
[ReadPermission("states")]
[ModifyPermission("states")]
[ServiceLookupPermission("states")]
public sealed class statesRow : Row<statesRow.RowFields>, IIdRow, INameRow
{
    const string jCountry = nameof(jCountry);

    [DisplayName("Id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Name"), Size(100), NotNull, QuickSearch, NameProperty]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("Country"), NotNull, ForeignKey(typeof(countriesRow)), LeftJoin(jCountry), TextualField(nameof(CountryName))]
    [ServiceLookupEditor(typeof(countriesRow))]
    public int? CountryId { get => fields.CountryId[this]; set => fields.CountryId[this] = value; }

    [DisplayName("Country Name"), Origin(jCountry, nameof(countriesRow.Name))]
    public string CountryName { get => fields.CountryName[this]; set => fields.CountryName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Name;
        public Int32Field CountryId;

        public StringField CountryName;
    }
}