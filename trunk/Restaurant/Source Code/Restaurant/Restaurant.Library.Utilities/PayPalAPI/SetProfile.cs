using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using com.paypal.sdk.profiles;

namespace Restaurant.Library.Utilities.PayPalAPI
{
    internal class SetProfile
    {
        public static readonly IAPIProfile DefaultProfile = CreateAPIProfile(
                         AppEnv.API_USERNAME,
                          AppEnv.API_PASSWORD,
                           AppEnv.API_SIGNATURE,
                            "", "", Constants.CERTIFICATE, Constants.PRIVATE_KEY_PASSWORD);

        public static IAPIProfile CreateAPIProfile(
                        string apiUsername, string apiPassword, string signature,
                            string CertificateFile_Sig, string APISignature_Sig,
                                string CertificateFile_Cer, string PrivateKeyPassword_Cer)
        {
            IAPIProfile profile = ProfileFactory.createSignatureAPIProfile();
            profile.APIUsername = apiUsername;
            profile.APIPassword = apiPassword;
            profile.Environment = Constants.ENVIRONMENT;

            profile.Subject = string.Empty;
            profile.APISignature = signature;
            return profile;
        }

        public static void SetDefaultProfile()
        {
            SessionProfile = DefaultProfile;
        }

        public static IAPIProfile SessionProfile
        {
            get
            {
                return (IAPIProfile)HttpContext.Current.Session[Constants.PROFILE_KEY];
            }
            set
            {
                HttpContext.Current.Session[Constants.PROFILE_KEY] = value;
            }
        }
    }
}
