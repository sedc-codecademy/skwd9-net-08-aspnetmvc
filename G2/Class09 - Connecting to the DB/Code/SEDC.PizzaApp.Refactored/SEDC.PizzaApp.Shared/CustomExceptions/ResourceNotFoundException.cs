using System;

namespace SEDC.PizzaApp.Shared.CustomExceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message) : base(message)
        {

        }
    }
}
