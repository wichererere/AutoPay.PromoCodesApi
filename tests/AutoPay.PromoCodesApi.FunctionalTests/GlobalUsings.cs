﻿global using System.Net;
global using System.Net.Http.Json;
global using System.Text;
global using System.Text.Json;
global using Ardalis.HttpClientTestExtensions;
global using AutoPay.PromoCodesApi.Infrastructure.Data;
global using AutoPay.PromoCodesApi.Infrastructure.Data.Config.Providers;
global using AutoPay.PromoCodesApi.Web;
global using FluentAssertions;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.AspNetCore.TestHost;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Testcontainers.MsSql;
global using Xunit;
