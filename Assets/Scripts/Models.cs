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
        this.email = emailText;

        this.password = passwordText;

        this.studentID = studentIDInt;

        this.firstName = firstNameText;

        this.lastName = lastNameText;

        this.gender = genderText;

        this.birthDate = birthdateText;

        this.major = majorText;

        this.graduationYear = graduationYearInt;

        this.committeName = committeNameText;

        this.position = positionText;

        this.role = roleText;

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