using Ctesifonte.Infra.Cross.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.ViewModel.Mordor
{
    public class CreateUserVM: BaseVM
    {
        [DisplayField]
        public string Uid { get; set; }
        [DisplayField]
        [RequiredField]
        public string Username { get; set; }
        [DisplayField]
        [RequiredField]
        public string Email { get; set; }
        [DisplayField]
        [RequiredField]
        public string Password { get; set; }
        [DisplayField]
        [RequiredField]
        public string Role { get; set; }
        [DisplayField]
        public bool Active { get; set; }
    }
}
