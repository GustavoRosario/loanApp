using LoanApp.Application.Dto;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using LoanApp.Domain.Dto;

namespace LoanApp.Application.Helpers
{
    public class WhatsApp
    {

        private string issuingTelephone = string.Empty;
        private string receiverTelephone = string.Empty;

        public async Task SendMessage(WhatsAppDto whatsaapDto)
        {
            const string ACCOUNT_SID = "";
            const string ATH_TOKEN = "";

            TwilioClient.Init(
                  ACCOUNT_SID,
                  ATH_TOKEN
                  );

            var message = await MessageResource.CreateAsync(
                from: new PhoneNumber("whatsapp:+1" + whatsaapDto.From),
                to: new PhoneNumber("whatsapp:+1" + whatsaapDto.To),
                body: whatsaapDto.Boby);
        }
    }
}
