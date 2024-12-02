using LoanApp.Domain.Dto;
using LoanApp.Domain.Ports.Repository;
using LoanApp.Infrastructure.Entity.Data;

namespace LoanApp.Application.Application.Adapters.Repository
{
    public class CommunicationChannelRepository : ICommunicationChannelRepository
    {
        private LoanAppDbContext LoanDbContext { get; set; }

        public CommunicationChannelRepository(LoanAppDbContext loanDbContext)
        {
            this.LoanDbContext = loanDbContext;
        }

        public async Task<List<CommunicationChannelDto>> GetData(int communicationChannelTypeId)
        {
            var lstCommunicationChannel = LoanDbContext.lo_communication_channel.Where(x => x.communication_channel_type_id == communicationChannelTypeId && x.active == true).ToList();

            var lst = lstCommunicationChannel.ConvertAll(x =>
            {
                return new CommunicationChannelDto()
                {
                    communication_channel_type_id = x.communication_channel_id,
                    communication_channel_name_value = x.communication_channel_value
                };
            });

            return await Task.Run(() => lst);
        }
    }
}
