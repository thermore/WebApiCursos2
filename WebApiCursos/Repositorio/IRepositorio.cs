using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCursos.Repositorio
{
    //interfaz base, definimos qué operaciones quiero que implemente. Modelo de acceso a datos genérico

    interface IRepositorio<TEntidad> //creamos el generic TEntidad
    {
        int Add(TEntidad modelo);
        int Borrar(int id); //recibe el id, porque la bbdd borra por id
        int Borrar(Expression<Func<TEntidad, bool>> lam); //recibe expresion lambda, con datos de entrada TEntidad y de salida un bool
        int Actualizar(TEntidad modelo);
        List<TEntidad> Get();
        List<TEntidad>Get(Expression<Func<TEntidad, bool>> lam);
        TEntidad Get(int pk); //me devuelve por clave primaria
    }
}
