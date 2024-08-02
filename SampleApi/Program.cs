var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var user = "some name";
var password = "somepassword";

Console.WriteLine($"{user} - {password}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

class WeakEncryption
{
    public static byte[] EncryptString()
    {
        System.Security.Cryptography.SymmetricAlgorithm serviceProvider = new System.Security.Cryptography.DESCryptoServiceProvider();
        byte[] key = { 16, 22, 240, 11, 18, 150, 192, 21 };
        serviceProvider.Key = key;
        System.Security.Cryptography.ICryptoTransform encryptor = serviceProvider.CreateEncryptor();

        String message = "Hello World";
        byte[] messageB = System.Text.Encoding.ASCII.GetBytes(message);
        return encryptor.TransformFinalBlock(messageB, 0, messageB.Length);
    }
}