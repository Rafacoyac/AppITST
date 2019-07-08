//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dates
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            this.DegreeSubjects = new HashSet<DegreeSubject>();
            this.Lessons = new HashSet<Lesson>();
        }
    
        public int SubjectsID { get; set; }
        public string Clave { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int CareersID { get; set; }
        public int SpecialityID { get; set; }
        public System.DateTime DateTimeCreation { get; set; }
        public System.DateTime DateTimeModification { get; set; }
        public string UserCreation { get; set; }
        public string UserModification { get; set; }
        public string Status { get; set; }
    
        public virtual Career Career { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DegreeSubject> DegreeSubjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
