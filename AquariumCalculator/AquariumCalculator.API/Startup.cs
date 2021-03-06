﻿using AquariumCalculator.Contracts;
using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Services;
using AquariumCalculator.Services.Configurators;
using AquariumCalculator.Services.Repositories;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AquariumCalculator.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddTransient<IGlassTickness, GlassTicknessCalculator>();
      services.AddTransient<IGlassCatalog, GlassCatalog>();
      services.AddTransient<IGlassStrength, MainPanelGlassStrengthConstants>();
      services.AddTransient<IAquariumCatalog, AquariumCatalog>();
      services.AddTransient<IPumpRepository, PumpRepository>();
      services.AddTransient<ISkimmerRepository, SkimmerRepository>();
      services.AddTransient<ILightRepository, LightRepository>();

      services.AddTransient<LightConfigurator>();
      services.AddTransient<PumpConfiguratior>();
      services.AddTransient<SkimmerConfigurator>();


      services.AddTransient<IPDFService, PDFService>();
      services.AddTransient<ITemplateService, TemplateService>();

      services.AddTransient<IEmailService, EmailService>();

      services.AddTransient<IInvoiceService, InvoiceService>();

      services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

      //services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
      //{
      //  builder.AllowAnyOrigin()
      //         .AllowAnyMethod()
      //         .AllowAnyHeader();
      //}));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseStaticFiles();

      app.UseCors(builder => builder
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials());
      //app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
