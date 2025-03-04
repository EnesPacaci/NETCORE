using Enes_Api.Hubs;
using Enes_Api.Models.DapperContext;
using Enes_Api.Repositories.BottomGridRepositories;
using Enes_Api.Repositories.CategoryRepository;
using Enes_Api.Repositories.ContactRepositories;
using Enes_Api.Repositories.EmployeeRepositories;
using Enes_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using Enes_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using Enes_Api.Repositories.MessageRepositories;
using Enes_Api.Repositories.PopularLocationRepositories;
using Enes_Api.Repositories.ProductRepository;
using Enes_Api.Repositories.ServiceRepository;
using Enes_Api.Repositories.StatisticsRepositories;
using Enes_Api.Repositories.TestimonialRepositories;
using Enes_Api.Repositories.ToDoListRepositories;
using Enes_Api.Repositories.WhoWeAreDetailRepository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddTransient<IStatisticRepository, StatiscticRepository>();
builder.Services.AddTransient<IChartRepository, ChartRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});

builder.Services.AddSignalR();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .WriteTo.Console()
//    .WriteTo.File(@"C:\sapapi\logs\requests.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

//builder.Host.UseSerilog()
//    .ConfigureLogging(logging =>
//    {
//        logging.ClearProviders();
//        logging.SetMinimumLevel(LogLevel.Information);
//    });

//builder.Services.AddSingleton<LoggerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
//app.UseSerilogRequestLogging();
app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/ChatHub");

//// Test SignalR client
//await TestSignalRClient();

app.Run();

//async Task TestSignalRClient()
//{
//    // SignalR istemci oluþturma
//    var connection = new HubConnectionBuilder()
//        .WithUrl("https://localhost:7077/ChatHub")
//        .Build();

//    connection.On<string, string>("ReceiveMessage", (user, message) =>
//    {
//        Console.WriteLine($"{user}: {message}");
//    });

//    try
//    {
//        await connection.StartAsync();
//        Console.WriteLine("SignalR istemcisi baðlandý.");

//        // Mesaj gönderme kýsmý
//        while (true)
//        {
//            Console.Write("Kullanýcý adý: ");
//            var user = Console.ReadLine();
//            Console.Write("Mesaj: ");
//            var message = Console.ReadLine();
//            await connection.InvokeAsync("SendMessage", user, message);
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Hata: {ex.Message}");
//    }
//}
