using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("product")]
[DisplayName("Product"), InstanceName("Product")]
[ReadPermission("product")]
[ModifyPermission("product")]
[ServiceLookupPermission("product")]
public sealed class productRow : Row<productRow.RowFields>, IIdRow, INameRow
{
    const string jCeito = nameof(jCeito);

    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Name"), Column("name"), QuickSearch, NameProperty]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("Description"), Column("description")]
    public string Description { get => fields.Description[this]; set => fields.Description[this] = value; }

    [DisplayName("Price"), Column("price"), Size(18)]
    public decimal? Price { get => fields.Price[this]; set => fields.Price[this] = value; }

    [DisplayName("Ceito"), Column("ceito"), ForeignKey(typeof(cetogeryRow)), LeftJoin(jCeito), TextualField(nameof(CeitoName))]
    [ServiceLookupEditor(typeof(cetogeryRow))]
    public int? Ceito { get => fields.Ceito[this]; set => fields.Ceito[this] = value; }

    [DisplayName("Photo"), Column("photo"),ImageUploadEditor]
    public string Photo { get => fields.Photo[this]; set => fields.Photo[this] = value; }

    [DisplayName("Type"), Column("type")]
    public string Type { get => fields.Type[this]; set => fields.Type[this] = value; }

    [DisplayName("Siplername"), Column("siplername")]
    public string Siplername { get => fields.Siplername[this]; set => fields.Siplername[this] = value; }

    [DisplayName("Entitydata"), Column("entitydata")]
    public DateOnly? Entitydata { get => fields.Entitydata[this]; set => fields.Entitydata[this] = value; }

    [DisplayName("Reviewurl"), Column("reviewurl")]
    public string Reviewurl { get => fields.Reviewurl[this]; set => fields.Reviewurl[this] = value; }

    [DisplayName("Productquntity"), Column("productquntity")]
    public string Productquntity { get => fields.Productquntity[this]; set => fields.Productquntity[this] = value; }

    [DisplayName("Rating")]
    public double? Rating { get => fields.Rating[this]; set => fields.Rating[this] = value; }

    [DisplayName("Review Count")]
    public int? ReviewCount { get => fields.ReviewCount[this]; set => fields.ReviewCount[this] = value; }

    [DisplayName("Ceito Name"), Origin(jCeito, nameof(cetogeryRow.Name))]
    public string CeitoName { get => fields.CeitoName[this]; set => fields.CeitoName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public StringField Name;
        public StringField Description;
        public DecimalField Price;
        public Int32Field Ceito;
        public StringField Photo;
        public StringField Type;
        public StringField Siplername;
        public DateOnlyField Entitydata;
        public StringField Reviewurl;
        public StringField Productquntity;
        public DoubleField Rating;
        public Int32Field ReviewCount;

        public StringField CeitoName;
    }
}