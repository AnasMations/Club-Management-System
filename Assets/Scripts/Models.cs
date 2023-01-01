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

    public Student()
    {

    }

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

        this.workStatus = "Working";

        this.reqruitmentDate = DateTime.Now.ToString("dd-mm-yyyy");

        Debug.Log($"OBJECT CREATED SUCCESSFULLY\n"+this.ToString());
    }

    public override string ToString()
    {
        string s = $"StudentID: {studentID}\n"+
        $"Full Name: {firstName} {lastName}\n"+
        $"Gender: {gender}\n"+
        $"Email: {email}\n"+
        $"Phone Number: {phoneNumber}\n"+
        $"Birthdate: {birthDate}\n"+
        $"Major: {major}\n"+
        $"Graduation Year: {graduationYear}\n"+
        "\n"+
        $"Committe Name: {committeName}\n"+
        $"position: {position}\n"+
        $"role: {role}\n"+
        $"Work Status: {workStatus}\n"+
        $"Reqruitment Date: {reqruitmentDate}\n"+
        "\n"+
        $"Tasks Finished: {tasksFinished}\n"+
        $"Tasks In Progress: {tasksInProgress}\n"+
        $"Tasks Not Started: {tasksNotStarted}"
        ;
        return s;
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