namespace BuriStore.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task SetVotesAsync(int itemId, string userId, double value);

        double GetAverageVotes(int itemId);
    }
}
