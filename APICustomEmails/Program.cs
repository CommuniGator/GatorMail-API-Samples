using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICustomEmails
{
    class Program
    {
        static void Main(string[] args)
        {   ////SET THESE PARAMETERS FROM THE SDK USERNAME (INSTANCE ENDS IN LZ). YOU CAN ACCESS THIS IN THE FRONT END OF COMMUNIGATOR UNDER TOOLS-> INTEGRATION AND THEN THE SECURITY TAB
            var api = new ApiCalls("***SDK USER***", "***SDK PASSWORD***", "***LZ NAME***");


         
                Console.WriteLine("Preloading XML files");
                api.LoadXML();
            
          
                Console.WriteLine("XML Files Loaded");
                Console.WriteLine("\n");

                int choice = 0;
                Console.WriteLine("Welcome to the CommuniGator API test app, please select one of the following options (press 0 to quit):");

                do
                {

                    Console.WriteLine("\n");
                    Console.WriteLine("/////////////////////////////////////");
                    Console.WriteLine("1. Perform authentication check");
                    Console.WriteLine("2. Send email 1");
                    Console.WriteLine("3. Send email 2");
                    Console.WriteLine("/////////////////////////////////////");
                    Console.WriteLine("\n");
                    Console.WriteLine("Examples of other API calls (for use with tracked links/opens from sent emails)");
                    Console.WriteLine("/////////////////////////////////////");
                    Console.WriteLine("4. Return campaign stats");
                    Console.WriteLine("5. Return sent emails");
                    Console.WriteLine("6. Reset counter for above");
                    Console.WriteLine("7. Update Campaign");
                    Console.WriteLine("8. Update Contact. Will insert if not found. (via XML)");
                    Console.WriteLine("/////////////////////////////////////");
                    var ans = Console.ReadLine();


                    choice = InputHandler(api, ans);
                } while (choice != 0);
            
            
        }




        private static int InputHandler(ApiCalls api, string ans)
        {
            int choice;
            if (int.TryParse(ans, out choice))
            {

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(api.AuthenticationCheck());
                        break;

                    case 2:
                        Console.WriteLine(api.SendEmail1());
                        break;

                    case 3:
                        Console.WriteLine(api.SendEmail2());
                        break;


                    case 4:
                        Console.WriteLine("Please enter the campaign id:");
                        string id1 = Console.ReadLine();
                        int id = 0;
                        int.TryParse(id1, out id);
                        Console.WriteLine(api.ReturnCampaignStats(id));
                        break;

                    case 5:
                        Console.WriteLine(api.ReturnSentEmails());
                        break;

                    case 6:
                        Console.WriteLine(api.ResetCounter());
                        break;

                    case 7:
                        Console.WriteLine(api.UpdateCampaign());
                        break;

                    case 8:
                        Console.WriteLine("Updating/Inserting contact. Returned int is contactid.");
                        Console.WriteLine(api.InsertContact());
                        break;

                    case 0:
                        break;

                }
            }

            return choice;
        }
    }
}
