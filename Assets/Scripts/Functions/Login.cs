using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField studentIDText;
    public TMP_InputField passwordText;
    public GameObject HomePage;

    ServerController serverController;

    void Start()
    {
        serverController = GameObject.FindGameObjectWithTag("ServerController").GetComponent<ServerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoginStudent()
    {
        int studentID = int.Parse(studentIDText.text);

        StartCoroutine(serverController.SelectStudentSQL(studentID, login));
    }

    void login()
    {
        if(serverController.connectedStudent.password.CompareTo(passwordText.text.Trim((char)8203))==0)
        {
            HomePage.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
