using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("productimage")]
[DisplayName("Productimage"), InstanceName("Productimage")]
[ReadPermission("productimage")]
[ModifyPermission("productimage")]
[ServiceLookupPermission("productimage")]
public sealed class productimageRow : Row<productimageRow.RowFields>, IIdRow, INameRow
{
    const string jProductid = nameof(jProductid);

    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Productid"), Column("productid"), ForeignKey(typeof(productRow)), LeftJoin(jProductid)]
    [TextualField(nameof(ProductidName)), ServiceLookupEditor(typeof(productRow))]
    public int? Productid { get => fields.Productid[this]; set => fields.Productid[this] = value; }

    [DisplayName("Image"), Column("image"), QuickSearch, NameProperty,ImageUploadEditor]
    public string Image { get => fields.Image[this]; set => fields.Image[this] = value; }

    [DisplayName("Productid Name"), Origin(jProductid, nameof(productRow.Name))]
    public string ProductidName { get => fields.ProductidName[this]; set => fields.ProductidName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public Int32Field Productid;
        public StringField Image;

        public StringField ProductidName;
    }
}