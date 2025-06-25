using BlazorBasic.Models;
using Xunit;

namespace BlazorBasic.Tests.Models
{
    public class PollOptionTests
    {
        [Fact]
        public void PollOption_InitializesWithDefaultValues()
        {
            // Act
            var pollOption = new PollOption();

            // Assert
            Assert.Equal(string.Empty, pollOption.Id);
            Assert.Equal(string.Empty, pollOption.Title);
            Assert.Equal(string.Empty, pollOption.Description);
            Assert.Equal(0, pollOption.VoteCount);
        }

        [Fact]
        public void PollOption_CanSetAllProperties()
        {
            // Arrange
            var pollOption = new PollOption();
            var id = "test-id";
            var title = "Test Title";
            var description = "Test Description";
            var voteCount = 5;

            // Act
            pollOption.Id = id;
            pollOption.Title = title;
            pollOption.Description = description;
            pollOption.VoteCount = voteCount;

            // Assert
            Assert.Equal(id, pollOption.Id);
            Assert.Equal(title, pollOption.Title);
            Assert.Equal(description, pollOption.Description);
            Assert.Equal(voteCount, pollOption.VoteCount);
        }

        [Fact]
        public void PollOption_VoteCountCanBeIncremented()
        {
            // Arrange
            var pollOption = new PollOption();
            
            // Act
            pollOption.VoteCount++;
            pollOption.VoteCount++;

            // Assert
            Assert.Equal(2, pollOption.VoteCount);
        }
    }
}