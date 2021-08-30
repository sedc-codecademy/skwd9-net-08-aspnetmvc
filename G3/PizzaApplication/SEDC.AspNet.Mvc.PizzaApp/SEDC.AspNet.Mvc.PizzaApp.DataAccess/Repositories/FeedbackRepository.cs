using SEDC.AspNet.Mvc.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.AspNet.Mvc.PizzaApp.DataAccess.Repositories
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        private readonly PizzaContext _context;

        public FeedbackRepository(PizzaContext context)
        {
            _context = context;
        }

        public List<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }

        public List<Feedback> GetByFilter(Func<Feedback, bool> filter)
        {
            return _context.Feedbacks.Where(filter).ToList();
        }

        public Feedback GetById(int id)
        {
            return _context.Feedbacks.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Feedback entity)
        {
            _context.Feedbacks.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Remove(int id)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(x => x.Id == id);
            if(feedback != null)
            {
                _context.Remove(feedback);
            }
            _context.SaveChanges();
        }

        public void Update(Feedback entity)
        {
            _context.Feedbacks.Update(entity);
            _context.SaveChanges();
        }
    }
}
