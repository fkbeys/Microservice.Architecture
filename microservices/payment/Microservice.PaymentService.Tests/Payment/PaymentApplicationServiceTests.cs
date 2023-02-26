﻿using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Microservice.PaymentService.Payment;

[TestFixture]
internal class PaymentApplicationServiceTests : PaymentServiceTests
{
    private IPaymentApplicationService _paymentApplicationService;

    [SetUp]
    public void Setup()
    {
        _paymentApplicationService = ServiceProvider.GetRequiredService<IPaymentApplicationService>();
    }
}