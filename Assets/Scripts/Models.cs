using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Student
{
    public int studentID=0;
    public string firstName;
    public string lastName;
    public string gender;
    public string email;
    public string password;
    public string phoneNumber;
    public string birthDate;
    public string major;
    public int graduationYear;
    public string committeName;
    public string position;
    public string role;
    public string workStatus;
    public string reqruitmentDate;
    public int tasksFinished = 0;
    public int tasksInProgress = 0;
    public int tasksNotStarted = 0;

    public Student(
    string emailText,
    string passwordText,
    string phoneNumberText,
    int studentIDInt,
    string firstNameText,
    string lastNameText,
    string genderText,
    string birthdateText,
    string majorText,
    int graduationYearInt,
    string committeNameText,
    string positionText,
    string roleText
    )
    {
        this.email = emailText.Trim((char)8203);

        this.password = passwordText.Trim((char)8203);

        this.studentID = studentIDInt;

        this.firstName = firstNameText.Trim((char)8203);

        this.lastName = lastNameText.Trim((char)8203);

        this.gender = genderText.Trim((char)8203);

        this.birthDate = birthdateText.Trim((char)8203);

        this.major = majorText.Trim((char)8203);

        this.graduationYear = graduationYearInt;

        this.committeName = committeNameText.Trim((char)8203);

        this.position = positionText.Trim((char)8203);

        this.role = roleText.Trim((char)8203);

        Debug.Log($"Object Student {this.studentID} {this.firstName} was Created\n");
    }
}

[Serializable]
public class Task
{
    public int studentID;
    public string studentName;
    public string committeName;
    public int taskID;
    public string taskName;
    public string taskDeadline;
    public string taskStatus;
}