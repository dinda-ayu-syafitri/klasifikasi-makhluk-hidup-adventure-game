using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emblem : MonoBehaviour
{
    bool collected = false;
   
   private void OnTriggerEnter(Collider other) {
    if(!collected)
    {
        CollectEmblem();
    }
   }

   private void CollectEmblem()
   {
       collected = true;
       Destroy(gameObject);
       GameEventManager.instance.EmblemCollected();
       print("Emblem collected!");
   }
}
