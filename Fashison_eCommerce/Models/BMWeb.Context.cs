//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fashison_eCommerce.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_A6A231_DAQLTMDTEntities : DbContext
    {
        public DB_A6A231_DAQLTMDTEntities()
            : base("name=DB_A6A231_DAQLTMDTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Authorize> Authorizes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Cart_Item> Cart_Item { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Main_Type> Main_Type { get; set; }
        public virtual DbSet<Order_Items> Order_Items { get; set; }
        public virtual DbSet<Order_Tracking> Order_Tracking { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Type> Product_Type { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TimeOut> TimeOuts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AccountRole> AccountRoles { get; set; }
        public virtual DbSet<Buyer_LoadAllProduct> Buyer_LoadAllProduct { get; set; }
        public virtual DbSet<Buyer_LoadProduct> Buyer_LoadProduct { get; set; }
        public virtual DbSet<Order_All> Order_All { get; set; }
        public virtual DbSet<Order_Cancel> Order_Cancel { get; set; }
        public virtual DbSet<Order_Confirm> Order_Confirm { get; set; }
        public virtual DbSet<Order_Delivered> Order_Delivered { get; set; }
        public virtual DbSet<Order_Delivering> Order_Delivering { get; set; }
        public virtual DbSet<Order_Receive> Order_Receive { get; set; }
        public virtual DbSet<OV_OrderView> OV_OrderView { get; set; }
        public virtual DbSet<SV_initOrderList> SV_initOrderList { get; set; }
        public virtual DbSet<SV_pickupList> SV_pickupList { get; set; }
        public virtual DbSet<SV_shipperList> SV_shipperList { get; set; }
        public virtual DbSet<SV_shippingList> SV_shippingList { get; set; }
        public virtual DbSet<view_Buyer_Order_Items> view_Buyer_Order_Items { get; set; }
        public virtual DbSet<view_Buyer_Orders> view_Buyer_Orders { get; set; }
        public virtual DbSet<view_Cart> view_Cart { get; set; }
        public virtual DbSet<view_MainType> view_MainType { get; set; }
        public virtual DbSet<view_Product> view_Product { get; set; }
        public virtual DbSet<view_Products> view_Products { get; set; }
        public virtual DbSet<view_Shop> view_Shop { get; set; }
    
        [DbFunction("DB_A6A231_DAQLTMDTEntities", "CheckAdminLogin")]
        public virtual IQueryable<CheckAdminLogin_Result> CheckAdminLogin(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<CheckAdminLogin_Result>("[DB_A6A231_DAQLTMDTEntities].[CheckAdminLogin](@Email, @Password)", emailParameter, passwordParameter);
        }
    
        [DbFunction("DB_A6A231_DAQLTMDTEntities", "CountNV")]
        public virtual IQueryable<CountNV_Result> CountNV()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<CountNV_Result>("[DB_A6A231_DAQLTMDTEntities].[CountNV]()");
        }
    
        [DbFunction("DB_A6A231_DAQLTMDTEntities", "fn_getLatestStatus")]
        public virtual IQueryable<fn_getLatestStatus_Result> fn_getLatestStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_getLatestStatus_Result>("[DB_A6A231_DAQLTMDTEntities].[fn_getLatestStatus]()");
        }
    
        [DbFunction("DB_A6A231_DAQLTMDTEntities", "fn_getShipper")]
        public virtual IQueryable<fn_getShipper_Result> fn_getShipper()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_getShipper_Result>("[DB_A6A231_DAQLTMDTEntities].[fn_getShipper]()");
        }
    
        [DbFunction("DB_A6A231_DAQLTMDTEntities", "Load_User_Cart")]
        public virtual IQueryable<Load_User_Cart_Result> Load_User_Cart(Nullable<int> user_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Load_User_Cart_Result>("[DB_A6A231_DAQLTMDTEntities].[Load_User_Cart](@user_id)", user_idParameter);
        }
    
        public virtual int ChangeStatus(string id, Nullable<int> status)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangeStatus", idParameter, statusParameter);
        }
    
        public virtual ObjectResult<DetailOrder_Result> DetailOrder(Nullable<int> shipperid)
        {
            var shipperidParameter = shipperid.HasValue ?
                new ObjectParameter("shipperid", shipperid) :
                new ObjectParameter("shipperid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetailOrder_Result>("DetailOrder", shipperidParameter);
        }
    
        public virtual ObjectResult<FindProducts_Result> FindProducts(Nullable<int> store_ID, string name, Nullable<int> type, Nullable<int> qualityMin, Nullable<int> qualityMax)
        {
            var store_IDParameter = store_ID.HasValue ?
                new ObjectParameter("Store_ID", store_ID) :
                new ObjectParameter("Store_ID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(int));
    
            var qualityMinParameter = qualityMin.HasValue ?
                new ObjectParameter("QualityMin", qualityMin) :
                new ObjectParameter("QualityMin", typeof(int));
    
            var qualityMaxParameter = qualityMax.HasValue ?
                new ObjectParameter("QualityMax", qualityMax) :
                new ObjectParameter("QualityMax", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindProducts_Result>("FindProducts", store_IDParameter, nameParameter, typeParameter, qualityMinParameter, qualityMaxParameter);
        }
    
        public virtual ObjectResult<get_ProductByID_Result> get_ProductByID(Nullable<int> product_ID)
        {
            var product_IDParameter = product_ID.HasValue ?
                new ObjectParameter("product_ID", product_ID) :
                new ObjectParameter("product_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_ProductByID_Result>("get_ProductByID", product_IDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetIdFromEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetIdFromEmail", emailParameter);
        }
    
        public virtual ObjectResult<getOrders_Of_User_Result> getOrders_Of_User(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getOrders_Of_User_Result>("getOrders_Of_User", useridParameter);
        }
    
        public virtual ObjectResult<getProducts_Result> getProducts(Nullable<int> storeID)
        {
            var storeIDParameter = storeID.HasValue ?
                new ObjectParameter("StoreID", storeID) :
                new ObjectParameter("StoreID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProducts_Result>("getProducts", storeIDParameter);
        }
    
        public virtual int ListOrderDetailUser(string orderid)
        {
            var orderidParameter = orderid != null ?
                new ObjectParameter("orderid", orderid) :
                new ObjectParameter("orderid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ListOrderDetailUser", orderidParameter);
        }
    
        public virtual ObjectResult<ListOrdersUser_Result> ListOrdersUser(Nullable<int> id, Nullable<int> status)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListOrdersUser_Result>("ListOrdersUser", idParameter, statusParameter);
        }
    
        public virtual int OSP_CapNhanDonHang(Nullable<int> purchaseOrderId, string address, string phone)
        {
            var purchaseOrderIdParameter = purchaseOrderId.HasValue ?
                new ObjectParameter("PurchaseOrderId", purchaseOrderId) :
                new ObjectParameter("PurchaseOrderId", typeof(int));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OSP_CapNhanDonHang", purchaseOrderIdParameter, addressParameter, phoneParameter);
        }
    
        public virtual int OSP_CapNhatChiTiet(Nullable<long> purchaseOrderDetailId, Nullable<int> purchaseOrderId, Nullable<int> productId, Nullable<int> quantity, Nullable<decimal> unitPrice, Nullable<decimal> subtotal)
        {
            var purchaseOrderDetailIdParameter = purchaseOrderDetailId.HasValue ?
                new ObjectParameter("PurchaseOrderDetailId", purchaseOrderDetailId) :
                new ObjectParameter("PurchaseOrderDetailId", typeof(long));
    
            var purchaseOrderIdParameter = purchaseOrderId.HasValue ?
                new ObjectParameter("PurchaseOrderId", purchaseOrderId) :
                new ObjectParameter("PurchaseOrderId", typeof(int));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var unitPriceParameter = unitPrice.HasValue ?
                new ObjectParameter("UnitPrice", unitPrice) :
                new ObjectParameter("UnitPrice", typeof(decimal));
    
            var subtotalParameter = subtotal.HasValue ?
                new ObjectParameter("Subtotal", subtotal) :
                new ObjectParameter("Subtotal", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OSP_CapNhatChiTiet", purchaseOrderDetailIdParameter, purchaseOrderIdParameter, productIdParameter, quantityParameter, unitPriceParameter, subtotalParameter);
        }
    
        public virtual ObjectResult<proc_getShipper_Result> proc_getShipper()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_getShipper_Result>("proc_getShipper");
        }
    
        public virtual ObjectResult<ReportForAdmin_Result> ReportForAdmin()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportForAdmin_Result>("ReportForAdmin");
        }
    
        public virtual int ResetPassword(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ResetPassword", idParameter);
        }
    
        public virtual int sp_AccountChangePassword(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AccountChangePassword", emailParameter, passwordParameter);
        }
    
        public virtual int sp_AccountResgister(string username, string password, string email)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_AccountResgister", usernameParameter, passwordParameter, emailParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_ConfirmProduct_Admin(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ConfirmProduct_Admin", idParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_EditProfile(Nullable<int> id, string name, string email, string address, string gender, string phone, Nullable<System.DateTime> birthday, string avatar)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var birthdayParameter = birthday.HasValue ?
                new ObjectParameter("Birthday", birthday) :
                new ObjectParameter("Birthday", typeof(System.DateTime));
    
            var avatarParameter = avatar != null ?
                new ObjectParameter("Avatar", avatar) :
                new ObjectParameter("Avatar", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EditProfile", idParameter, nameParameter, emailParameter, addressParameter, genderParameter, phoneParameter, birthdayParameter, avatarParameter);
        }
    
        public virtual ObjectResult<sp_getAddressByID_Result> sp_getAddressByID(Nullable<int> addressID)
        {
            var addressIDParameter = addressID.HasValue ?
                new ObjectParameter("addressID", addressID) :
                new ObjectParameter("addressID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getAddressByID_Result>("sp_getAddressByID", addressIDParameter);
        }
    
        public virtual ObjectResult<sp_GetCartItem_Result> sp_GetCartItem(Nullable<int> cartID)
        {
            var cartIDParameter = cartID.HasValue ?
                new ObjectParameter("CartID", cartID) :
                new ObjectParameter("CartID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetCartItem_Result>("sp_GetCartItem", cartIDParameter);
        }
    
        public virtual ObjectResult<sp_getOrderDetail_Result> sp_getOrderDetail(string order_id)
        {
            var order_idParameter = order_id != null ?
                new ObjectParameter("order_id", order_id) :
                new ObjectParameter("order_id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getOrderDetail_Result>("sp_getOrderDetail", order_idParameter);
        }
    
        public virtual ObjectResult<sp_getUserAddress_Result> sp_getUserAddress(Nullable<int> user_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getUserAddress_Result>("sp_getUserAddress", user_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_InsUserFb(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsUserFb", emailParameter);
        }
    
        public virtual ObjectResult<sp_ListProductOfShop_Result> sp_ListProductOfShop(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListProductOfShop_Result>("sp_ListProductOfShop", idParameter);
        }
    
        public virtual ObjectResult<sp_Load_Cart_Result> sp_Load_Cart(Nullable<int> user_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Load_Cart_Result>("sp_Load_Cart", user_idParameter);
        }
    
        public virtual ObjectResult<sp_loadUserCart_Result> sp_loadUserCart(Nullable<int> user_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_loadUserCart_Result>("sp_loadUserCart", user_idParameter);
        }
    
        public virtual ObjectResult<sp_Login_Result> sp_Login(string email, string pass)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Login_Result>("sp_Login", emailParameter, passParameter);
        }
    
        public virtual ObjectResult<sp_ProductByStore_Result> sp_ProductByStore(Nullable<int> storeid)
        {
            var storeidParameter = storeid.HasValue ?
                new ObjectParameter("storeid", storeid) :
                new ObjectParameter("storeid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ProductByStore_Result>("sp_ProductByStore", storeidParameter);
        }
    
        public virtual ObjectResult<sp_ProductByType_Result> sp_ProductByType(Nullable<int> typeid)
        {
            var typeidParameter = typeid.HasValue ?
                new ObjectParameter("typeid", typeid) :
                new ObjectParameter("typeid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ProductByType_Result>("sp_ProductByType", typeidParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<sp_searchProduct_Result> sp_searchProduct(string name, Nullable<int> typeid)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var typeidParameter = typeid.HasValue ?
                new ObjectParameter("typeid", typeid) :
                new ObjectParameter("typeid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_searchProduct_Result>("sp_searchProduct", nameParameter, typeidParameter);
        }
    
        public virtual ObjectResult<sp_Shipper_Orders_Result> sp_Shipper_Orders(Nullable<int> shipper_id)
        {
            var shipper_idParameter = shipper_id.HasValue ?
                new ObjectParameter("shipper_id", shipper_id) :
                new ObjectParameter("shipper_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Shipper_Orders_Result>("sp_Shipper_Orders", shipper_idParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<bool>> Sp_User_Login(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("Sp_User_Login", userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<sp_View_Orders_Result> sp_View_Orders(Nullable<int> store_id, Nullable<int> status)
        {
            var store_idParameter = store_id.HasValue ?
                new ObjectParameter("store_id", store_id) :
                new ObjectParameter("store_id", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_View_Orders_Result>("sp_View_Orders", store_idParameter, statusParameter);
        }
    
        public virtual int USP_CapNhatUser(string email, string firstName, string lastName, string phone, string address, string gender, Nullable<System.DateTime> dayOfBirth)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var dayOfBirthParameter = dayOfBirth.HasValue ?
                new ObjectParameter("DayOfBirth", dayOfBirth) :
                new ObjectParameter("DayOfBirth", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_CapNhatUser", emailParameter, firstNameParameter, lastNameParameter, phoneParameter, addressParameter, genderParameter, dayOfBirthParameter);
        }
    
        public virtual int USP_DangKy(string email, string pass, string firstName, string lastName, string phone, string address, string gender, Nullable<System.DateTime> dayOfBirth)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("Pass", pass) :
                new ObjectParameter("Pass", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var dayOfBirthParameter = dayOfBirth.HasValue ?
                new ObjectParameter("DayOfBirth", dayOfBirth) :
                new ObjectParameter("DayOfBirth", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_DangKy", emailParameter, passParameter, firstNameParameter, lastNameParameter, phoneParameter, addressParameter, genderParameter, dayOfBirthParameter);
        }
    
        public virtual int USP_TaoUser(string email, string firstName, string lastName, string phone, string address, string gender, Nullable<System.DateTime> dayOfBirth, string role)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var dayOfBirthParameter = dayOfBirth.HasValue ?
                new ObjectParameter("DayOfBirth", dayOfBirth) :
                new ObjectParameter("DayOfBirth", typeof(System.DateTime));
    
            var roleParameter = role != null ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("USP_TaoUser", emailParameter, firstNameParameter, lastNameParameter, phoneParameter, addressParameter, genderParameter, dayOfBirthParameter, roleParameter);
        }
    }
}
