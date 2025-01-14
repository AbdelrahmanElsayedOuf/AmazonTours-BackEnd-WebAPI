
using AmazonTours.Application.Interfaces.Identity;
using AmazonTours.Application.Interfaces.Services;
using AmazonTours.Application.Interfaces.UnitOfWork;
using AmazonTours.Application.Services;
using AmazonTours.Infrastructure.UnitOfWork;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Amazon_Tours
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AmazonToursDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AmazonToursDBLocal"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // Add Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AmazonToursDBContext>()
                .AddDefaultTokenProviders();

            // Add Authentication
            //
            //It defines the mechanism through which the application verifies the identity of users or clients.
            builder.Services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    /*ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidAudience = "https://enaya.sa/",
                    ValidIssuer = "https://enaya.sa/",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Palestine")),
                    ValidateIssuerSigningKey = true*/
                };
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IInquiryService, InquiryService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IReceiptVoucherService, ReceiptVoucherService>();



            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
