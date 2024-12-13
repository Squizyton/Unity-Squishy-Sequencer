using Sirenix.OdinInspector;
using UnityEngine;

namespace Squizyton.Cutscene
{
    
    public class CS_Wait : CutsceneAction
    {
        [VerticalGroup("Special Parameters")]
        [InfoBox("This action 'pauses' the queue. " )]
        public float pauseTime = 2f;



        private float _timer;



        public CS_Wait()
        {
            name = "Wait";
            description = "Pauses the Sequence Queue for specified Time";
        }

        public override void OnStart()
        {
        }

        public override Status Executing()
        {
            if (_timer < pauseTime)
            {
                _timer += Time.deltaTime;
                return Status.Running;
            }
            
            return Status.Finished;
        }

        public override void OnEnd()
        {
         
        }
    }
}
