﻿using FluentValidation;
using StudentEnrollment.API.DTOs;
using StudentEnrollment.API.DTOs.Authentication;
using StudentEnrollment.API.Filters;
using StudentEnrollment.API.Services;

namespace StudentEnrollment.API.Endpoints
{
    public static class AuthenticationEndpoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/login/", async (LoginDto loginDto, IAuthManager authManager, IValidator<LoginDto> validator) =>
            {
                var response = await authManager.Login(loginDto);

                if (response is null)
                {
                    return Results.Unauthorized();
                }

                return Results.Ok(response);

            })
            .AddEndpointFilter<ValidatationFilter<LoginDto>>()
            .AllowAnonymous()
            .WithTags("Authentication")
            .WithName("Login")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status401Unauthorized);

            routes.MapPost("/api/register/", async (RegisterDto registerDto, IAuthManager authManager, IValidator<RegisterDto> validator) =>
            {
                var response = await authManager.Register(registerDto);

                if (!response.Any())
                {
                    return Results.Ok();
                }

                var errors = new List<ErrorResponseDto>();
                foreach (var error in response)
                {
                    errors.Add(new ErrorResponseDto
                    {
                        Code = error.Code,
                        Description = error.Description
                    });
                }

                return Results.BadRequest(errors);

            })
            .AddEndpointFilter<ValidatationFilter<RegisterDto>>()
            .AllowAnonymous()
            .WithTags("Authentication")
            .WithName("Register")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
