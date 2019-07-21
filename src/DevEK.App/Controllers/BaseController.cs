using System;
using DevEK.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevEK.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotify _notify;

        public BaseController(INotify notify)
        {
            _notify = notify;
        }

        protected bool OperationIsValid()
        {
            return !_notify.ThereIsNotification();
        }

    }
}
