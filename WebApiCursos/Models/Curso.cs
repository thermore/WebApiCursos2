//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiCursos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Curso
    {
        public Curso()
        {
            this.Aula = new HashSet<Aula>();
        }
    
        public int idCurso { get; set; }
        public string nombre { get; set; }
        public Nullable<int> profesor { get; set; }
        public System.DateTime incio { get; set; }
        public int duracion { get; set; }
    
        public Profesor Profesor1 { get; set; }
        public ICollection<Aula> Aula { get; set; }
    }
}
