using EFCoreBt23.Data;
using EFCoreBt23.Repos;
using EFCoreBt23.Repositories;
using EFCoreBt23.Repositories.Interface;
using EFCoreBt23.Services;
using EFCoreBt23.Services.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOracle<StudentDbContext>(builder.Configuration.GetConnectionString("OracleConn"));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IMarkRepository, MarkRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IMarkService, MarkService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
