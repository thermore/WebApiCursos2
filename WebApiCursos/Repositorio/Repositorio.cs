using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApiCursos.Models;
using WebApiCursos.Models.ViewModel;

namespace WebApiCursos.Repositorio
{
    public class Repositorio<TViewModel, TEntidad> :
        IRepositorio<TViewModel, TEntidad>
        where TViewModel : class,IViewModel<TEntidad>, new() //TViewModel tiene q ser una clase e implemente un IViewModel de tipo TEntidad
        where TEntidad : class  //las renstricción se crea con new, 
    {
        protected cursoEntities Context;  //instancia conexión

        public Repositorio(cursoEntities context)
        {
            Context = context;
        }

        protected DbSet<TEntidad> DbSet  //q nos devuelve el DbSet(conjunto de tablas(de TEntidad) en la conexión)
        {
            get { return Context.Set<TEntidad>(); } //devuelve esa tabla
        }


        public virtual TViewModel Add(TViewModel modelo) //virtual para poder hacer algo distinto
        {
            var m = modelo.ToBaseDatos(); //me devuelve un objeto de tipo modelo, obejeto preparado xa enviar a la bbdd

            DbSet.Add(m);

            try
            {
                Context.SaveChanges();  //guardame los cambios
                modelo.FromBaseDatos(m); //m tiene el id, pero modelo no tiene su id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return modelo; //actualizado lo q hemos enviado a la bbdd
        }


        public virtual int Borrar(int id)
        {

            var mod = DbSet.Find(id);
            DbSet.Remove(mod);

            int n = 0;

            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return n;
        }

        public virtual int Borrar(TViewModel modelo)
        {

            var dato = GetModelDesdeViewModel(modelo);
            DbSet.Remove(dato);

            int n = 0;

            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return n;
        }

        public virtual int Borrar(Expression<Func<TEntidad, bool>> lam)
        {
            var datos = DbSet.Where(lam);
            DbSet.RemoveRange(datos);
            int n=0;

            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return n;
        }

        public virtual int Actualizar(TViewModel modelo) //pasa un TViewModel
        {
            var datos = GetModelDesdeViewModel(modelo);

            modelo.UpdateBaseDatos(datos);

            
            Context.Entry(modelo).State = EntityState.Modified; //actualiza un objeto, sobre una bbdd el método Entry nos dice que el estado es modificado
            int n = 0;
            //n = Context.SaveChanges();

            try
            {
                n = Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return n;
        }

        public TEntidad GetModelDesdeViewModel(TViewModel modelo)
        {
            var datos = DbSet.Find(modelo.GetPk());
            return datos;
        }

        public virtual List<TViewModel> Get()
        {
            var datos = DbSet;

            List<TViewModel> list=new List<TViewModel>();

            foreach (var entidad in datos)
            {
                var v = new TViewModel();
                v.FromBaseDatos(entidad);
                list.Add(v);

            }
            return list;
        }

        public virtual List<TViewModel> Get(Expression<Func<TEntidad, bool>> lam)
        {
            var datos = DbSet.Where(lam);

            List<TViewModel> list = new List<TViewModel>();

            foreach (var entidad in datos)
            {
                var v = new TViewModel();
                v.FromBaseDatos(entidad);
                list.Add(v);

            }
            return list;
        }

        public virtual TViewModel Get(int pk)
        {
            var v = new TViewModel();
            var entidad = DbSet.Find(pk);
            v.FromBaseDatos(entidad));
            return v;
        }
    }
}