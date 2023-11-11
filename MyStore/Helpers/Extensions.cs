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

        public static CustomerModel ToCustomerModel(this Customer domainObject)
        {
            var model = new CustomerModel();
            model.Custid = domainObject.Custid;
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
            model.Orders = domainObject.Orders;
            return model;

        }

        public static Customer ToCustomer (this CustomerModel model)
        {
            var customer = new Customer ();
            customer.Custid =   model.Custid;
            customer.Companyname = model.Companyname;
            customer.Contactname = model.Contactname;
            customer.Contacttitle = model.Contacttitle;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.Region = model.Region;
            customer.Postalcode= model.Postalcode;
            customer.Country = model.Country;
            customer.Phone = model.Phone;
            customer.Fax = model.Fax;
            customer.Orders = model.Orders;
            return customer;
        }

        public static EmployeeModel ToEmployeeModel(this Employee domainObject)
        {
            var model = new EmployeeModel();
            model.Empid = domainObject.Empid;
            model.Lastname = domainObject.Lastname;
            model.Firstname = domainObject.Firstname;
            model.Title = domainObject.Title;
            model.Titleofcourtesy = domainObject.Titleofcourtesy;
            model.Birthdate = domainObject.Birthdate;
            model.Hiredate = domainObject.Hiredate;
            model.Address = domainObject.Address;
            model.City = domainObject.City;
            model.Region = domainObject.Region;
            model.Postalcode = domainObject.Postalcode;
            model.Country = domainObject.Country;
            model.Phone = domainObject.Phone;
            model.Mgrid = domainObject.Mgrid;
            model.InverseMgr = domainObject.InverseMgr;
            model.Mgr = domainObject.Mgr;
            model.Orders = domainObject.Orders;

            return model;
        }

        public static Employee ToEmployee(this EmployeeModel model)
        {
            var employee = new Employee();
            employee.Empid = model.Empid;
            employee.Lastname = model.Lastname;
            employee.Firstname = model.Firstname;
            employee.Title = model.Title;
            employee.Titleofcourtesy =  model.Titleofcourtesy;
            employee.Birthdate = model.Birthdate;
            employee.Hiredate = model.Hiredate;
            employee.Address = model.Address;
            employee.City = model.City;
            employee.Region = model.Region;
            employee.Postalcode= model.Postalcode;
            employee.Country = model.Country;
            employee.Phone = model.Phone;
            employee.Mgrid = model.Mgrid;
            employee.InverseMgr = model.InverseMgr;
            employee.Mgr = model.Mgr;
            employee.Orders = model.Orders;

            return employee;
        }

        public static NumModel ToNumModel(this Num domainObject) 
        {  
            var model = new NumModel();
            model.N = domainObject.N;

            return model;
        
        }

        public static Num ToNum (this NumModel model)
        {
            var num = new Num();
            num.N = model.N;

            return num;
        }

        public static OrderModel ToOrderModel(this Order domainObject)
        {
            var model = new OrderModel();
            model.Orderid = domainObject.Orderid;
            model.Custid = domainObject.Custid;
            model.Empid = domainObject.Empid;
            model.Orderdate = domainObject.Orderdate;
            model.Requireddate = domainObject.Requireddate;
            model.Shippeddate = domainObject.Shippeddate;
            model.Shipperid = domainObject.Shipperid;
            model.Freight = domainObject.Freight;
            model.Shipname = domainObject.Shipname;
            model.Shipaddress = domainObject.Shipaddress;
            model.Shipcity = domainObject.Shipcity;
            model.Shipregion = domainObject.Shipregion;
            model.Shippostalcode = domainObject.Shippostalcode;
            model.Shipcountry = domainObject.Shipcountry;
            model.Cust = domainObject.Cust;
            model.Emp = domainObject.Emp;
            model.OrderDetails = domainObject.OrderDetails;
            model.Shipper = domainObject.Shipper;

            return model;
        }

        public static Order ToOrder(this OrderModel model)
        {
            var order = new Order();
            order.Orderid = model.Orderid;
            order.Custid = model.Custid;
            order.Empid = model.Empid;
            order.Orderdate = model.Orderdate;
            order.Requireddate = model.Requireddate;
            order.Shippeddate= model.Shippeddate;
            order.Shipperid= model.Shipperid;
            order.Freight = model.Freight;
            order.Shipname = model.Shipname;
            order.Shipaddress = model.Shipaddress;
            order.Shipcity= model.Shipcity;
            order.Shipregion = model.Shipregion;
            order.Shippostalcode= model.Shippostalcode;
            order.Shipcountry= model.Shipcountry;
            order.Cust = model.Cust;
            order.Emp = model.Emp;
            order.OrderDetails = model.OrderDetails;
            order.Shipper = model.Shipper;

            return order;
        }

        public static OrderDetailModel ToOrderDetailModel(this OrderDetail domainObject)
        {
            var model = new OrderDetailModel();
            model.Orderid = domainObject.Orderid;
            model.Productid = domainObject.Productid;
            model.Unitprice = domainObject.Unitprice;
            model.Qty = domainObject.Qty;
            model.Discount = domainObject.Discount;
            model.Order = domainObject.Order;
            model.Product = domainObject.Product;
            return model;
        }

        public static OrderDetail ToOrderDetail(this OrderDetailModel model)
        {
            var order = new OrderDetail();
            order.Orderid = model.Orderid;
            order.Productid = model.Productid;
            order.Unitprice = model.Unitprice;
            order.Qty = model.Qty;
            order.Discount = model.Discount;
            order.Order = model.Order;
            order.Product = model.Product;

            return order;
        }

        public static ProductModel ToProductModel(this Product domainObject) 
        { 
            var model = new ProductModel(); 
            model.Productid = domainObject.Productid; 
            model.Productname = domainObject.Productname;
            model.Supplierid = domainObject.Supplierid;
            model.Categoryid = domainObject.Categoryid;
            model.Unitprice = domainObject.Unitprice;
            model.Discontinued = domainObject.Discontinued;
            model.Category = domainObject.Category;
            model.OrderDetails = domainObject.OrderDetails;
            model.Supplier = domainObject.Supplier;

            return model;
        }

        public static Product ToProduct(this ProductModel model)
        {
            var product = new Product();
            product.Productid = model.Productid;
            product.Productname = model.Productname;
            product.Supplierid = model.Supplierid;
            product.Categoryid = model.Categoryid;
            product.Unitprice = model.Unitprice;
            product.Discontinued = model.Discontinued;
            product.Category = model.Category;
            product.OrderDetails = model.OrderDetails;
            product.Supplier = model.Supplier;

            return product;
        }

        public static ScoreModel ToScoreModel(this Score domainObject) 
        {
            var model = new ScoreModel();
            model.Testid = domainObject.Testid;
            model.Studentid = domainObject.Studentid;
            model.Score1 = domainObject.Score1;
            model.Test = domainObject.Test;

            return model;
        }

        public static Score ToScore(this ScoreModel model)
        {
            var score = new Score();
            score.Testid = model.Testid;
            score.Studentid = model.Studentid;
            score.Score1 = model.Score1;
            score.Test = model.Test;

            return score;
        }

        public static TestModel ToTestModel(this Test domainObject)
        {
            var model = new TestModel();
            model.Testid = domainObject.Testid;
            model.Scores = domainObject.Scores;

            return model;
        }

        public static Test ToTest(this TestModel model)
        {
            var test = new Test();
            test.Testid = model.Testid;
            test.Scores = model.Scores;

            return test;
        }
    }
}
