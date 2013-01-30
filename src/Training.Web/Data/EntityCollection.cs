using System;
using System.Collections.Generic;

namespace Training.Web.Data
{
    public class EntityCollection<T> : SynchronizedCollection<T>
    {
        readonly Action<T, int> idSetter;

        public EntityCollection(Action<T, int> idSetter)
        {
            if (idSetter == null) throw new ArgumentNullException("idSetter");
            this.idSetter = idSetter;
        }

        public void AddEntity(T entity)
        {
            idSetter(entity, IdGenerator.NextId());
            Add(entity);
        }
    }
}