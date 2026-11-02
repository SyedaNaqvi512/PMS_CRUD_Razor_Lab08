using PMS_CRUD_Razor_Lab08.Data;

var builder = WebApplication.CreateBuilder(args);

// Register Razor Pages.
builder.Services.AddRazorPages();

// Register application services.
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
// Open Products page by default
app.MapGet("/", () => Results.Redirect("/Products"));

app.Run();