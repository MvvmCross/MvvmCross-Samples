using System.Collections.Generic;

namespace InternetMinute.Core.Services.Times
{
    public class DescriptionService : IDescriptionService
    {
        public List<Description> Descriptions { get; private set; }

        public DescriptionService()
        {
            // source http://www.intel.co.uk/content/www/us/en/communications/internet-minute-infographic.html
            Descriptions = new List<Description>()
                {
                    new Description(
                        "GB Global IP Data transfer",
                        "http://i.imgur.com/0FMXZ1r.png",
                        639800),
                    new Description(
                        "BotNet infection",
                        "http://i.imgur.com/VTC3ptT.png",
                        135),
                    new Description(
                        "New Wikipedia Articles",
                        "http://i.imgur.com/rb9ABgp.jpg",
                        6),
                    new Description(
                        "Victims of Identity Theft",
                        "http://i.imgur.com/qSIyhMk.png",
                        20),
                    new Description(
                        "Emails sent",
                        "http://i.imgur.com/8MrcqyM.jpg",
                        204000000),
                    new Description(
                        "New Mobile Users",
                        "http://i.imgur.com/DlSsyHP.jpg",
                        1300),
                    new Description(
                        "Apps Downloaded",
                        "http://i.imgur.com/qIjKyE4.jpg",
                        47000),
                    new Description(
                        "$ Amazon Sales",
                        "http://i.imgur.com/cda070E.jpg",
                        83000),
                    new Description(
                        "Pandora Music Minutes",
                        "http://i.imgur.com/uaoatQa.jpg",
                        3668460),
                    new Description(
                        "New LinkedIn Accounts",
                        "http://i.imgur.com/j4bPOTv.png",
                        100),
                    new Description(
                        "Flickr Photo Views",
                        "http://i.imgur.com/ZcnmLpC.jpg",
                        20000000),
                    new Description(
                        "Flickr Photo Uploads",
                        "http://i.imgur.com/ZcnmLpC.jpg",
                        3000),
                    new Description(
                        "New Twitter Accounts",
                        "http://i.imgur.com/QCLowLf.png",
                        320),
                    new Description(
                        "New Tweets",
                        "http://i.imgur.com/QCLowLf.png",
                        100000),
                    new Description(
                        "Facebook Views",
                        "http://i.imgur.com/Np1qLLT.png",
                        6000000),
                    new Description(
                        "Facebook Logins",
                        "http://i.imgur.com/Np1qLLT.png",
                        277000),
                    new Description(
                        "Google Searches",
                        "http://i.imgur.com/tUVGRXq.jpg",
                        2000000),
                    new Description(
                        "YouTube Video Views",
                        "http://i.imgur.com/fbGq1fM.jpg",
                        1300000),
                    new Description(
                        "YouTube Video Minutes Uploaded",
                        "http://i.imgur.com/fbGq1fM.jpg",
                        1800),
                };
        }
    }
}