using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Member : MonoBehaviour
{
    public Student student;
    public TMP_Text infoText;

    void Start()
    {

    }

    void Update()
    {

    }

    public void LoadMember(Student student)
    {
        this.student = student;

        infoText.text =
        $"Full Name: {student.firstName} {student.lastName}\n"+
        $"Major: {student.major}\n"+
        $"Committe Name: {student.committeName}\n"+
        $"Role: {student.role}\n"+
        $"# Tasks: {student.tasksInProgress + student.tasksNotStarted}"
        ;
    }

    public void ReportInfoFunction()
    {
        this.transform.root.gameObject.GetComponent<MembersLoader>().navigateToReport(student);
    }
}
