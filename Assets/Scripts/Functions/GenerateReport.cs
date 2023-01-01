using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateReport : MonoBehaviour
{
    public TMP_Text infoText;
    public GameObject ReportPage;
    public ServerControllerStudents serverControllerStudents;
    Student student;

    void Start()
    {
        serverControllerStudents = GameObject.FindGameObjectWithTag("ServerController").GetComponent<ServerControllerStudents>();
        //ReportInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Calling the function from button click
    public void ReportInfo(Student s)
    {
        ReportPage.SetActive(true);
        infoText.text = s.ToString();
        Debug.Log("REPORT\n"+s.ToString());
    }

    public void ReportInfo(int studentID)
    {
        serverControllerStudents.SelectStudent(studentID, navigateToReport);
    }

    void navigateToReport()
    {
        student = serverControllerStudents.currentStudent;
        ReportPage.SetActive(true);
        infoText.text = student.ToString();
        Debug.Log("REPORT\n"+student.ToString());
    }
}
