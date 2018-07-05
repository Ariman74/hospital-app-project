//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hospital.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class Sick
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sick()
        {
            this.Visit = new HashSet<Visit>();
        }
    
        public System.Guid Id { get; set; }

        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
       
        public Nullable<int> Age { get; set; }
        public Nullable<int> SexId { get; set; }
        public Nullable<int> StatusId { get; set; }
     
        public string VisitDate { get; set; }
   
        public string VisitTime { get; set; }
    
        public virtual Sex Sex { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visit { get; set; }
    }
}