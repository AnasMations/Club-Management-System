using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;
using System.Linq;

public class ServerControllerTasks : MonoBehaviour
{
    public Task currentTask;
    public int []taskIds;

    void Start()
    {
        // Task task = new Task(202000005, "Task TEST", "Media");
        // InsertTask(task);
    }

    public void InsertTask(Task task, Action action = null)
    {
        StartCoroutine(InsertTaskSQL(task, action));
    }

    IEnumerator InsertTaskSQL(Task task, Action action = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("addTaskName",  task.taskName);
        form.AddField("addCommitteName",  task.committeName);
        form.AddField("addTaskDate",  task.taskDate);
        form.AddField("addStudentID",  task.studentID);

        string URL = "http://club-management-system.000webhostapp.com/insertTask.php";

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
                //TODO
                //currentTask=
                if(action!=null) action();
            }
        }
    }

    public Task SelectTask(int taskID, Action action = null)
    {
        StartCoroutine(SelectTaskSQL(taskID, action));
        return currentTask; //TODO Need to finish coroutine before returning Task
    }
    
    IEnumerator SelectTaskSQL(int taskID, Action action = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("selectTaskID", taskID);

        string URL = "http://club-management-system.000webhostapp.com/selectTask.php";

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

                Task t = new Task();
                
                t.taskID = int.Parse(response[0]);
                t.taskName = response[1];
                t.committeName = response[2];
                t.taskDate = response[3];
                t.taskStatus = response[4];
                t.studentFisrtName = response[5];
                t.studentLastName = response[6];

                currentTask = t;

                if(action!=null) action();
            }
        }
    }
    public void UpdateTask(Task task, Action action = null)
    {
        StartCoroutine(UpdateTaskSQL(task, action));
    }
    IEnumerator UpdateTaskSQL(Task task, Action action = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("selectTaskID", task.taskID);
        form.AddField("updateTaskStatus", task.taskStatus);

        string URL = "http://club-management-system.000webhostapp.com/updateTask.php";

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

    public void DeleteTask(string Type, int ID, Action action = null)
    {
        StartCoroutine(DeleteTaskSQL(Type, ID, action));
    }

    IEnumerator DeleteTaskSQL(string Type, int ID, Action action = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("selectType", Type);
        form.AddField("selectID", ID);

        string URL = "http://club-management-system.000webhostapp.com/delete.php";

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
    public void SelectTaskIds(string CommitteName="", Action action = null)
    {
        StartCoroutine(SelectTaskIdsSQL(CommitteName, action));
    }
    IEnumerator SelectTaskIdsSQL(string CommitteName="", Action action = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("selectCommitteName", CommitteName);

        string URL = "http://club-management-system.000webhostapp.com/selectTaskIds.php";

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

                List<int> temp = new List<int>();
                foreach(string x in response)
                {
                    if(int.TryParse(x, out int res))
                    {
                        temp.Add(res);
                    }
                }
                taskIds = temp.ToArray();

                if(action!=null) action();
            }
        }
    }

}
