﻿using AutoMapper;
using StudentEnrollment.API.DTOs.Student;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.API.Endpoints
{
    public static class StudentEndpoints
    {
        public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/Student", async (IStudentRepository repo, IMapper mapper) =>
            {
                var students = await repo.GetAllAsync(); ;
                var data = mapper.Map<List<StudentDto>>(students);
                return data;
            })
            .WithTags(nameof(Student))
            .WithName("GetAllStudents")
            .Produces<List<StudentDto>>(StatusCodes.Status200OK);

            routes.MapGet("/api/Student/{id}", async (int Id, IStudentRepository repo, IMapper mapper) =>
            {
                return await repo.GetAsync(Id)
                    is Student model
                        ? Results.Ok(mapper.Map<StudentDto>(model))
                        : Results.NotFound();
            })
            .WithTags(nameof(Student))
            .WithName("GetStudentById")
            .Produces<StudentDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            routes.MapGet("/api/Student/GetDetails/{id}", async (int Id, IStudentRepository repo, IMapper mapper) =>
            {
                return await repo.GetStudentDetails(Id)
                    is Student model
                        ? Results.Ok(mapper.Map<StudentDetailsDto>(model))
                        : Results.NotFound();
            })
            .WithTags(nameof(Student))
            .WithName("GetStudentDetailsById")
            .Produces<StudentDetailsDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            routes.MapPut("/api/Student/{id}", async (int Id, StudentDto studentDto, IStudentRepository repo, IMapper mapper) =>
            {
                var foundModel = await repo.GetAsync(Id);

                if (foundModel is null)
                {
                    return Results.NotFound();
                }
                //update model properties here
                mapper.Map(studentDto, foundModel);
                await repo.UpdateAsync(foundModel);
                return Results.NoContent();
            })
            .WithTags(nameof(Student))
            .WithName("UpdateStudent")
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status204NoContent);

            routes.MapPost("/api/Student/", async (CreateStudentDto studentDto, IStudentRepository repo, IMapper mapper) =>
            {
                var student = mapper.Map<Student>(studentDto);
                await repo.AddAsync(student);
                return Results.Created($"/Students/{student.Id}", student);
            })
            .WithTags(nameof(Student))
            .WithName("CreateStudent")
            .Produces<Student>(StatusCodes.Status201Created);

            routes.MapDelete("/api/Student/{id}", async (int Id, IStudentRepository repo, IMapper mapper) =>
            {
                return await repo.DeleteAsync(Id) ? Results.NoContent() : Results.NotFound();
            })
            .WithTags(nameof(Student))
            .WithName("DeleteStudent")
            .Produces<Student>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
