using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("Payments")]
[DisplayName("Payments"), InstanceName("Payments")]
[ReadPermission("payments")]
[ModifyPermission("payments")]
[ServiceLookupPermission("payments")]
public sealed class paymentsRow : Row<paymentsRow.RowFields>, IIdRow, INameRow
{
    const string jOrder = nameof(jOrder);

    [DisplayName("Id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Order"), NotNull, ForeignKey(typeof(orderRow)), LeftJoin(jOrder), TextualField(nameof(OrderUserid))]
    [ServiceLookupEditor(typeof(orderRow))]
    public int? OrderId { get => fields.OrderId[this]; set => fields.OrderId[this] = value; }

    [DisplayName("Provider"), Size(50), NotNull, QuickSearch, NameProperty]
    public string Provider { get => fields.Provider[this]; set => fields.Provider[this] = value; }

    [DisplayName("Provider Payment Id"), Size(100)]
    public string ProviderPaymentId { get => fields.ProviderPaymentId[this]; set => fields.ProviderPaymentId[this] = value; }

    [DisplayName("Amount"), Size(18), Scale(2), NotNull]
    public decimal? Amount { get => fields.Amount[this]; set => fields.Amount[this] = value; }

    [DisplayName("Currency"), Size(10), NotNull]
    public string Currency { get => fields.Currency[this]; set => fields.Currency[this] = value; }

    [DisplayName("Status"), Size(20), NotNull]
    public string Status { get => fields.Status[this]; set => fields.Status[this] = value; }

    [DisplayName("Raw Response")]
    public string RawResponse { get => fields.RawResponse[this]; set => fields.RawResponse[this] = value; }

    [DisplayName("Created At"), NotNull]
    public DateTime? CreatedAt { get => fields.CreatedAt[this]; set => fields.CreatedAt[this] = value; }

    [DisplayName("Updated At")]
    public DateTime? UpdatedAt { get => fields.UpdatedAt[this]; set => fields.UpdatedAt[this] = value; }

    [DisplayName("Order Userid"), Origin(jOrder, nameof(orderRow.Userid))]
    public string OrderUserid { get => fields.OrderUserid[this]; set => fields.OrderUserid[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public Int32Field Id;
        public Int32Field OrderId;
        public StringField Provider;
        public StringField ProviderPaymentId;
        public DecimalField Amount;
        public StringField Currency;
        public StringField Status;
        public StringField RawResponse;
        public DateTimeField CreatedAt;
        public DateTimeField UpdatedAt;

        public StringField OrderUserid;
    }
}