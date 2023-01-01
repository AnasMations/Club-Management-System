using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField studentIDText;
    public TMP_InputField passwordText;
    public GameObject HomePage;
    public ServerControllerStudents serverControllerStudents;

    Student student;

    void Start()
    {
        serverControllerStudents = GameObject.FindGameObjectWithTag("ServerController").GetComponent<ServerControllerStudents>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoginStudent()
    {
        int studentID = int.Parse(studentIDText.text);

        serverControllerStudents.SelectStudent(studentID, navigateToHome);
    }

    void navigateToHome()
    {
        student = serverControllerStudents.currentStudent;
        if(!string.IsNullOrEmpty(student.password) && student.password.CompareTo(passwordText.text.Trim((char)8203))==0)
        {
            HomePage.SetActive(true);
            this.gameObject.SetActive(false);
            clearData();
        }
    }

    void clearData()
    {
        studentIDText.text = "";
        passwordText.text = "";
    }
}
