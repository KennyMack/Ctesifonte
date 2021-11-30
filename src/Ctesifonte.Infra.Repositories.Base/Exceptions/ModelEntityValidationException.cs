using Ctesifonte.Domain.Base.Interfaces.Exceptions;
using Ctesifonte.Infra.Cross.Utils.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Base.Exceptions
{
    public class ModelEntityValidationException : Exception, IModelEntityValidationException
    {
        public ModelEntityValidationException(DbUpdateException innerException) :
           base(null, innerException)
        {
        }

        public override string Message
        {
            get
            {
                var innerException = InnerException as DbUpdateException;
                if (innerException != null)
                {
                    StringBuilder sb = new StringBuilder();
                    /*
                    sb.AppendLine();
                    sb.AppendLine();
                    foreach (var eve in innerException.EntityValidationErrors)
                    {
                        sb.AppendLine(string.Format("- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().FullName, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage));
                        }
                    }

                    sb.AppendLine();*/

                    return sb.ToString();
                }

                return base.Message;
            }
        }

        public List<ModelException> MException
        {
            get
            {
                var Exceptions = new List<ModelException>();
                var innerException = InnerException as DbUpdateException;
                if (innerException != null)
                {/*
                    var eve = innerException.EntityValidationErrors.First();

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Exceptions.Add(new ModelException
                        {
                            ErrorCode = (int)EExceptionErrorCodes.SaveSQLError,
                            Field = ve.PropertyName,
                            Value = eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName)?.ToString(),
                            Messages = new[]
                            {
                                ve.ErrorMessage
                            }
                        });
                    }
                    */
                }

                return Exceptions;
            }
        }
    }
}
