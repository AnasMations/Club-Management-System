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

        changeButtonColor(task.taskStatus);
    }

    public void DeleteTask()
    {
        this.transform.root.gameObject.GetComponent<TasksLoader>().DeleteTask(task);
        Destroy(gameObject);
    }

    public void UpdateTaskStatus(string newStatus)
    {
        task.taskStatus = newStatus;
        this.transform.root.gameObject.GetComponent<TasksLoader>().UpdateTaskStatus(task);
        changeButtonColor(task.taskStatus);

    }

    void changeButtonColor(string s)
    {
        Color32 defaultColor = new Color32(102, 171, 216, 255);
        NotStarted.color = defaultColor;
        InProgress.color = defaultColor;
        Finished.color = defaultColor;

        if(s.CompareTo("Not Started")==0)
        {
            NotStarted.color = new Color32(204, 75, 75, 255);
        }
        else if(s.CompareTo("In Progress")==0)
        {
            InProgress.color = new Color32(204, 192, 74, 255);
        }
        else if(s.CompareTo("Finished")==0)
        {
            Finished.color = new Color32(80, 204, 74, 255);
        }
    }
}
