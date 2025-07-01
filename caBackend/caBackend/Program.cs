using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


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

app.MapPost("/Login", async (HttpContext context) =>
{
    var request = await context.Request.ReadFromJsonAsync<LoginRequest>();
    var response = new LoginResponse
    {
        isLoggedIn = false,
        isPaid = false
    };

    if (request is not null)
    {
        if (request.username == "Jason" && request.password == "Jason1234")
        {
            response.isLoggedIn = true;
            response.isPaid = true;
        }
        else if (request.username == "Alex" && request.password == "Alex1234")
        {
            response.isLoggedIn = true;
            response.isPaid = true;
        }
        else if (request.username == "Daimon" && request.password == "Daimon1234")
        {
            response.isLoggedIn = true;
            response.isPaid = false;
        }
        else if (request.username == "Lewis" && request.password == "Lewis1234")
        {
            response.isLoggedIn = true;
            response.isPaid = false;
        }
        else if (request.username == "Asher" && request.password == "Asher1234")
        {
            response.isLoggedIn = true;
            response.isPaid = false;
        }
    }

    return Results.Json(response);
});

app.MapGet("/Ad", () =>
{
    string GetBase64(string path)
    {
        byte[] imageBytes = System.IO.File.ReadAllBytes(path);
        return Convert.ToBase64String(imageBytes);
    }

    var images = new List<string>
    {
        GetBase64("wwwroot/images/ad1.png"),
        GetBase64("wwwroot/images/ad2.png"),
        GetBase64("wwwroot/images/ad3.png")
    };

    return Results.Json(images);
});

//params: username/besttime
app.MapPost("/Leaderboard", async (GameResult incomingResult, AppDbContext db) =>
{
    var existing = await db.GameResults
        .FirstOrDefaultAsync(r => r.Username == incomingResult.Username);

    if (existing != null)
    {
        if (incomingResult.BestTime < existing.BestTime)
        {
            existing.BestTime = incomingResult.BestTime;
            await db.SaveChangesAsync();
        }
    }
    else
    {
        db.GameResults.Add(incomingResult);
        await db.SaveChangesAsync();
    }
    
    var top5 = await db.GameResults
        .OrderBy(r => r.BestTime)
        .Take(5)
        .Select(r => new { r.Username, r.BestTime })
        .ToListAsync();
    
    var allSorted = await db.GameResults
        .OrderBy(r => r.BestTime)
        .ToListAsync();

    int rank = allSorted.FindIndex(r => r.Username == incomingResult.Username) + 1;

    return Results.Json(new
    {
        Top5 = top5,
        YourRank = rank
    });
});


app.Run();

public class LoginRequest
{
    public string username { get; set; }
    public string password { get; set; }
}

public class LoginResponse
{
    public bool isLoggedIn { get; set; }
    public bool isPaid { get; set; }
}