using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TaskData : MonoBehaviour
{
    public Task task;
    public TMP_Text infoText;
    public Image NotStarted;
    public Image InProgress;
    public Image Finished;

    void Start()
    {

    }

    void Update()
    {

    }

    public void LoadTask(Task task)
    {
        this.task = task;

        infoText.text =
        $"Task: {task.taskName}\n"+
        $"Date: {task.taskDate}\n"+
        $"Assigned to: {task.studentFisrtName} {task.studentLastName}\n"+
        $"Committe: {task.committeName}"
        ;

        if(task.taskStatus.CompareTo("In Progress")==0)
        {
            InProgress.color = Color.green;
        }
        else if(task.taskStatus.CompareTo("Finished")==0)
        {
            Finished.color = Color.green;
        }
        else
        {
            NotStarted.color = Color.green;
        }
    }

    public void DeleteTask()
    {
        this.transform.root.gameObject.GetComponent<TasksLoader>().DeleteTask(task);
    }
}
