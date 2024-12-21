using API.IntegrationTest.Dto;
using API.IntegrationTest.SeedData;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.IntegrationTest.API
{
    public class CandidateControllerTest : BaseIntegrationTest
    {
        public CandidateControllerTest() : base(nameof(CandidateControllerTest))
        {
        }

        [Theory]
        [MemberData(nameof(ValidCandidateData))]
        public async Task Post_ValidInput_ShouldCreateCandidate(CandidateDto candidateDto)
        {
            // Arrange
            var jsonContent = JsonSerializer.Serialize(candidateDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/candidate", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode); // Ensure the candidate was created.

            var responseString = await response.Content.ReadAsStringAsync();
            var createdCandidate = JsonSerializer.Deserialize<CandidateDto>(responseString);

            // Check if the created candidate has the correct data.
            Assert.Equal(candidateDto.email, createdCandidate.first_name);
            Assert.Equal(candidateDto.phone_number, createdCandidate.phone_number);
        }

        [Theory]
        [MemberData(nameof(InvalidCandidateData))]
        public async Task Post_InvalidInput_ShouldReturnBadRequest(CandidateDto candidateDto)
        {
            // Arrange
            var jsonContent = JsonSerializer.Serialize(candidateDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/candidate", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode); // Ensure the request failed due to invalid data.
        }

        public static IEnumerable<object[]> ValidCandidateData()
        {
            yield return new object[]
            {
                new CandidateDto
                {
                    Id = Guid.NewGuid().ToString(),
                    first_name = "Hari",
                    last_name = "Ram",
                    email = "hari.ram@example.com",
                    phone_number = "123-456-7890",
                    time_to_call = DateTime.UtcNow.AddHours(1),
                    linkedin_profile = "https://www.linkedin.com/in/hariram",
                    github_profile = "https://github.com/hariram",
                    comment = "Candidate No. 1"
                }
            };
        }

        public static IEnumerable<object[]> InvalidCandidateData()
        {
            yield return new object[]
            {
                new CandidateDto
                {
                    first_name = "sita",
                    last_name = "thapa",
                    email = "Sita", // Invalid email
                    phone_number = "987-654-3210"
                }
            };
        }
    }
}
