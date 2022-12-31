using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class ServerController : MonoBehaviour
{
    public Student connectedStudent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator InsertStudentSQL(Student student, Action action = null)
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
                action();
            }
        }
    }

    public IEnumerator UpdateStudentSQL(Student student)
    {
        yield return 0;
    }

    public IEnumerator DeleteStudentSQL(Student student)
    {
        yield return 0;
    }

    public IEnumerator SelectStudentSQL(int studentID, Action action = null)
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
                connectedStudent.studentID = int.Parse(response[0]);
                connectedStudent.firstName = response[1];
                connectedStudent.lastName = response[2];
                connectedStudent.email = response[3];
                connectedStudent.password = response[4];
                connectedStudent.position = response[5];
                connectedStudent.gender = response[6];
                connectedStudent.birthDate = response[7];

                action();
            }
        }
    }
}
