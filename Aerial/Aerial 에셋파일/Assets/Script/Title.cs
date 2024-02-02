using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class Title : MonoBehaviour
{
    public Texture2D cursorTex;
    public float PlayTime;
    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.ForceSoftware); 
    }
    private void Update()
    {
      //  Debug.Log(Time.realtimeSinceStartup);
    }
    private void Start()
    {
        Player.circle = 0;
        NPC.Event = false;
        NPC.FieldEvent = false;
       // Player.GameTime = 0;
        
    }
  
    
   
}
