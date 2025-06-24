using BlazorBasic.Models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace BlazorBasic.Services
{
    public class PollService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string POLL_DATA_KEY = "studentPollData";
        private PollData? _cachedPollData;

        public PollService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<PollData> GetPollDataAsync()
        {
            if (_cachedPollData != null)
                return _cachedPollData;

            try
            {
                var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", POLL_DATA_KEY);
                
                if (!string.IsNullOrEmpty(json))
                {
                    _cachedPollData = JsonSerializer.Deserialize<PollData>(json);
                }
                
                if (_cachedPollData == null)
                {
                    _cachedPollData = CreateInitialPollData();
                    await SavePollDataAsync(_cachedPollData);
                }

                return _cachedPollData;
            }
            catch (Exception)
            {
                _cachedPollData = CreateInitialPollData();
                await SavePollDataAsync(_cachedPollData);
                return _cachedPollData;
            }
        }

        public async Task<bool> VoteAsync(string optionId)
        {
            var pollData = await GetPollDataAsync();
            
            if (pollData.HasVoted)
                return false;

            var option = pollData.Options.FirstOrDefault(o => o.Id == optionId);
            if (option == null)
                return false;

            option.VoteCount++;
            pollData.HasVoted = true;
            pollData.VotedOptionId = optionId;
            pollData.VotedAt = DateTime.Now;

            await SavePollDataAsync(pollData);
            return true;
        }

        public async Task<bool> HasVotedAsync()
        {
            var pollData = await GetPollDataAsync();
            return pollData.HasVoted;
        }

        public async Task<List<PollOption>> GetResultsAsync()
        {
            var pollData = await GetPollDataAsync();
            return pollData.Options;
        }

        public async Task<int> GetTotalVotesAsync()
        {
            var pollData = await GetPollDataAsync();
            return pollData.Options.Sum(o => o.VoteCount);
        }

        private async Task SavePollDataAsync(PollData pollData)
        {
            var json = JsonSerializer.Serialize(pollData);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", POLL_DATA_KEY, json);
            _cachedPollData = pollData;
        }

        private static PollData CreateInitialPollData()
        {
            return new PollData
            {
                Options = new List<PollOption>
                {
                    new PollOption
                    {
                        Id = "agentic-ai",
                        Title = "IA Agêntica",
                        Description = "Sistemas de inteligência artificial que agem de forma autônoma"
                    },
                    new PollOption
                    {
                        Id = "simple-llms",
                        Title = "Implantação de LLMs Simples",
                        Description = "Deploy e implementação de modelos de linguagem em produção"
                    },
                    new PollOption
                    {
                        Id = "mcp-protocol",
                        Title = "Protocolo MCP (Model Context Protocol)",
                        Description = "Protocolo para comunicação e contexto entre modelos"
                    }
                }
            };
        }
    }
}