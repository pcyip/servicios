using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.AppCode
{
    public class DriveOAuthAuthentication
    {
        /*
        private const string SERVICE_ACCOUNT_EMAIL = "757354324172-9hkiqk474v127g9qli1ufpa25j2tgnh1@developer.gserviceaccount.com";
        private const string SERVICE_ACCOUNT_PKCS12_FILE_PATH = @"\path\to\<public_key_fingerprint>-privatekey.p12";

        /// <summary>
        /// Build a Drive service object authorized with the service account.
        /// </summary>
        /// <returns>Drive service object.</returns>
        static DriveService BuildService()
        {
            X509Certificate2 certificate = new X509Certificate2(SERVICE_ACCOUNT_PKCS12_FILE_PATH, "notasecret",
                X509KeyStorageFlags.Exportable);

            var provider = new AssertionFlowClient(GoogleAuthenticationServer.Description, certificate)
            {
                ServiceAccountId = SERVICE_ACCOUNT_EMAIL,
                Scope = DriveService.Scopes.Drive.GetStringValue(),
            };
            var auth = new OAuth2Authenticator<AssertionFlowClient>(provider, AssertionFlowClient.GetState);

            return new DriveService(auth);
        }
        */
    }
}