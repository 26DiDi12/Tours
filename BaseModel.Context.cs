﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Туры
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ToursDBEntities3 : DbContext
    {
        private static ToursDBEntities3 _context;

        public ToursDBEntities3()
            : base("name=ToursDBEntities3")
        {
        }

        public static ToursDBEntities3 GetContext()
        {
            if (_context == null)
                _context = new ToursDBEntities3();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tours> Tours { get; set; }
        public virtual DbSet<Ваучеры> Ваучеры { get; set; }
        public virtual DbSet<Документы> Документы { get; set; }
        public virtual DbSet<Заявки> Заявки { get; set; }
        public virtual DbSet<Клиенты> Клиенты { get; set; }
        public virtual DbSet<Отели> Отели { get; set; }
        public virtual DbSet<Отзывы_отелей> Отзывы_отелей { get; set; }
        public virtual DbSet<Страны> Страны { get; set; }
        public virtual DbSet<Типы_питания> Типы_питания { get; set; }
        public virtual DbSet<Типы_туров> Типы_туров { get; set; }
        public virtual DbSet<Услуги> Услуги { get; set; }
    }
}
