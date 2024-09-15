using LoanApp.Domain.Dto;

namespace LoanApp.Domain.Ports.Repository
{
    public interface ICommunicationChannelRepository
    {
        public Task<List<CommunicationChannelDto>> GetData(int communicationChannelTypeId);
    }
}
