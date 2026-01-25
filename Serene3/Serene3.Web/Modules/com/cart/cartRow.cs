using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("cart")]
[DisplayName("Cart"), InstanceName("Cart")]
[ReadPermission("cart")]
[ModifyPermission("cart")]
[ServiceLookupPermission("cart")]
public sealed class cartRow : Row<cartRow.RowFields>, IIdRow, INameRow
{
    const string jProductid = nameof(jProductid);

    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Productid"), Column("productid"), ForeignKey(typeof(productRow)), LeftJoin(jProductid)]
    [TextualField(nameof(ProductidName)), ServiceLookupEditor(typeof(productRow))]
    public int? Productid { get => fields.Productid[this]; set => fields.Productid[this] = value; }

    [DisplayName("Userid"), Column("userid"), Size(255), QuickSearch, NameProperty]
    public string Userid { get => fields.Userid[this]; set => fields.Userid[this] = value; }

    [DisplayName("Photo")]
    public string Photo { get => fields.Photo[this]; set => fields.Photo[this] = value; }

    [DisplayName("Price"), Size(18)]
    public decimal? Price { get => fields.Price[this]; set => fields.Price[this] = value; }

    [DisplayName("Quntity")]
    public int? Quntity { get => fields.Quntity[this]; set => fields.Quntity[this] = value; }

    [DisplayName("Productid Name"), Origin(jProductid, nameof(productRow.Name))]
    public string ProductidName { get => fields.ProductidName[this]; set => fields.ProductidName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public Int32Field Productid;
        public StringField Userid;
        public StringField Photo;
        public DecimalField Price;
        public Int32Field Quntity;

        public StringField ProductidName;
    }
}