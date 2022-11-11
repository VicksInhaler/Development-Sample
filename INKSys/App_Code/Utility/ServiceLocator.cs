using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wsLdapService;
using wsLoginService;

/// <summary>
/// Summary description for ServiceLocator
/// </summary>
public class ServiceLocator
{
    private static LdapService LdapService = null;
    private static LoginService LoginService = null;
    public ServiceLocator()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static LdapService GetLdapService()
    {
        if (LdapService == null)
        {
            LdapService = new LdapService();
            LdapService.Url = System.Configuration.ConfigurationManager.AppSettings["wsLdapServiceString"];

            //if (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["webClientProtocolTimeout"]) == -1)
            //{
            LdapService.Timeout = System.Threading.Timeout.Infinite;
            //}
            //else
            //{
            //    ldapService.Timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["webClientProtocolTimeout"]);
            //}

            LdapService.Credentials = System.Net.CredentialCache.DefaultCredentials;
        }

        return LdapService;
    }
    public static LoginService GetLoginService()
    {
        if (LoginService == null)
        {
            LoginService = new LoginService();
            LoginService.Url = System.Configuration.
                ConfigurationManager.AppSettings["wsLoginServiceString"];

            if (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["webClientProtocolTimeout"]) == -1)
            {
                LoginService.Timeout = System.Threading.Timeout.Infinite;
            }
            else
            {
                LoginService.Timeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["webClientProtocolTimeout"]);
            }

            LoginService.Credentials = System.Net.CredentialCache.DefaultCredentials;
        }

        return LoginService;
    }

}