﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VariationOne
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgeCategories_ToyStore> AgeCategories_ToyStore { get; set; }
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<AgentPriorityHistory> AgentPriorityHistory { get; set; }
        public virtual DbSet<AgentType> AgentType { get; set; }
        public virtual DbSet<Categories_ToyStore> Categories_ToyStore { get; set; }
        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Cities_Cursach> Cities_Cursach { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Countries_ToyStore> Countries_ToyStore { get; set; }
        public virtual DbSet<Customers_Cursach> Customers_Cursach { get; set; }
        public virtual DbSet<Deals> Deals { get; set; }
        public virtual DbSet<Departments_Cursach> Departments_Cursach { get; set; }
        public virtual DbSet<Directories_ToyStore> Directories_ToyStore { get; set; }
        public virtual DbSet<Edenices> Edenices { get; set; }
        public virtual DbSet<Employees_Cursach> Employees_Cursach { get; set; }
        public virtual DbSet<Genders_Cursach> Genders_Cursach { get; set; }
        public virtual DbSet<Givers> Givers { get; set; }
        public virtual DbSet<Group_roles_Cursach> Group_roles_Cursach { get; set; }
        public virtual DbSet<Groups_Cursach> Groups_Cursach { get; set; }
        public virtual DbSet<Main> Main { get; set; }
        public virtual DbSet<Makers> Makers { get; set; }
        public virtual DbSet<Manufacturers_ToyStore> Manufacturers_ToyStore { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialCountHistory> MaterialCountHistory { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<Names> Names { get; set; }
        public virtual DbSet<Offices_Cursach> Offices_Cursach { get; set; }
        public virtual DbSet<Orders_ToyStore> Orders_ToyStore { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistory { get; set; }
        public virtual DbSet<ProductMaterial> ProductMaterial { get; set; }
        public virtual DbSet<ProductSale> ProductSale { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Projects_Cursach> Projects_Cursach { get; set; }
        public virtual DbSet<Providers_ToyStore> Providers_ToyStore { get; set; }
        public virtual DbSet<Roles_ToyStore> Roles_ToyStore { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Specifications_Cursach> Specifications_Cursach { get; set; }
        public virtual DbSet<Status_ToyStore> Status_ToyStore { get; set; }
        public virtual DbSet<Statuses_Cursach> Statuses_Cursach { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Toys_ToyStore> Toys_ToyStores { get; set; }
        public virtual DbSet<User_role_Cursach> User_role_Cursach { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Users_Cursach> Users_Cursach { get; set; }
        public virtual DbSet<Users_ToyStore> Users_ToyStore { get; set; }
    }
}
