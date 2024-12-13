using System;
using System.Collections.Generic;
using UnityEngine;

namespace Squizyton.Cutscene
{


    public class CutscenePlayer : MonoBehaviour
    {
        private Queue<CutsceneAction> cutsceneActions;

        private bool _isPlaying;
        public bool IsPlaying => _isPlaying;

        public CutsceneAction currentAction;


        //Debug
        private CutsceneSequence currentCutsceneSequence;


        private void Update()
        {
            //If the Player is currently playing a cutscene
            if (_isPlaying)
            {
                if (currentAction.CurrentStatus == CutsceneAction.Status.Running &&
                    currentAction.CurrentStatus != CutsceneAction.Status.Waiting)
                {
                    currentAction.CurrentStatus = currentAction.Executing();
                }
                else if (cutsceneActions.Count > 0)
                {
                    PopQueue();
                }
                else
                {
#if UNITY_EDITOR
                    Debug.Log("Cutscene is Done");
#endif
                    _isPlaying = false;
                }
            }
        }


        public CutsceneAction ReturnCurrentAction()
        {
            return currentAction;
        }

        public CutsceneAction.Status ReturnCurrentActionStatus()
        {
            return currentAction.CurrentStatus;
        }

        void PopQueue()
        {
            currentAction?.OnEnd();
            currentAction = cutsceneActions.Dequeue();
            currentAction.OnStart();
            currentAction.CurrentStatus = CutsceneAction.Status.Running;
        }

        public void PlaySequence(CutsceneSequence sequence)
        {
            cutsceneActions ??= new Queue<CutsceneAction>();

            currentCutsceneSequence = sequence;

            //Load up the queue
            for (int i = 0; i < sequence.CutsceneActions.Count; i++)
            {
                cutsceneActions.Enqueue(sequence.CutsceneActions[i]);
            }

            //pop the first action
            PopQueue();

            _isPlaying = true;
        }
    }
}