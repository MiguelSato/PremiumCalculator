using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PremiumCalculator.Validation.states;

namespace PremiumCalculator.Validation
{
    public class StateValidator
    {
        private HashSet<String> _states;

        private IStatesInput _stateInput;


        public StateValidator()
        {
            _stateInput = new StatesFileInput();

            _states = _stateInput.GetStates();
        }


        public Boolean IsValid(String state)
        {

            String upperCaseString = state.ToUpper();
            
            return _states.Contains(upperCaseString);
        }

    }
}