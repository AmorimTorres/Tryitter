using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Rede_Social_Da_Galera___Tryitter.Models;
using System.Net;
using System.Net.Http.Json;

namespace TryitterTests
{
    public class StudentTest : IClassFixture<StudentTestContext<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public StudentTest(StudentTestContext<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task ShouldRequestStudent()
        {
            var client = _factory.CreateClient();
            var requisition = await client.GetAsync("/Student");
            requisition.Should().BeSuccessful();
        }

        [Fact]
        public async Task ShouldCreateAStudent()
        {
            var client = _factory.CreateClient();

            var student = new Student
            {
                StudentId = 1,
                StudentName = "andre",
                StudentEmail = "andre@email.com",
                CourseModule = "avançado",
                Status = "indo",
                Password = "12345678",
            };
            using HttpResponseMessage response = await client
                 .PostAsJsonAsync("student", student);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
