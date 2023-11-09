using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaskManager
{
    public List<Project> projects { get; set; }
    public List<string> members { get; set; }

    public TaskManager()
    {
        projects = new List<Project>();
        members = new List<string>();
        Project p1 = new Project
        {
            characteristic = "1 проект",
            deadline = DateTime.Now.AddDays(7),
            dothat = "инициатор",
            response = "ответственный",
            tasks = new List<Task>(),
            status = "проект"
        };
        projects.Add(p1);
    }
    /// <summary>
    /// создание проекта
    /// </summary>
    /// <param name="description"></param>
    /// <param name="deadline"></param>
    /// <param name="initiator"></param>
    /// <param name="responsible"></param>
    public void CreateProject(string description, DateTime deadline, string initiator, string responsible)
    {
        Project p2 = new Project
        {
            characteristic = description,
            deadline = deadline,
            dothat = initiator,
            response = responsible,
            tasks = new List<Task>(),
            status = "проект"
        };
        projects.Add(p2);
    }
    /// <summary>
    /// инфа о созданном проекте проекте 
    /// </summary>
    /// <param name="projectcharacteristic"></param>
    /// <param name="taskcharacteristic"></param>
    /// <param name="taskdeadline"></param>
    /// <param name="dotask"></param>
    public void Create(string projectcharacteristic, string taskcharacteristic, DateTime taskdeadline, string dotask)
    {
        Project project = projects.FirstOrDefault(p => p.characteristic == projectcharacteristic && p.status == "проект");
        if (project != null)
        {
            Task task = new Task
            {
                characteristic = taskcharacteristic,
                deadline = taskdeadline,
                dothat = dotask,
                iwilldothat = "",
                status = "принят",
                report = new List<Report>()
            };
            project.tasks.Add(task);
        }
        else
        {
            Console.WriteLine("неверное описание проекта, или он не находится в статусе проекта");
        }
    }
    /// <summary>
    /// передача проекта к сотрудникам
    /// </summary>
    /// <param name="projectcharacteristic"></param>
    /// <param name="taskcharacteristic"></param>
    /// <param name="iwilldothat"></param>
    public void ToMember(string projectcharacteristic, string taskcharacteristic, string iwilldothat)
    {
        Project project = projects.FirstOrDefault(p => p.characteristic == projectcharacteristic && p.status == "проект");
        if (project != null)
        {
            Task task = project.tasks.FirstOrDefault(t => t.characteristic == taskcharacteristic && t.status == "принят");
            if (task != null)
            {
                task.iwilldothat = iwilldothat;
                task.status = "в процессе";
            }
            else
            {
                Console.WriteLine("неверное описание задачи или ей не присвоен статус");
            }
        }
        else
        {
            Console.WriteLine("неверное описание проекта, или он не находится в статусе проекта");
        }
    }
    /// <summary>
    /// для завершения проекта(обновления статуса), создания отчёта
    /// </summary>
    /// <param name="projectcharacteristic"></param>
    /// <param name="taskcharacteristic"></param>
    /// <param name="iwilldothat"></param>
    /// <param name="reporttext"></param>
    public void Complete(string projectcharacteristic, string taskcharacteristic, string iwilldothat, string reporttext)
    {
        Project project = projects.FirstOrDefault(p => p.characteristic == projectcharacteristic && p.status == "проект");
        if (project != null)
        {
            Task task = project.tasks.FirstOrDefault(t => t.characteristic == taskcharacteristic && t.iwilldothat == iwilldothat && t.status == "в процессе");
            if (task != null)
            {
                Report report = new Report
                {
                    text = reporttext,
                    date = DateTime.Now,
                    iwilldothat = iwilldothat
                };
                task.report.Add(report);
                task.status = "завершён";
            }
            else
            {
                Console.WriteLine("неверное описание задачи или она не находится в состоянии выполнения");
            }
        }
        else
        {
            Console.WriteLine("неверное описание проекта, или он не находится в статусе проекта");
        }
    }
    /// <summary>
    /// обновление статуса
    /// </summary>
    /// <param name="projectcharacteristic"></param>
    public void UpdateStatus(string projectcharacteristic)
    {
        Project project = projects.FirstOrDefault(p => p.characteristic == projectcharacteristic && p.status == "Project");
        if (project != null)
        {
            bool allTasks = project.tasks.All(t => t.status == "Completed");
            if (allTasks)
            {
                project.status = "завершён";
            }
            else
            {
                project.status = "в процессе";
            }
        }
        else
        {
            Console.WriteLine("неверное описание проекта, или он не находится в статусе проекта");
        }
    }
    public List<Project> ProjectsByStatus(string status)
    {
        return projects.Where(p => p.status == status).ToList();
    }
    /// <summary>
    /// проверяется, существует ли проект с указанным описанием
    /// </summary>
    /// <param name="projectcharacteristic"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    public List<Task> TasksByStatus(string projectcharacteristic, string status)
    {
        Project project = projects.FirstOrDefault(p => p.characteristic == projectcharacteristic);
        if (project != null)
        {
            return project.tasks.Where(t => t.status == status).ToList();
        }
        else
        {
            Console.WriteLine("неверное описание проекта");
            return null;
        }
    }
}
