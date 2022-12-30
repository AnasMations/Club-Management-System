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
    public TextMeshProUGUI studentIDText;
    public TextMeshProUGUI firstNameText;
    public TextMeshProUGUI lastNameText;
    public TextMeshProUGUI genderText;
    public TextMeshProUGUI birthdateText;
    public TextMeshProUGUI majorText;
    public TextMeshProUGUI graduationYearText;
    public TextMeshProUGUI committeNameText;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI roleText;

    void Start()
    {

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

        if(int.TryParse(studentIDText.text, out int studentID))
        {
            Debug.Log("StudentID is not numeric value!");
            return;
        }

        if(int.TryParse(graduationYearText.text, out int graduationYear))
        {
            Debug.Log("Graduation Year is not numeric value!");
            return;
        }
        
        Student student = new Student(emailText.text, passwordText.text, phoneNumberText.text, studentID, firstNameText.text, lastNameText.text, genderText.text, birthdateText.text, majorText.text, graduationYear, committeNameText.text, positionText.text, roleText.text);
    }
}
