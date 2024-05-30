using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characteranimations : MonoBehaviour
{
    public Animator animator;
        void Start()
    {
       animator.SetInteger("setpose", 0); 
    }

    // Update is called once per frame
    void Update()
    {
        var direction = 0;
        
      if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
      {
        direction = 1;
      }

      if(Input.GetKey(KeyCode.LeftShift))
      {
        direction = 2;
      }

      animator.SetInteger("setpose", direction);
      
    }
}
