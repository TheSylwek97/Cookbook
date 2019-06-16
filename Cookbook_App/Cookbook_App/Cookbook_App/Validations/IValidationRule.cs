using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook_App.Validations
{
    interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
