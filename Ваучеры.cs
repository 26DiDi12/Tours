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
    
    public partial class Ваучеры
    {
        public int ID { get; set; }
        public Nullable<int> Клиент { get; set; }
        public Nullable<bool> Ваучер_на_трансфер { get; set; }
        public Nullable<bool> Ваучер_на_заселение { get; set; }
    
        public virtual Клиенты Клиенты { get; set; }
    }
}
