//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nu34life.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Suscription
    {
        public int Id { get; set; }
        public System.DateTime Payday { get; set; }
        public System.DateTime Ending_date { get; set; }
        public int Nutritionist_Id { get; set; }
        public int Membership_Id { get; set; }
    
        public virtual Membership Membership { get; set; }
        public virtual Nutritionist Nutritionist { get; set; }
    }
}
