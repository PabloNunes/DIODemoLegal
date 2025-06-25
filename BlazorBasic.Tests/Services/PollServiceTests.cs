using BlazorBasic.Models;
using BlazorBasic.Services;
using Microsoft.JSInterop;
using Moq;
using System.Text.Json;
using Xunit;

namespace BlazorBasic.Tests.Services
{
    public class PollServiceTests
    {
        private readonly Mock<IJSRuntime> _mockJSRuntime;
        private readonly PollService _pollService;

        public PollServiceTests()
        {
            _mockJSRuntime = new Mock<IJSRuntime>();
            _pollService = new PollService(_mockJSRuntime.Object);
        }

        [Fact]
        public async Task GetPollDataAsync_WhenNoDataInLocalStorage_ReturnsInitialPollData()
        {
            // Arrange
            _mockJSRuntime.Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
                .ReturnsAsync((string?)null);

            // Act
            var result = await _pollService.GetPollDataAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Options.Count);
            Assert.False(result.HasVoted);
            Assert.Contains(result.Options, o => o.Id == "agentic-ai");
            Assert.Contains(result.Options, o => o.Id == "simple-llms");
            Assert.Contains(result.Options, o => o.Id == "mcp-protocol");
        }

        [Fact]
        public async Task GetPollDataAsync_WhenValidDataInLocalStorage_ReturnsStoredData()
        {
            // Arrange
            var storedPollData = new PollData
            {
                Options = new List<PollOption>
                {
                    new PollOption { Id = "test", Title = "Test Option", VoteCount = 5 }
                },
                HasVoted = true,
                VotedOptionId = "test",
                VotedAt = DateTime.Now
            };
            var json = JsonSerializer.Serialize(storedPollData);
            
            _mockJSRuntime.Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
                .ReturnsAsync(json);

            // Act
            var result = await _pollService.GetPollDataAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result.Options);
            Assert.True(result.HasVoted);
            Assert.Equal("test", result.VotedOptionId);
            Assert.Equal("test", result.Options.First().Id);
        }

        [Fact]
        public async Task VoteAsync_WhenAlreadyVoted_ReturnsFalse()
        {
            // Arrange
            var pollData = new PollData
            {
                Options = new List<PollOption>
                {
                    new PollOption { Id = "agentic-ai", Title = "IA Agêntica", VoteCount = 0 }
                },
                HasVoted = true,
                VotedOptionId = "agentic-ai"
            };
            var json = JsonSerializer.Serialize(pollData);
            
            _mockJSRuntime.Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
                .ReturnsAsync(json);

            // Act
            var result = await _pollService.VoteAsync("agentic-ai");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task HasVotedAsync_WhenNotVoted_ReturnsFalse()
        {
            // Arrange
            _mockJSRuntime.Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
                .ReturnsAsync((string?)null);

            // Act
            var result = await _pollService.HasVotedAsync();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task HasVotedAsync_WhenVoted_ReturnsTrue()
        {
            // Arrange
            var pollData = new PollData
            {
                Options = new List<PollOption>(),
                HasVoted = true
            };
            var json = JsonSerializer.Serialize(pollData);
            
            _mockJSRuntime.Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
                .ReturnsAsync(json);

            // Act
            var result = await _pollService.HasVotedAsync();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetResultsAsync_ReturnsAllPollOptions()
        {
            // Arrange
            _mockJSRuntime.Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
                .ReturnsAsync((string?)null);

            // Act
            var results = await _pollService.GetResultsAsync();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(3, results.Count);
            Assert.Contains(results, o => o.Id == "agentic-ai");
            Assert.Contains(results, o => o.Id == "simple-llms");
            Assert.Contains(results, o => o.Id == "mcp-protocol");
        }

        [Fact]
        public async Task GetTotalVotesAsync_ReturnsCorrectTotal()
        {
            // Arrange
            var pollData = new PollData
            {
                Options = new List<PollOption>
                {
                    new PollOption { Id = "option1", VoteCount = 5 },
                    new PollOption { Id = "option2", VoteCount = 3 },
                    new PollOption { Id = "option3", VoteCount = 2 }
                }
            };
            var json = JsonSerializer.Serialize(pollData);
            
            _mockJSRuntime.Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
                .ReturnsAsync(json);

            // Act
            var totalVotes = await _pollService.GetTotalVotesAsync();

            // Assert
            Assert.Equal(10, totalVotes);
        }

        [Fact]
        public async Task GetTotalVotesAsync_WhenNoVotes_ReturnsZero()
        {
            // Arrange
            _mockJSRuntime.Setup(js => js.InvokeAsync<string>("localStorage.getItem", It.IsAny<object[]>()))
                .ReturnsAsync((string?)null);

            // Act
            var totalVotes = await _pollService.GetTotalVotesAsync();

            // Assert
            Assert.Equal(0, totalVotes);
        }
    }
}