using Data;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ITagHelperInitializer<ScriptTagHelper>, AppendVersionTagHelperInitializer>();
builder.Services.AddSingleton<ITagHelperInitializer<LinkTagHelper>, AppendVersionTagHelperInitializer>();
builder.Services.AddSingleton<ITagHelperInitializer<ImageTagHelper>, AppendVersionTagHelperInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


public class AppendVersionTagHelperInitializer :
    ITagHelperInitializer<ScriptTagHelper>,
    ITagHelperInitializer<LinkTagHelper>,
    ITagHelperInitializer<ImageTagHelper>
{
    private const bool DefaultValue = true;

    public void Initialize(ScriptTagHelper helper, ViewContext context)
    {
        helper.AppendVersion = DefaultValue;
    }

    public void Initialize(LinkTagHelper helper, ViewContext context)
    {
        helper.AppendVersion = DefaultValue;
    }

    public void Initialize(ImageTagHelper helper, ViewContext context)
    {
        helper.AppendVersion = DefaultValue;
    }
}