using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;
using Serilog;
using Serilog.Sinks.PostgreSQL;
using Serilog.Sinks.PostgreSQL.ColumnWriters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddSwaggerGen();

string tableName = "logs";
string ConnectionString = "Host=localhost;Database=Warfront-legacy-users;Username=postgres;Password=1563;";

/*
 настройка логгирования (столбцы в бд)
*/

IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
{
    {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
    {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
    {"level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
    {"raise_date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
    {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
    {"properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
    {"props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
    {"machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
};

/* Настройка логгирования
   */

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.PostgreSQL(ConnectionString, tableName, columnWriters, needAutoCreateTable:true)
    .CreateLogger();

builder.Logging.AddSerilog();

var app = builder.Build();

app.UseForwardedHeaders();

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI((o) => 
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        o.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();



app.Run();
