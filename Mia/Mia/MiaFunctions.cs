using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Media.SpeechRecognition;
using Windows.Storage;

using Windows.System;

namespace Mia
{
    

    class MiaFunctions
    {

        private static string userSpeech = "";

        private readonly static IReadOnlyDictionary<string, Delegate> vcdLookup = new Dictionary<string, Delegate>{
                    /*
            {<command name from VCD>, (Action)(async () => {
                 <code that runs when that commmand is called>
            })}
            */

           

            {"laurie", (Action)(async () => {
                 Uri website = new Uri(@"https://employeeprofile.ge.com/employeeprofile/people/216000327");
                 await Launcher.LaunchUriAsync(website);
             })},

            {"redirect", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/");
                 await Launcher.LaunchUriAsync(website);
             })},

             {"google", (Action)(async () => {
                 Uri website = new Uri(@"https://www.google.com/#q=" + userSpeech);
                 await Launcher.LaunchUriAsync(website);
             })},

             {"search", (Action)(async () => {
                 Uri website = new Uri(@"http://search.ge.com/#All/" + userSpeech);
                 await Launcher.LaunchUriAsync(website);
             })},

             {"email", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/subscribeMailAndData.do?sysparm=all");
                 await Launcher.LaunchUriAsync(website);
             })},

              {"helpdesk", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/Helpdesk/");
                 await Launcher.LaunchUriAsync(website);
             })},

              {"requestConferencing", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/requestCommunication.do?sysparam=Conferencing");
                 await Launcher.LaunchUriAsync(website);
             })},

               {"requestConnectivity", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/connectivity.do");
                 await Launcher.LaunchUriAsync(website);
             })},

              {"openMyTech", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/");
                 await Launcher.LaunchUriAsync(website);
             })},

            { "openMyTechnology", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/mytechnology.do");
                 await Launcher.LaunchUriAsync(website);
            })},

             { "openMyTeamsTechnology", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/mytechnology.do");
                 await Launcher.LaunchUriAsync(website);
            })},


            { "managePhones", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/manageCommunication.do?sysparam=Phones");
                 await Launcher.LaunchUriAsync(website);
            })},

            { "openMyTechGuide", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/kb_view.do?sysparm_article=KB1467713");
                 await Launcher.LaunchUriAsync(website);
            })},



            { "openAccessories", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/accessoriesSpecialOrder.do");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"requestAccessories", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/accessoriesSpecialOrder.do");
                 await Launcher.LaunchUriAsync(website);
            })},


            { "isBrokenAccessory", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/accessoriesSpecialOrder.do");
                 await Launcher.LaunchUriAsync(website);
            })},

            {"openRequests", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/my_requests.do");
                 await Launcher.LaunchUriAsync(website);
            })},

            {"openPCRefresh", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/lifeEvents.do?sysparm=refreshUpgrade&sys_type=comms#/compDevices");
                 await Launcher.LaunchUriAsync(website);
            })},

            {"openMobileRefresh", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/lifeEvents.do?sysparm=refreshUpgrade&sys_type=comms#/commsDevices");
                 await Launcher.LaunchUriAsync(website);
            })},

            {"isBrokenPhone", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/lifeEvents.do?sysparm=replaceBroken#/commsDevices");
                 await Launcher.LaunchUriAsync(website);
            })},

            {"isBrokenComputer", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/lifeEvents.do?sysparm=replaceBroken#/compDevices//");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"missingComputer", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/lifeEvents.do?sysparm=lostStolen");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"missingMobile", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/lifeEvents.do?sysparm=lostStolen#/commsDevices");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"openComputerReq", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/computers.do");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"requestPhone", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/requestCommunication.do?sysparam=Phones");
                 await Launcher.LaunchUriAsync(website);
            })},

              {"phoneFeatures", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/addRemoveFeatureRedesign.do");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"reassignPC", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/manage_request.do?sysparm=Reassign");
                 await Launcher.LaunchUriAsync(website);
            })},

              {"reassignMobile", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/manage_request.do?sysparm=Reassign");
                 await Launcher.LaunchUriAsync(website);
            })},


             {"requestSoftware", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/software.do?sysparam=PC");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"manageSoftware", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/softwareLibrary.do");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"discoverMytech", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/discoverhome.do");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"leaderCode", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/audioconferencing.do");
                 await Launcher.LaunchUriAsync(website);
            })},

             {"aQuestion", (Action)(async () => {
                 Uri website = new Uri(@"https://ge.service-now.com/mytech/audioconferencing.do");
                 await Launcher.LaunchUriAsync(website);
            })},


        };

        /*
        Register Custom Cortana Commands from VCD file
        */
        public static async void RegisterVCD()
        {

            StorageFile vcd =  await Package.Current.InstalledLocation.GetFileAsync(
                @"VoiceCommands.xml");

            await VoiceCommandDefinitionManager
                .InstallCommandDefinitionsFromStorageFileAsync(vcd);
        }

        /*
        Look up the spoken command and execute its corresponding action
        */

        public static void RunCommand(VoiceCommandActivatedEventArgs cmd)
        {
            var m = cmd.Result.SemanticInterpretation.Properties.ToList()[0]; 
            userSpeech = cmd.Result.Text;
            

            var p = m.Value;
            SpeechRecognitionResult result = cmd.Result;
            string commandName = result.RulePath[0];
            vcdLookup[commandName].DynamicInvoke();

           
                
        }

    }
}
