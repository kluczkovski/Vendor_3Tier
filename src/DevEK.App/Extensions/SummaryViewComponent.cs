using System;
using System.Threading.Tasks;
using DevEK.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevEK.App.Extensions
{
    public class SummaryViewComponent: ViewComponent
    {
        private readonly INotify _notify;

        public SummaryViewComponent(INotify notify)
        {
            _notify = notify;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications =  await Task.FromResult(_notify.GetNotifications());

            notifications.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Message));
            return View();
        }
    }
}
