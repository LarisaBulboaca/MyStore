using MyStore.Domain;
using MyStore.Models;
using System.Runtime.CompilerServices;

namespace MyStore.Helpers
{
    public static class Extensions
    {
        public static int CountWords(this string paragraph)
        {
            var words = paragraph.Split(' ');
            return words.Length;
        }

        public static CategoryModel ToCategoryModels(this Category domainObject)
        {
            var model = new CategoryModel();
            model.Categoryid = domainObject.Categoryid;
            model.Categoryname = domainObject.Categoryname;
            model.Description = domainObject.Description;
            return model;
        }

        public static Category ToCategory(this CategoryModel model)
        {
            var category = new Category();
            category.Categoryid = model.Categoryid;
            category.Categoryname = model.Categoryname;
            category.Description = model.Description;
            return category;
        }

        public static ShipperModel ToShipperModel(this Shipper domainObject)
        {
            
            var model = new ShipperModel();
            model.Shipperid = domainObject.Shipperid;
            model.Companyname = domainObject.Companyname;
            model.Phone = domainObject.Phone;
            return model;
        }

        public static Shipper ToShipper(this ShipperModel model)
        {
            var shipper = new Shipper();
            shipper.Shipperid = model.Shipperid;
            shipper.Companyname = model.Companyname;
            shipper.Phone = model.Phone;
            return shipper;
        }

        public static SupplierModel ToSupplierModel(this Supplier domainObject)
        {
            var model = new SupplierModel();

            model.Supplierid = domainObject.Supplierid;
            model.Companyname = domainObject.Companyname;
            model.Contactname = domainObject.Contactname;
            model.Contacttitle = domainObject.Contacttitle;
            model.Address = domainObject.Address;
            model.City = domainObject.City;
            model.Region = domainObject.Region;
            model.Postalcode = domainObject.Postalcode;
            model.Country = domainObject.Country;
            model.Phone = domainObject.Phone;
            model.Fax = domainObject.Fax;

            return model;
        }

        public static Supplier ToSupplier(this SupplierModel model)
        {
            var supplier = new Supplier();

            supplier.Supplierid = model.Supplierid;
            supplier.Companyname = model.Companyname;
            supplier.Contactname = model.Contactname;
            supplier.Contacttitle = model.Contacttitle;
            supplier.Address = model.Address;
            supplier.City = model.City;
            supplier.Region = model.Region;
            supplier.Postalcode = model.Postalcode;
            supplier.Country = model.Country;
            supplier.Phone = model.Phone;
            supplier.Fax = model.Fax;

            return supplier;
        }
    }
}
