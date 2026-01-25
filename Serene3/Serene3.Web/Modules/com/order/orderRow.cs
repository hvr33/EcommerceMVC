using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;

namespace Serene3.com;

[ConnectionKey("cetgeroycontrol"), Module("com"), TableName("order")]
[DisplayName("Order"), InstanceName("Order")]
[ReadPermission("order")]
[ModifyPermission("order")]
[ServiceLookupPermission("order")]
public sealed class orderRow : Row<orderRow.RowFields>, IIdRow, INameRow
{
    const string jCountry = nameof(jCountry);
    const string jState = nameof(jState);
    const string jCity = nameof(jCity);

    [DisplayName("Userid"), Column("userid"), QuickSearch, NameProperty]
    public string Userid { get => fields.Userid[this]; set => fields.Userid[this] = value; }

    [DisplayName("Name"), Column("name")]
    public string Name { get => fields.Name[this]; set => fields.Name[this] = value; }

    [DisplayName("Phone"), Column("phone")]
    public string Phone { get => fields.Phone[this]; set => fields.Phone[this] = value; }

    [DisplayName("Email"), Column("email")]
    public string Email { get => fields.Email[this]; set => fields.Email[this] = value; }

   

    [DisplayName("Onlinepaid"), Column("onlinepaid")]
    public bool? Onlinepaid { get => fields.Onlinepaid[this]; set => fields.Onlinepaid[this] = value; }

    [DisplayName("Entity Date")]
    public DateOnly? EntityDate { get => fields.EntityDate[this]; set => fields.EntityDate[this] = value; }

    [DisplayName("Customer Name"), Size(150)]
    public string CustomerName { get => fields.CustomerName[this]; set => fields.CustomerName[this] = value; }

    [DisplayName("Country"), ForeignKey(typeof(countriesRow)), LeftJoin(jCountry), TextualField(nameof(CountryName))]
    [ServiceLookupEditor(typeof(countriesRow), Service = "com/countries/List")]
    public int? CountryId { get => fields.CountryId[this]; set => fields.CountryId[this] = value; }

    [DisplayName("State"), ForeignKey(typeof(statesRow)), LeftJoin(jState), TextualField(nameof(StateName))]
    [ServiceLookupEditor(typeof(statesRow), Service = "com/states/List")]
    public int? StateId { get => fields.StateId[this]; set => fields.StateId[this] = value; }

    [DisplayName("City"), ForeignKey(typeof(citiesRow)), LeftJoin(jCity), TextualField(nameof(CityName))]
    [ServiceLookupEditor(typeof(citiesRow), Service = "com/cities/List")]
    public int? CityId { get => fields.CityId[this]; set => fields.CityId[this] = value; }

    [DisplayName("Address"), Size(255)]
    public string Address { get => fields.Address[this]; set => fields.Address[this] = value; }

    [DisplayName("Order Date")]
    public DateTime? OrderDate { get => fields.OrderDate[this]; set => fields.OrderDate[this] = value; }

    [DisplayName("Id"), Column("id"), Identity, IdProperty]
    public int? Id { get => fields.Id[this]; set => fields.Id[this] = value; }

    [DisplayName("Productid"), Column("productid")]
    public int? Productid { get => fields.Productid[this]; set => fields.Productid[this] = value; }

    [DisplayName("Country Name"), Origin(jCountry, nameof(countriesRow.Name))]
    public string CountryName { get => fields.CountryName[this]; set => fields.CountryName[this] = value; }

    [DisplayName("State Name"), Origin(jState, nameof(statesRow.Name))]
    public string StateName { get => fields.StateName[this]; set => fields.StateName[this] = value; }

    [DisplayName("City Name"), Origin(jCity, nameof(citiesRow.Name))]
    public string CityName { get => fields.CityName[this]; set => fields.CityName[this] = value; }

    public class RowFields : RowFieldsBase
    {
        public StringField Userid;
        public StringField Name;
        public StringField Phone;
        public StringField Email;
     
        public BooleanField Onlinepaid;
        public DateOnlyField EntityDate;
        public StringField CustomerName;
        public Int32Field CountryId;
        public Int32Field StateId;
        public Int32Field CityId;
        public StringField Address;
        public DateTimeField OrderDate;
        public Int32Field Id;
        public Int32Field Productid;

        public StringField CountryName;
        public StringField StateName;
        public StringField CityName;
    }
}