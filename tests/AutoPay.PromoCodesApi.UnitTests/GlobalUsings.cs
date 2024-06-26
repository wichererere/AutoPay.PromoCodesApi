﻿global using System.Runtime.CompilerServices;
global using Ardalis.Result;
global using Ardalis.SharedKernel;
global using AutoPay.PromoCodesApi.Core.AuditAggregate;
global using AutoPay.PromoCodesApi.Core.PromoCodeAggregate;
global using AutoPay.PromoCodesApi.Core.PromoCodeAggregate.ErrorMessages;
global using AutoPay.PromoCodesApi.Core.PromoCodeAggregate.Specifications;
global using AutoPay.PromoCodesApi.Core.Services;
global using AutoPay.PromoCodesApi.UseCases.PromoCodes.Create;
global using AutoPay.PromoCodesApi.UseCases.PromoCodes.DecreaseMaxPossibleDownloads;
global using AutoPay.PromoCodesApi.UseCases.PromoCodes.Get;
global using AutoPay.PromoCodesApi.UseCases.PromoCodes.MarkAsInactive;
global using AutoPay.PromoCodesApi.UseCases.PromoCodes.Update;
global using FluentAssertions;
global using MediatR;
global using Microsoft.Extensions.Logging;
global using NSubstitute;
global using NSubstitute.ReturnsExtensions;
global using Xunit;
