using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEditor.PackageManager;
namespace Squizyton.Cutscene
{
    public class CS_WaitForInput : CutsceneAction
    {
        //Will Automatically check if new input system is enabled
        private bool _hasNewInputSystem;


        [VerticalGroup("Special Parameters")] public KeyCode keyWaitingToBePressed;


        public CS_WaitForInput()
        {
            name = "Wait For User Input";
            description = "Waits for user input to continue Sequence";
            CheckForNewInputSystem();
        }

        public override void OnStart()
        {
        }

        public override Status Executing()
        {
            if (Input.GetKeyDown(keyWaitingToBePressed))
            {
                return Status.Finished;
            }

            return Status.Running;
        }

        public override void OnEnd()
        {
        }


        public void CheckForNewInputSystem()
        {
            string inputSystemName = "com.unity.inputsystem";

            if (!File.Exists("Packages/manifest.json"))
            {
                Debug.Log("You...don't have a manifest.json file?");
            }

            string jsonText = File.ReadAllText("Packages/manifest.json");

            _hasNewInputSystem = jsonText.Contains(inputSystemName);


            if (_hasNewInputSystem)
            {
                Debug.LogError("You have the new input system enabled, I recommend not using this action.");
            }
        }
    }
}