using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice_Line : MonoBehaviour
{
    //Audio Sources MUST NOT be Awake on Start
    public AudioSource[] CustomerCalls;
    public AudioSource VoiceCalls;

    //OnTriggerEnter may be change to a regular call, so the GradeOrderInput script calls the Voice Line
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "customer")
        {
            //Placeholder
            int num = Random.Range(0, CustomerCalls.Length);

            //if statement to avoid multiple playbacks at the same time
            if(!VoiceCalls.isPlaying )
            {
                VoiceCalls = CustomerCalls[num];
                VoiceCalls.Play();
                Debug.Log("Playing Sound Effect " + num);
            }
            else
            {
                Debug.Log("WAIT!!!");
            }
        }

        /* The next line of code is for the cooking mechanic sfx (if wanted to be implemented)
         * The cooking Sfx has to be looped and not awake on start.
           
         * This call should be located when the object is placed in the cooking location
        public void CookingSfx()
        {
            CustomerCalls[*number for cooking sfx*].Play();
        }

          * This call should be located when the object is done cooking (the timer ends)
        public void EndCookingSfx()
        {
            CustomerCalls[*number for cooking sfx*].Stop();
        }

         */
    }
}
