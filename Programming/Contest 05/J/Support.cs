using System;
using System.Collections.Generic;

public class Support
{
    private readonly List<Task> tasks = new List<Task>();

    public IEnumerable<Task> Tasks => tasks;

    // open | <����� ���������> � ������� ����� ��������� � �������� ��� ����������������� �����;
    public int OpenTask(string text)
    {
        tasks.Add(new Task(tasks.Count + 1, text));
        return tasks.Count;
    }

    // close | <id ���������> | <����� ����������� ��������� �� ���������> � �������� �� ��������� � ������� ���;
    public void CloseTask(int id, string answer)
    {
        tasks[id - 1].Answer = answer;
        tasks[id - 1].IsResolved = true;
    }

    // get unresolved � �������� ���������� ��� ���� �������������� ���������;
    public List<Task> GetAllUnresolvedTasks()
    {
        var unresolvedTasks = new List<Task>();
        foreach (var elem in tasks)
        {
            if (!elem.IsResolved)
                unresolvedTasks.Add(elem);
        }
        return unresolvedTasks;
    }

    // close unresolved | <����� ����������� ��������� �� ��� �������������� ���������> � �������� �� ��� �������������� ��������� � ������� ��;
    public void CloseAllUnresolvedTasksWithDefaultAnswer(string answer)
    {
        foreach (var elem in tasks)
        {
            if (!elem.IsResolved)
                CloseTask(elem.Id, answer);
        }
    }

    // info | <id ���������> � �������� ���������� �� ��������� �� ������������������ ������;
    public string GetTaskInfo(int id)
    {
        return tasks[id - 1].ToString();
    }
}