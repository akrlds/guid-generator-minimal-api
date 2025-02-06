using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace GUIDGeneratorApi.Tests
{
    public class GUIDGeneratorApiTests : IClassFixture<WebApplicationFactory<GUIDGeneratorApi.Program>>
    {
        private readonly HttpClient _client;

        public GUIDGeneratorApiTests(WebApplicationFactory<GUIDGeneratorApi.Program> factory)
        {
            _client = factory.CreateClient();
        }

        private static async Task<string> GetGuidFromResponse(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(content);
            return jsonResponse.GetProperty("guid").GetString()!;
        }

        private static void AssertValidGuid(string guid)
        {
            Assert.True(Guid.TryParse(guid, out _));
        }

        private static void AssertUppercaseGuid(string guid)
        {
            Assert.Equal(guid, guid.ToUpper());
        }

        private static void AssertNoHyphensInGuid(string guid)
        {
            Assert.DoesNotContain("-", guid);
        }

        [Fact]
        public async Task GetGuid_ReturnsValidGuid()
        {
            var response = await _client.GetAsync("/api/guid");

            var guid = await GetGuidFromResponse(response);

            AssertValidGuid(guid);
        }

        [Fact]
        public async Task GetGuid_Uppercase_ReturnsUppercaseGuid()
        {
            var response = await _client.GetAsync("/api/guid?uppercase=true");

            var guid = await GetGuidFromResponse(response);

            AssertValidGuid(guid);
            AssertUppercaseGuid(guid);
        }


        [Fact]
        public async Task GetGuid_NoHyphens_ReturnsGuidWithoutHyphens()
        {
            var response = await _client.GetAsync("/api/guid?hyphens=false");

            var guid = await GetGuidFromResponse(response);

            AssertValidGuid(guid);
            AssertNoHyphensInGuid(guid);
        }
        
        [Fact]
        public async Task GetGuid_Uppercase_NoHyphens_ReturnsUppercaseGuidWithoutHyphens()
        {
            var response = await _client.GetAsync("/api/guid?hyphens=false&uppercase=true");

            var guid = await GetGuidFromResponse(response);

            AssertValidGuid(guid);
            AssertUppercaseGuid(guid);
            AssertNoHyphensInGuid(guid);
        }

    }
}