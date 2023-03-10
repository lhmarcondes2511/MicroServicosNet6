using AutoMapper;
using GeekShopping.CartAPI.Model.Context;
using GeekShopping.CartAPI.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using GeekShopping.CartAPI.Repository;
using Microsoft.IdentityModel.Logging;
using GeekShopping.CartAPI.Repository;
using GeekShopping.CartAPI.RabbitMQSender;

var builder = WebApplication.CreateBuilder(args);
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

// Add services to the container.

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 20))));

builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();


builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();

builder.Services.AddHttpClient<ICouponRepository, CouponRepository>(s => s.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CouponAPI"]));

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddAuthentication("Bearer")
	.AddJwtBearer("Bearer", options =>
	{
		options.Authority = "https://localhost:5535/";
		options.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateAudience = false,
		};
	});
builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("ApiScope", policy =>
	{
		policy.RequireAuthenticatedUser();
		policy.RequireClaim("scope", "geek_shopping");
	});
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.CartAPI", Version = "v1" });
	c.EnableAnnotations();
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = @"Enter 'Bearer' [space] and your token!",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				},
				Scheme ="oauth2",
				Name = "Bearer",
				In = ParameterLocation.Header
			},
			new List<string>()
		}
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	IdentityModelEventSource.ShowPII = true;
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();