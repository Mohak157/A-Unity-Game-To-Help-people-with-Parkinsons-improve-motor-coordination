using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Backgroundmusic : MonoBehaviour
{
   private static Backgroundmusic backgroundMusic;
   void Awake()
   {
      if (backgroundMusic != null)
      {
         Destroy(gameObject);

      }
      else
      {
         backgroundMusic = this;
         DontDestroyOnLoad(gameObject);
      }
   }
}
