public class Program
{

    public static int Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddControllersWithViews();
        var app = builder.Build();
        app.MapControllerRoute("default","{controller}/{action}/{index?}");
        app.Run();

        return 0;
    }
}