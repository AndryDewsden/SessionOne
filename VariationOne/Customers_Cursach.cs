//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Customers_Cursach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers_Cursach()
        {
            this.Projects_Cursach = new HashSet<Projects_Cursach>();
        }
    
        public int id_customer { get; set; }
        public string customer_name { get; set; }
        public int customer_id_city { get; set; }
        public string customer_address { get; set; }
    
        public virtual Cities_Cursach Cities_Cursach { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Projects_Cursach> Projects_Cursach { get; set; }
    }
}
