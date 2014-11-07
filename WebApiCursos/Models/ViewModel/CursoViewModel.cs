using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCursos.Models.ViewModel
{
    public class CursoViewModel : IViewModel<Curso>
    {
        //vamos a privatizar los datos q salen en api/cursos
        public int idCurso { get; set; }
        public string nombre { get; set; }
        public Nullable<int> profesor { get; set; }
        public System.DateTime incio { get; set; }
        public int duracion { get; set; }

        public String NombreProfesor { get; set; }


        public Curso ToBaseDatos()
        {
            var model = new Curso()  //las de la derecha son propiedades de Curso(constructor) y las d la izqda clase viewModel
            {
                idCurso = idCurso,
                nombre = nombre,
                profesor = profesor,
                incio = incio,
                duracion = duracion
            };
            return model;
        }

        public void FromBaseDatos(Curso model) //recupera el objeto Curso y escribe los campos desde Curso
        {
            idCurso = model.idCurso;
            nombre = model.nombre;
            profesor = model.profesor;
            incio = model.incio;
            duracion = model.duracion;

            try
            {
                NombreProfesor = model.Profesor1.nombre;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateBaseDatos(Curso model) //objeto del modelo q existía y los modifica
        {
            model.idCurso=idCurso ;
            model.nombre=nombre ;
            model.profesor=profesor;
            model.incio=incio ;
            model.duracion= duracion ;
        }

        public int[] GetPk()
        {
            return new[] {idCurso};
        }
    }
}