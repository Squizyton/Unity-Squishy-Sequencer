using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Squizyton.Cutscene
{
   public class CutsceneSequence : SerializedMonoBehaviour
   {

      [InfoBox("Holds A List of Actions to play. This will be done in order")]
      [TableList(DrawScrollView = true, MaxScrollViewHeight = 1000, MinScrollViewHeight = 200)]
      public List<CutsceneAction> CutsceneActions = new List<CutsceneAction>();
      
      public void CreateSequence(List<CutsceneAction> cutsceneActions)
      {
         CutsceneActions = cutsceneActions;
      }




      [Button(Name = "Play Sequence",Icon = SdfIconType.Play)]
      public void DebugPlaySequence()
      {
         #if UNITY_EDITOR
         if (EditorApplication.isPlaying)
         {
            
            //Find the player
            CutscenePlayer player = FindAnyObjectByType<CutscenePlayer>();
            
            
            //Play sequence
            if(player != null)
               player.PlaySequence(this);
            
            else Debug.LogWarning("No Cutscene player found");
         }else Debug.LogError("The Editor is not in play mode.");
         #endif
      }
   }
}
