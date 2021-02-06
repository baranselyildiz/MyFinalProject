using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic Constraint (Kısıtlama)
    // class : referans tip
    // IEntity : IEntity olabilir ve ya IEntity implemente eden bir nesne olabilir
    // new() : new'lenebilir olmalı
    // IEntity newlenmediği için, onu da iptal etmiş olduk. Sadece Category, Customer, Product alabiliyor...
    // Yani artık sadece veri tabanı nesneleri ile çalışan bir repository oluşturmuş olduk.
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
