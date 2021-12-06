using Ctesifonte.Application.Interfaces.ViewModels;
using Ctesifonte.Infra.Cross.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.ViewModel
{
    public class BaseVM : IBaseVM
    {
        [DisplayField]
        public Guid Id { get; set; }
        [DisplayField]
        public DateTime Created { get; set; }
        [DisplayField]
        public DateTime Modified { get; set; }
    }
}
