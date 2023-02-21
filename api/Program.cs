class Program {
    private static void Main(string[] args) {       

        Database.openConnectDb();  
        Database.request();

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        var app = builder.Build();  

        app.UseHttpsRedirection();    

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        Database.closeConnectDb();
    } 
}