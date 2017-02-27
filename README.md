# GatorMail API C# Example


This code is a simple console application to show how easy it is to send emails via the CommuniGator API and how to generate and insert your own content into pre-existing templates.


*Please note, this example assumes knowledge of the CommuniGator product and a basic understanding of email and campaign creation. Please refer to the knowledgebase at [https://help.communigator.co.uk](https://help.communigator.co.uk) or speak to your account manager to organise a training session.*



The console app demonstrates connection to our SOAP web service via a web reference in visual studio. The XML must be passed as a string to the service.



### Prerequisites to API email creation

A couple of things must be completed before you can trigger emails through the API, namely creating an email and a campaign.

Create an email as normal. Use the template HTML that we've provided (TemplateHTML.html). Please note - the HTML we will be inserting will replace `#[MERGEFIELD1]#`. You can have up to ten mergefields in an email, if you want to customise the email further than a single block for your future sends.

Attach this email to a new campaign and make the campaign type 'Follow Up / Workflow Campaign'. This will remove the need for an audience. Set up any other details you would like to add for the campaign and then initiate it. Note the campaign ID - you can find this in the URL when in the campaign editing screen, after `itemid=`.

There are two XML files in the same directory as the exe for the code. They contain different HTML in the mergefield to demonstrate how different you can make emails look. Specify the correct camapignid and change the contact details to be yourself. You can set a datetime to send the campaign if that is required.

In the code, find where the Username, Password and Instancename is specified.

    var api = new ApiCalls("USERNAME", "PASSWORD", "INSTANCENAME");

Set these to be correct for your instance. You can find the details under Tools -> Integration (security subtab) in the front end.

Your IP address may not be authorised with that instance. You can either add the IP if you have admin level access, or temporarily switch off IP authentication on the same security subtab during testing.

Ensure the credentials are correct by peforming the authenticationcheck call (option 1 in the console app).

### All done!

You can now send emails via the UploadContactTriggerCampaign call. There are a couple of other calls added to show some extra functionality. For a full list of calls, please reference our [SDK documentation](http://help.communigator.co.uk/m/BespokeIntegrations/l/312411-communigator-sdk-integration) and visit the [SDK URL](https://www.communigatormail.co.uk/SDK.asmx) for more info.
