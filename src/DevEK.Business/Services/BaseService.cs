using System;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace DevEK.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotify _notify;

        public BaseService(INotify notify)
        {
            _notify = notify;
        }

        protected void Notification(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notification(error.ErrorMessage);
            }
        }


        protected void Notification(string message)
        {
            _notify.Handle(new Notification(message));
        }


        // TV = Entity Validation, ex.: VendorValidation
        // TE = Genericy Entity , ex.: Vendor
        protected bool RunValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);
            if (!validator.IsValid)
            {
                Notification(validator);
                return false;
            }
            return true;
        }
    }
}
