using Ctesifonte.Infra.Cross.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.ViewModel.Hefestos
{
    public class CreateCustomerVM: BaseVM
    {
        [DisplayField]
        [RequiredField]
        public string Name { get; set; }
        [DisplayField]
        [RequiredField]
        public string CNPJ { get; set; }
        [DisplayField]
        [RequiredField]
        public string Email { get; set; }
        [DisplayField]
        [RequiredField]
        public bool Active { get; set; }
    }
}
