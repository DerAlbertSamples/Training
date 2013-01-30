using System;
using System.Collections.Generic;
using Training.Web.Entities;

namespace Training.Web.Data
{
    public class EntityStore
    {
        static readonly EntityStore _currentStore = new EntityStore();
        readonly EntityCollection<Person> personen;
        readonly EntityCollection<Firma> firmen;

        readonly Dictionary<Type, object> stores = new Dictionary<Type, object>();

        EntityStore()
        {
            stores[typeof (Person)] =  new EntityCollection<Person>((entity, id) => entity.Id = id);
            stores[typeof(Firma)] = new EntityCollection<Firma>((entity, id) => entity.Id = id);

            personen = GetStore<Person>();
            firmen = GetStore<Firma>();
            Seed();
        }

        public IEnumerable<Person> Personen
        {
            get { return personen; }
        }

        public IEnumerable<Firma> Firmen
        {
            get { return firmen; }
        }

        public static EntityStore Current
        {
            get { return _currentStore; }
        }


        public void Add<T>(T entity)
        {
            GetStore<T>().AddEntity(entity);
        }

        public void Remove<T>(T entity)
        {
            GetStore<T>().Remove(entity);
        }

        EntityCollection<T> GetStore<T>()
        {
            return (EntityCollection<T>) stores[typeof (T)];
        }

        void Seed()
        {
            DataSeeder.Seed(this);
        }
    }
}