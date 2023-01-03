using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateReport : MonoBehaviour
{
    public TMP_Text infoText;
    public GameObject ReportPage;
    public ServerControllerStudents serverControllerStudents;
    public ServerControllerTasks serverControllerTasks;
    public TMP_InputField taskName;
    Student student;

    void Start()
    {
        serverControllerStudents = GameObject.FindGameObjectWithTag("ServerController").GetComponent<ServerControllerStudents>();
        serverControllerTasks = GameObject.FindGameObjectWithTag("ServerController").GetComponent<ServerControllerTasks>();
        //ReportInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AssignTask()
    {
        string taskname = this.taskName.text.Trim((char)8203);
        if(!string.IsNullOrEmpty(taskname)){
            serverControllerTasks.InsertTask(new Task(student.studentID, taskname, student.committeName));
        }
    }
    public void Delete()
    {
        serverControllerStudents.DeleteStudent("Student", student.studentID);
    }
    public void ReportInfo(Student s)
    {
        student = s;
        ReportPage.SetActive(true);
        infoText.text = student.ToString();
        Debug.Log("REPORT\n"+student.ToString());
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
