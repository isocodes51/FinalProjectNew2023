using Entitites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{ //class: Referans Tip demek burada
  //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir
  //new(): new lenebilir olmalı
   public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);// filter=null demek filtre vermeyebilirsin sana kalmış demek. Filtre vememişse tüm datayı getir demek
        T Get(Expression <Func <T,bool>> filter); //burada filtre zorunlu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
