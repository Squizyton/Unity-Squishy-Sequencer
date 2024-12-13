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
   }
}
