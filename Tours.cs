//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Tours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tours()
        {
            this.Заявки = new HashSet<Заявки>();
        }
    
        public int ID { get; set; }
        public string Название { get; set; }
        public string Страна { get; set; }
        public Nullable<int> Количество_билетов { get; set; }
        public Nullable<int> Стоимость { get; set; }
        public Nullable<bool> Статус { get; set; }
        public Nullable<int> Типы_туров { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заявки> Заявки { get; set; }
        public virtual Страны Страны { get; set; }
        public virtual Типы_туров Типы_туров1 { get; set; }
    }
}
