using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Repositories.StaticDbRepositories
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public Feedback GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Feedback entity)
        {
            int feedbackId = 1;
            entity.Id = feedbackId;
            StaticDb.Feedbacks.Add(entity);
            return feedbackId;
        }

        public void Update(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}
