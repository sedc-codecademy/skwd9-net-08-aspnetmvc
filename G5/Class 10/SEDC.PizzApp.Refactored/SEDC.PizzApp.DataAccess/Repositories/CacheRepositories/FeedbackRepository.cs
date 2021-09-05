using SEDC.PizzApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzApp.DataAccess.Repositories.CacheRepositories
{
   public class FeedbackRepository : IRepository<Feedback>
   {
      public void DeleteById(int id)
      {
         var feedback = CacheDb.Feedbacks.FirstOrDefault(f => f.Id == id);

         if (feedback != null)
         {
            CacheDb.Feedbacks.Remove(feedback);
         }
      }

      public List<Feedback> GetAll()
      {
         return CacheDb.Feedbacks;
      }

      public Feedback GetById(int id)
      {
         return CacheDb.Feedbacks.FirstOrDefault(feedback => feedback.Id == id);
      }

      public int Insert(Feedback entity)
      {
         CacheDb.FeedbackId++;

         entity.Id = CacheDb.FeedbackId;

         CacheDb.Feedbacks.Add(entity);

         return entity.Id;
      }

      public void Update(Feedback entity)
      {
         var feedback = CacheDb.Feedbacks.FirstOrDefault(f => f.Id == entity.Id);

         if (feedback != null)
         {
            var index = CacheDb.Feedbacks.IndexOf(entity);

            CacheDb.Feedbacks[index] = entity;
         }
      }
   }
}