using Ctesifonte.Infra.Cross.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Base.Interfaces.Exceptions
{
    public interface IModelEntityValidationException
    {
        string Message { get; }
        List<ModelException> MException { get; }
    }
}
