using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConsoleSample.Utils
{
    //Validation验证器
  public static  class ExecuteValidationHelper
    {
        public static List<ValidationResult> ExecuteValidation(this EfCoreDbContext context)
        {
            var result = new List<ValidationResult>();
            foreach (var entry in context.ChangeTracker.Entries().Where(t=>(t.State==EntityState.Added)||(t.State==EntityState.Modified)))
            {
                var entity = entry.Entity;
                var valProvider = new ValidationDbContextServiceProvider(context);
                var valContext = new ValidationContext(entity, valProvider, null);
                var entityErrors = new List<ValidationResult>();
                if (!Validator.TryValidateObject(
                    entity, valContext, entityErrors, true))
                {
                    result.AddRange(entityErrors);
                }
            }

            return result.ToList();
        }
    }
    public class ValidationDbContextServiceProvider : IServiceProvider
    {
        private readonly DbContext _currContext;

        /// <summary>
        /// This creates the validation service provider
        /// </summary>
        /// <param name="currContext">The currect DbContext in which this validation is happening</param>
        public ValidationDbContextServiceProvider(DbContext currContext)
        {
            _currContext = currContext;
        }

        /// <summary>
        /// This implemenents the GetService part of the service provider. It only understands the type DbContext
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(DbContext))
            {
                return _currContext;
            }

            return null;
        }
    }
}
