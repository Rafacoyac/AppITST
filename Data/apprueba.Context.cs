﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class appruebaEntities : DbContext
    {
        public appruebaEntities()
            : base("name=appruebaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Autentication> Autentications { get; set; }
        public virtual DbSet<Binnacle> Binnacles { get; set; }
        public virtual DbSet<Career> Careers { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<ClassRoomType> ClassRoomTypes { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<DegreeSubject> DegreeSubjects { get; set; }
        public virtual DbSet<EducationLevel> EducationLevels { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
    }
}
