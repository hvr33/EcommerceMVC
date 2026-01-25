using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("orderdetials")]
[DisplayName("Orderdetials"), InstanceName("Orderdetials")]
[ReadPermission("orderdetiaals")]
[ModifyPermission("orderdetiaals")]
public sealed class orderdetialsRow : Row<orderdetialsRow.RowFields>, IIdRow
{
    const string jProductid = nameof(jProductid);
    const string jOrderid = nameof(jOrderid);

    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Productid"), Column("productid"), ForeignKey(typeof(productRow)), LeftJoin(jProductid)]
    [TextualField(nameof(ProductidName)), ServiceLookupEditor(typeof(productRow), Service = "com/product/List")]
    public int? Productid { get => fields.Productid[this]; set => fields.Productid[this] = value; }

    [DisplayName("Totalprice"), Column("totalprice"), Size(18)]
    public decimal? Totalprice { get => fields.Totalprice[this]; set => fields.Totalprice[this] = value; }

    [DisplayName("Quantity"), Column("quantity")]
    public int? Quantity { get => fields.Quantity[this]; set => fields.Quantity[this] = value; }

    [DisplayName("Orderid"), Column("orderid"), ForeignKey(typeof(orderRow)), LeftJoin(jOrderid), TextualField(nameof(OrderidUserid))]
    [ServiceLookupEditor(typeof(orderRow))]
    public int? Orderid { get => fields.Orderid[this]; set => fields.Orderid[this] = value; }

    [DisplayName("Price"), Column("price"), Size(18)]
    public decimal? Price { get => fields.Price[this]; set => fields.Price[this] = value; }

    [DisplayName("Entitydata"), Column("entitydata")]
    public DateOnly? Entitydata { get => fields.Entitydata[this]; set => fields.Entitydata[this] = value; }

    [DisplayName("Productid Name"), Origin(jProductid, nameof(productRow.Name))]
    public string ProductidName { get => fields.ProductidName[this]; set => fields.ProductidName[this] = value; }

    [DisplayName("Orderid Userid"), Origin(jOrderid, nameof(orderRow.Userid))]
    public string OrderidUserid { get => fields.OrderidUserid[this]; set => fields.OrderidUserid[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public Int32Field Productid;
        public DecimalField Totalprice;
        public Int32Field Quantity;
        public Int32Field Orderid;
        public DecimalField Price;
        public DateOnlyField Entitydata;

        public StringField ProductidName;
        public StringField OrderidUserid;
    }
}