//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wpJulioSolorzano.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT_TAX
    {
        public long ID { get; set; }
        public long PRODUCT_ID { get; set; }
        public long TAX_ID { get; set; }
        public string TYPE { get; set; }
        public decimal VALUE { get; set; }
        public bool STATE { get; set; }
    
        public virtual PRODUCT PRODUCT { get; set; }
        public virtual TAX TAX { get; set; }
    }
}
