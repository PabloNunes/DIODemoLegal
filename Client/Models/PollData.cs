namespace BlazorBasic.Models
{
    public class PollData
    {
        public List<PollOption> Options { get; set; } = new List<PollOption>();
        public bool HasVoted { get; set; } = false;
        public string? VotedOptionId { get; set; }
        public DateTime? VotedAt { get; set; }
    }
}