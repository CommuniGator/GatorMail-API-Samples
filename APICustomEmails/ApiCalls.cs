﻿using System;
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
        //private string CompEmailxml;
        private string contactXML;
        private string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
 


        private API.SDK _api;



        //Set username, password and instance name. Set URL for API commands
        //
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

            try
            {
                XmlDocument xml1 = new XmlDocument();
                xml1.Load(Path.Combine(rootPath, @"data\Email1.xml"));
                Email1xml = xml1.OuterXml;

                XmlDocument xml2 = new XmlDocument();
                xml2.Load(Path.Combine(rootPath, @"data\Email2.xml"));
                Email2xml = xml2.OuterXml;

                XmlDocument xml3 = new XmlDocument();
                xml3.Load(Path.Combine(rootPath, @"data\ContactXML.xml"));
                contactXML = xml3.OuterXml;

                /*
                XmlDocument xmlEmail = new XmlDocument();
                xmlEmail.Load(Path.Combine(rootPath, @"CompEmail.xml"));
                CompEmailxml = xmlEmail.OuterXml;
                */



            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("XML file error, please check code.");
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

        //Create Email
        public string CreateEmail()
        {
            string text;
            using (var streamReader = new StreamReader(Path.Combine(rootPath, @"email.html"), Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }


            var result = _api.createEmail("testSCG", text, "ljkhdafa");

            return result.ToString();

        }

        //Update Campaign
        public string UpdateCampaign()
        {
            var date = new DateTime(2017, 03, 16);

            var result = _api.updateCampaign(14285, date, "sam@supporttesting.geml1.co.uk", "Test", "sam@communigator.co.uk", "This is a test", "Attached Email", 19276);

            return result.ToString();
        }
        //Insert Contact

        public string InsertContact()
        {
            var result = _api.UpdateContact(contactXML);

            return result;
    
    }

    }
}
