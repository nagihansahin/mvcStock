//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcStock.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class KategoriTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KategoriTbl()
        {
            this.TblUrunler = new HashSet<TblUrunler>();
        }
    
        public short kategoriID { get; set; }
        [Required(ErrorMessage ="L�tfen, Kategori Ad�n� Giriniz!")]
        [StringLength(50, ErrorMessage = "Max 50 Karakter Giriniz...")]
        public string kategoriAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblUrunler> TblUrunler { get; set; }
    }
}