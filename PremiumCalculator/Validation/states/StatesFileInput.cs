using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PremiumCalculator.Validation.states
{
    public class StatesFileInput : IStatesInput
    {

        public HashSet<String> GetStates()
        {

            HashSet<String> states = new HashSet<String>();

            String jsonFileLocation = AppDomain.CurrentDomain.BaseDirectory;
            jsonFileLocation += "/../usa_states.json";

            using (StreamReader reader = new StreamReader(jsonFileLocation))
            {
                String jsonStr = reader.ReadToEnd();

                JObject json = JObject.Parse(jsonStr);

                JArray statesArray = (JArray)json["usa_states"];

                foreach(JObject node in statesArray)
                {
                    String code = (String)node.GetValue("code");

                    states.Add(code);
                }

                return states;

            }
            
        }
    }
}