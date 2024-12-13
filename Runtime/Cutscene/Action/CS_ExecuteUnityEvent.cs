using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Squizyton.Cutscene
{
    /// <summary>
    /// Executes a Unity Event. Will never return a Status.Running
    /// </summary>
    public class CS_ExecuteUnityEvent : CutsceneAction
    {
        [VerticalGroup("Special Parameters")]
        public UnityEvent unityEvent;



        public CS_ExecuteUnityEvent()
        {
            name = "Exectute Unity Event";
            description = "Executes a Unity Event";

        }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public override void OnStart()
        {
            unityEvent?.Invoke();
        }

        public override Status Executing()
        {
            return Status.Finished;
        }

        public override void OnEnd()
        {
        }
    }
}