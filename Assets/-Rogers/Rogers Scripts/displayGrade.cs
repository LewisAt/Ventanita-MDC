using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayGrade : MonoBehaviour
{
    public Text gradeDisplay;
    //string mealGrade;
    void Start()
    {
        gradeDisplay.text = "this and this";
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            updateGradeDisplay("failure");
        }
    }
    public void updateGradeDisplay(string grade)
    {
        gradeDisplay.text = "" + grade;
    }
}
