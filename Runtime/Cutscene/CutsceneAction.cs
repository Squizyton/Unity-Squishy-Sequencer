using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Squizyton.Cutscene
{
    [Serializable]
    public abstract class CutsceneAction
    {
        [TableColumnWidth(57, Resizable = true)]
        
        [ReadOnly,VerticalGroup("Cutscene Action Name and Description")]
        public string name;
        [ReadOnly,VerticalGroup("Cutscene Action Name and Description"),TextArea]
        public string description;
        
        
        public enum Status
        {
            Waiting,
            Running,
            //TODO:: Add support for pausing the cutscene 
            Paused,
            Finished,
        }


        public CutsceneAction()
        {
        }


        private Status _currentStatus = Status.Waiting;
        
        public Status CurrentStatus
        {
            get => _currentStatus;
            set => _currentStatus = value;
        }
        
        
        public abstract void OnStart();
        public abstract Status Executing();
        public abstract void OnEnd();
    }
}
