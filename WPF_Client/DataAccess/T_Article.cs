//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_Client.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long IdAuthor { get; set; }
        public System.DateTime Date { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public long Viewcount { get; set; }
    
        public virtual T_User T_User { get; set; }
    }
}
