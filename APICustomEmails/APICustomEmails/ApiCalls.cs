using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;

namespace APICustomEmails
{
    public class ApiCalls
    {
        //Declare Variables
        private string Username { get; set; }
        private string Password { get; set; }
        private string InstanceName { get; set; }
        private string Email1xml;
        private string Email2xml;


        private API.SDK _api;



        //Set username, password and instance name. Set URL for API commands
        public ApiCalls(string username, string password, string instancename)
        {
            _api = new API.SDK();

            Username = username;
            Password = password;
            InstanceName = instancename;

            _api.AuthHeaderValue = new API.AuthHeader()
            {
                Username = this.Username,
                Password = this.Password
            };

            _api.Url = $"http://www.communigatormail.co.uk/{InstanceName}/SDK.asmx";
        }




        //Preload XML files. Use OuterXml as it needs to be in string format
        public void LoadXML()
        {

            var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                XmlDocument xml1 = new XmlDocument();
                xml1.Load(Path.Combine(rootPath, @"Email1.xml"));
                Email1xml = xml1.OuterXml;

                XmlDocument xml2 = new XmlDocument();
                xml2.Load(Path.Combine(rootPath, @"Email2.xml"));
                Email2xml = xml2.OuterXml;
                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Warning! XML files not found! Ensure that ExistingCustomer.xml and NewCustomer.xml are present in exe folder");
                Console.WriteLine("Please press enter to try again");
                Console.ReadLine();
                LoadXML();
            }

        }




        //////////////////////////////////////////////////////////////////Begin API call list


        //Authentication Check
        public string AuthenticationCheck()
        {
            var result = _api.AuthenticationCheck();
            return result;
        }


        //Send email 1
        public string SendEmail1()
        {
            var result = _api.UploadContactTriggerCampaign(Email1xml);
            return result;
        }
    
        //Send email 2
        public string SendEmail2()
        {
            var result = _api.UploadContactTriggerCampaign(Email2xml);
            return result;
        }

        //Return Campaign Stats
        public string ReturnCampaignStats(int id)
        {
            var result = _api.CampaignStats(id);

            return result.ToString();
        }

        //Return sent emails
        public string ReturnSentEmails()
        {
            var result = _api.ReturnSentEmails();

            return result.ToString();
        }

        //Reset counter
        public string ResetCounter()
        {
            var result = _api.ResetCounter("ReturnSentEmails");

            return result.ToString();
        }
    }
}
