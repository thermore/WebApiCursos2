using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCursos.Models.ViewModel
{
    public interface IViewModel<TModelo> where TModelo:class //va a recibir un generic de tipo modelo
    {

        //  1. para acceder a este repositorio, este interface
        TModelo ToBaseDatos();  //crear un objeto para insercciones, se transforma en tipo modelo
        void FromBaseDatos(TModelo model);// le pasa el TModelo, coger la info dsd la bbdd para randerizar y de valor a los campos de clase
        void UpdateBaseDatos(TModelo model); //le paso el modelo actualizar
        int[] GetPk(); //poder saber cual es la clave primaria del modelo

    }
}
