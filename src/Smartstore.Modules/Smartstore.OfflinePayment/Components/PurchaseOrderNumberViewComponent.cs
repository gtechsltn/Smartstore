﻿using Microsoft.AspNetCore.Mvc;
using Smartstore.Core.Checkout.Orders;
using Smartstore.OfflinePayment.Models;
using Smartstore.OfflinePayment.Settings;

namespace Smartstore.OfflinePayment.Components
{
    public class PurchaseOrderNumberViewComponent : OfflinePaymentViewComponentBase
    {
        private readonly ICheckoutStateAccessor _checkoutStateAccessor;

        public PurchaseOrderNumberViewComponent(ICheckoutStateAccessor checkoutStateAccessor)
        {
            _checkoutStateAccessor = checkoutStateAccessor;
        }

        public override IViewComponentResult Invoke(string providerName)
        {
            var model = GetPaymentInfoModel<PurchaseOrderNumberPaymentInfoModel, PurchaseOrderNumberPaymentSettings>();

            var paymentData = _checkoutStateAccessor.CheckoutState.PaymentData;

            model.PurchaseOrderNumber = (string)paymentData.Get("PurchaseOrderNumber");

            return View(model);
        }
    }
}
