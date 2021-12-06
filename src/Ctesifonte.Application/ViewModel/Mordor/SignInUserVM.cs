using Ctesifonte.Infra.Cross.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.ViewModel.Mordor
{
    public class SignInUserVM
    {
        // [DisplayField]
        // [RequiredField]
        public string Email { get; set; }

        // [DisplayField]
        // [RequiredField]
        public string Password { get; set; }
    }
}
