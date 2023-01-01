using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MembersLoader : MonoBehaviour
{
    public GameObject member;
    public Transform content;
    public GameObject ReportPage;
    int []StudentIDs;
    public ServerControllerStudents serverControllerStudents;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        LoadStudentIds();
    }

    void LoadStudentIds()
    {
        serverControllerStudents.SelectStudentIds("", LoadMembers);
    }

    void LoadMembers()
    {

        StudentIDs = serverControllerStudents.studentIds;

        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach(int id in StudentIDs)
        {
            serverControllerStudents.SelectStudent(id, instantiateMember);
        }
    }

    void instantiateMember()
    {
        GameObject MemberObj = Instantiate(member, content); 
        MemberObj.GetComponent<Member>().LoadMember(serverControllerStudents.currentStudent);
    }

    public void navigateToReport(Student s)
    {
        this.gameObject.SetActive(false);
        ReportPage.GetComponent<GenerateReport>().ReportInfo(s);
    }
}
