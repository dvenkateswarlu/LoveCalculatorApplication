using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace LoveCalculatorApp.CommunicationDTO
{
    public class PhoneModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;

            if (string.IsNullOrWhiteSpace(value))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            var parts = value.Split('-');

            var phone = new Phone();

            if (parts.Length == 1)
            {
                phone.CountryCode = "91";
                phone.UserNumber = parts[0];
            }
            else
            {
                phone.CountryCode = parts[0];
                phone.UserNumber = parts[1];
            }

            bindingContext.Result = ModelBindingResult.Success(phone);
            return Task.CompletedTask;
        }
    }
}