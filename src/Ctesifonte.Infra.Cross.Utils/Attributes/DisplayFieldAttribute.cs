using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Cross.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class DisplayFieldAttribute : DisplayNameAttribute
    {
        public DisplayFieldAttribute([CallerMemberName] string propertyName = "")
        {
            try
            {
                var a = new System.Resources.ResourceManager(typeof(Resources.FieldsNameResource))
                {
                    IgnoreCase = true
                };
                DisplayNameValue = a.GetString(propertyName) ?? propertyName;
            }
            catch (Exception)
            {
                DisplayNameValue = propertyName;
            }
        }
    }
}
