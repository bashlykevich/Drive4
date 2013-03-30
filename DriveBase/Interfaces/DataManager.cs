using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Linq.Expressions;

namespace Drive4.Toolkit.Interfaces
{

    public interface DataManager
    {
        Type EditWindow
        {
            get;
            set;
        }
        Type EntityType
        {
            get;
        }
        string Name
        {
            get;
        }
        void Create(EntityObject DataItemToCreate);
        void Update(EntityObject DataItemToUpdate);
        void Delete(int ID);
        EntityObject Retrieve(int ID);
        IEnumerable<EntityObject> Retrieve();
        IEnumerable<EntityObject> Retrieve(Dictionary<string, string> SQLFilterParameters);
        IEnumerable DataColumns { get;}
    }
    public static class ExtensionMethods
    {
        public static TResult NextId<TSource, TResult>(this ObjectSet<TSource> table, Expression<Func<TSource, TResult>> selector)
            where TSource : class
        {
            TResult lastId = table.Any() ? table.Max(selector) : default(TResult);

            if (lastId is int)
            {
                lastId = (TResult)(object)(((int)(object)lastId) + 1);
            }
            return lastId;
        }
    }
}
