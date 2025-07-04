namespace BlazorBasic.Models
{
    public class PollOption
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int VoteCount { get; set; } = 0;
    }
}