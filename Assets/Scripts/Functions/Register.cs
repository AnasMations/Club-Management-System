using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Register : MonoBehaviour
{
    public TextMeshProUGUI emailText;
    public TextMeshProUGUI passwordText;
    public TextMeshProUGUI confirmPasswordText;
    public TextMeshProUGUI phoneNumberText;
    public TMP_InputField studentIDText;
    public TextMeshProUGUI firstNameText;
    public TextMeshProUGUI lastNameText;
    public TextMeshProUGUI genderText;
    public TextMeshProUGUI birthdateText;
    public TextMeshProUGUI majorText;
    public TMP_InputField graduationYearText;
    public TextMeshProUGUI committeNameText;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI roleText;

    public GameObject LoginPage;

    public ServerControllerStudents serverControllerStudents;

    void Start()
    {
        serverControllerStudents = GameObject.FindGameObjectWithTag("ServerController").GetComponent<ServerControllerStudents>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateStudent()
    {
        if (passwordText.text.CompareTo(confirmPasswordText.text) != 0)
        {
            Debug.Log("Passwords not matching!");
            return;
        }

        int studentID = int.Parse(studentIDText.text);

        // if(int.TryParse(studentIDText.text, out int studentID))
        // {
        //     Debug.Log($"StudentID {studentIDText.text} is not numeric value!");
        //     return;
        // }

        int graduationYear = int.Parse(graduationYearText.text);

        // if(!int.TryParse(graduationYearText.text, out int graduationYear))
        // {
        //     Debug.Log($"Graduation Year {graduationYearText.text} is not numeric value!");
        //     return;
        // }

        Student student = new Student(emailText.text, passwordText.text, phoneNumberText.text, studentID, firstNameText.text, lastNameText.text, genderText.text, birthdateText.text, majorText.text, graduationYear, committeNameText.text, positionText.text, roleText.text);
        serverControllerStudents.InsertStudent(student, navigateToLogin);
    }

    void navigateToLogin()
    {
        LoginPage.SetActive(true);
        this.gameObject.SetActive(false);
        clearData();
    }

    void clearData()
    {
        emailText.text = "";
        passwordText.text = "";
        confirmPasswordText.text = "";
        phoneNumberText.text = "";
        studentIDText.text = "";
        firstNameText.text = "";
        lastNameText.text = "";
        genderText.text = "";
        birthdateText.text = "";
        majorText.text = "";
        graduationYearText.text = "";
        committeNameText.text = "";
        positionText.text = "";
        roleText.text = "";
    }
}
