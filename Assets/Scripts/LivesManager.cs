using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LivesManager : MonoBehaviour
{
    public void SetLivesCount(int count)
    {
        count = Mathf.Clamp(count,0,3);
        var lives = GetComponentsInChildren<Image>().ToList();
        lives.ForEach(x => x.enabled = false);
        for (int i = 0; i <= count; i++)
        {
            lives[i].enabled = true;
        }
    }

    
  
}
