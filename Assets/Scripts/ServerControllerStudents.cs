using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class ServerControllerStudents : MonoBehaviour
{
    public Student currentStudent;
    public int []studentIds;

    public void InsertStudent(Student student, Action action = null)
    {
        StartCoroutine(InsertStudentSQL(student, action));
    }

    IEnumerator InsertStudentSQL(Student student, Action action = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("addStudentID",  student.studentID);
        form.AddField("addFirstName",  student.firstName);
        form.AddField("addLastName",  student.lastName);
        form.AddField("addEmail",  student.email);
        form.AddField("addPassword",  student.password);
        form.AddField("addPosition",  student.position);
        form.AddField("addGender",  student.gender);
        form.AddField("addBirthdate",  student.birthDate);

        string URL = "http://club-management-system.000webhostapp.com/insertStudent.php";

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else if(www.downloadHandler.text.Contains("ERROR"))
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if(action!=null) action();
            }
        }
    }

    public Student SelectStudent(int studentID, Action action = null)
    {
        StartCoroutine(SelectStudentSQL(studentID, action));
        return currentStudent; //TODO Need to finish coroutine before returning Student
    }
    
    IEnumerator SelectStudentSQL(int studentID, Action action = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("selectStudentID", studentID);

        string URL = "http://club-management-system.000webhostapp.com/selectStudent.php";

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else if(www.downloadHandler.text.Contains("ERROR"))
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string []response = www.downloadHandler.text.Split("|");

                Student s = new Student();
                
                s.studentID = int.Parse(response[0]);
                s.firstName = response[1];
                s.lastName = response[2];
                s.email = response[3];
                s.password = response[4];
                s.position = response[5];
                s.gender = response[6];
                s.birthDate = response[7];

                currentStudent = s;

                if(action!=null) action();
            }
        }
    }

    IEnumerator UpdateStudentSQL(Student student)
    {
        yield return 0;
    }

    IEnumerator DeleteStudentSQL(Student student)
    {
        yield return 0;
    }

    IEnumerator SelectAllStudentIdsSQL(Student student)
    {
        yield return 0;
    }

}
