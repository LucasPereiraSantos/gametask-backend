//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gametask_back_api
{
    using System;
    using System.Collections.Generic;
    
    public partial class gm_tarefa
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public Nullable<System.DateTime> dataInicio { get; set; }
        public Nullable<System.DateTime> dataFim { get; set; }
        public string nivelDificuldade { get; set; }
    }
}
