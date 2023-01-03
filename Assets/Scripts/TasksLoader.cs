using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksLoader : MonoBehaviour
{
    public GameObject task;
    public Transform content;
    int []TaskIDs;
    public ServerControllerTasks serverControllerTasks;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        LoadTaskIds();
    }

    void LoadTaskIds()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
        
        serverControllerTasks.SelectTaskIds("", LoadTask);
    }

    void LoadTask()
    {
        TaskIDs = serverControllerTasks.taskIds;

        foreach(int id in TaskIDs)
        {
            serverControllerTasks.SelectTask(id, instantiateTask);
        }
    }

    void instantiateTask()
    {
        GameObject TaskObj = Instantiate(task, content); 
        TaskObj.GetComponent<TaskData>().LoadTask(serverControllerTasks.currentTask);
    }

    public void DeleteTask(Task task)
    {
        serverControllerTasks.DeleteTask("Task", task.taskID);
    }
}
