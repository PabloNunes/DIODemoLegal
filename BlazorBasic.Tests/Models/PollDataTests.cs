using BlazorBasic.Models;
using Xunit;

namespace BlazorBasic.Tests.Models
{
    public class PollDataTests
    {
        [Fact]
        public void PollData_InitializesWithDefaultValues()
        {
            // Act
            var pollData = new PollData();

            // Assert
            Assert.NotNull(pollData.Options);
            Assert.Empty(pollData.Options);
            Assert.False(pollData.HasVoted);
            Assert.Null(pollData.VotedOptionId);
            Assert.Null(pollData.VotedAt);
        }

        [Fact]
        public void PollData_CanSetAllProperties()
        {
            // Arrange
            var pollData = new PollData();
            var options = new List<PollOption>
            {
                new PollOption { Id = "option1", Title = "Option 1" },
                new PollOption { Id = "option2", Title = "Option 2" }
            };
            var hasVoted = true;
            var votedOptionId = "option1";
            var votedAt = DateTime.Now;

            // Act
            pollData.Options = options;
            pollData.HasVoted = hasVoted;
            pollData.VotedOptionId = votedOptionId;
            pollData.VotedAt = votedAt;

            // Assert
            Assert.Equal(options, pollData.Options);
            Assert.Equal(hasVoted, pollData.HasVoted);
            Assert.Equal(votedOptionId, pollData.VotedOptionId);
            Assert.Equal(votedAt, pollData.VotedAt);
        }

        [Fact]
        public void PollData_OptionsCollectionCanBeModified()
        {
            // Arrange
            var pollData = new PollData();
            var option1 = new PollOption { Id = "option1", Title = "Option 1" };
            var option2 = new PollOption { Id = "option2", Title = "Option 2" };

            // Act
            pollData.Options.Add(option1);
            pollData.Options.Add(option2);

            // Assert
            Assert.Equal(2, pollData.Options.Count);
            Assert.Contains(option1, pollData.Options);
            Assert.Contains(option2, pollData.Options);
        }

        [Fact]
        public void PollData_CanTrackVotingState()
        {
            // Arrange
            var pollData = new PollData();
            var votedOptionId = "test-option";
            var votedAt = DateTime.Now;

            // Act
            pollData.HasVoted = true;
            pollData.VotedOptionId = votedOptionId;
            pollData.VotedAt = votedAt;

            // Assert
            Assert.True(pollData.HasVoted);
            Assert.Equal(votedOptionId, pollData.VotedOptionId);
            Assert.Equal(votedAt, pollData.VotedAt);
        }
    }
}