
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Playables;



namespace Squizyton.Cutscene
{
    /// <summary>
    /// Plays a Timeline Sequence. DOES NOT PASS FINISHED UNTIL THE WHOLE TIME LINE IS COMPLETED
    /// </summary>
    public class CS_Timeline : CutsceneAction
    {
        [VerticalGroup("Special Parameters")] public PlayableDirector director;

        public CS_Timeline()
        {
            name = "Play Timeline";
            description = "Plays Specified Timeline. Does not return finished until the whole Timeline is completed";
        }


        public override void OnStart()
        {
            director.Play();
        }

        public override Status Executing()
        {
            return director.time < director.duration ? Status.Running : Status.Finished;
        }

        public override void OnEnd()
        {
        }
    }
}