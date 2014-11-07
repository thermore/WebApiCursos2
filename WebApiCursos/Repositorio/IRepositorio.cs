using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCursos.Repositorio
{
    //interfaz base, definimos qué operaciones quiero que implemente. Modelo de acceso a datos genérico
    //el cliente puede comunicar con TViewModel --> con TEntidad --> con bbdd (DBContext)

    interface IRepositorio<TViewModel,TEntidad> //el view va hacia la vista, entidad hacia la bbdd
    {
        //se reciben TViewModel
        TViewModel Add(TViewModel modelo);
        int Borrar(int id); //recibe el id, porque la bbdd borra por id
        int Borrar(TViewModel modelo);
        int Borrar(Expression<Func<TEntidad, bool>> lam); //recibe expresion lambda, con datos de entrada TEntidad y de salida un bool
        int Actualizar(TViewModel modelo);
        List<TViewModel> Get();
        List<TViewModel> Get(Expression<Func<TEntidad, bool>> lam);
        TViewModel Get(int pk); //me devuelve por clave primaria


        //que devuelva los objetos por pk
        TEntidad GetModelDesdeViewModel(TViewModel model); //le pasamos un View y nos devuelve una Entidad
    }
}
