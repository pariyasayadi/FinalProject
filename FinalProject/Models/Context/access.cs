//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class access
    {
        public int num { get; set; }
        public string codemelliuser { get; set; }
        public Nullable<int> fake { get; set; }
    
        public virtual type type { get; set; }
        public virtual user user { get; set; }
    }
}
