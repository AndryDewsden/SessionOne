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
    
    public partial class Orders_ToyStore
    {
        public int id_order { get; set; }
        public int order_id_directory { get; set; }
        public int order_id_toy { get; set; }
        public int order_quantity { get; set; }
    
        public virtual Directories_ToyStore Directories_ToyStore { get; set; }
        public virtual Toys_ToyStore Toys_ToyStore { get; set; }
    }
}
