namespace BuriStore.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BuriStore.Data.Common.Repositories;
    using BuriStore.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int itemId)
        {
            return this.votesRepository.All()
                   .Where(x => x.ItemId == itemId)
                   .Average(x => x.Value);
        }

        public async Task SetVotesAsync(int itemId, string userId, double value)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.ItemId == itemId && x.UserId == userId);
            if (vote == null)
            {
                vote = new Vote
                {
                    ItemId = itemId,
                    UserId = userId,
                };
                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
