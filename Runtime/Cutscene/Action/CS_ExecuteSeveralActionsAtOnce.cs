using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Squizyton.Cutscene
{
    /// <summary>
    /// This class will ExecuteSeveralActionsAtOnce and will not pass the Finished status until ALL are
    /// done. 
    /// </summary>
    public class CS_ExecuteSeveralActionsAtOnce : CutsceneAction
    {
        
        [VerticalGroup("Special Parameters"),InfoBox("Does Not Return Status of Finished Until ALL ACTIONS are done")]
        public List<CutsceneAction> Actions = new List<CutsceneAction>();

        public CS_ExecuteSeveralActionsAtOnce()
        {
            name = "Execute Several Actions At Once";
            description = "Executes Several Actions At Once";
        }
        
        

        public override void OnStart()
        {
            
            //Start all the actions
            foreach(var action in Actions)
                action.OnStart();
        }

        public override Status Executing()
        {
            
            //Execute all Actions
            foreach (var action in Actions)
            {
                action.CurrentStatus = action.Executing();
            }
            
            //Check to see if any are still running
            foreach (var action in Actions)
            {
                if(action.CurrentStatus == Status.Running)
                    return Status.Running;
            }

            return Status.Finished;
        }

        public override void OnEnd()
        {
            Debug.Log("Several Action Sequence Has Completed");
        }
    }
}
