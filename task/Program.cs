using System.Collections.Generic;
using System;
class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        List<string> teamMembers = new List<string>
        {
            "dude",
            "guy",
            "james bond",
            "lara croft",
            "jacky chan",
            "regina george",
            "cady heron",
            "rihanna",
            "виктор цой",
            "cinderella"
        };

        foreach (string member in teamMembers)
        {
            taskManager.Create("1 проект", "написать песню о крокодиле", DateTime.Now.AddDays(7), member);
        }
        List<Task> tasks = taskManager.TasksByStatus("1 проект", "принят");
        foreach (Task task in tasks)
        {
            taskManager.Complete("1 проект", task.characteristic, task.dothat, "Отчет об выполнении задачи");
        }
    }
}
        






