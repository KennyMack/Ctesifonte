using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Base.Interfaces.Models
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
