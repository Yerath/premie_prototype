using System;
using VPIService.Interfaces;
using VPIService.VolmachtVPITokenWebservice;

namespace VPIService.Agents
{
    public class VPIAgent : IVPIAgent
    {
        private readonly TokenWebServiceSoapClient _client;

        public VPIAgent()
        {
            _client = new VolmachtVPITokenWebservice.TokenWebServiceSoapClient();
        }

        public string GetToken()
        {
            var token = String.Empty;

            var result = _client.GetToken(
                Properties.Settings.Default["VPI_appKey"].ToString(),
                Properties.Settings.Default["VPI_username"].ToString(),
                Properties.Settings.Default["VPI_password"].ToString(),
                out token
            );

            if (string.IsNullOrEmpty(token))
                throw new Exception(String.Format("VPI webservice call (token opvragen) failed: {0}",
                    result.Description));

            return token;
        }

    }
}
