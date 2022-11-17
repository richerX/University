using System;
using System.Collections.Generic;
using System.Linq;

public partial class Program
{
    private static List<string> GetTopCategories(IEnumerable<Item> items, IEnumerable<CustomerItem> customersItems, IEnumerable<Customer> customers, int age, int count)
    {
        // �������� ������� �� ����� �����������
        var popularity = new Dictionary<string, int>();
        foreach (var item in items)
            if (!popularity.Keys.Contains(item.Category))
                popularity[item.Category] = 0;

        // ������������ ������ ��������� (���������, ���-�� �������)
        foreach (var purchase in customersItems)
        {
            Customer currentCustomer = customers.Where(customer => customer.Id == purchase.CustomerId).ToList()[0];
            Item currentItem = items.Where(item => item.Id == purchase.ItemId).ToList()[0];
            popularity[currentItem.Category] += currentCustomer.Age >= age ? 1 : 0;
        }

        // ���������� �� �������� ������������ ������ ���������
        var popularityList = new List<KeyValuePair<string, int>>();
        foreach (var elem in popularity.ToList())
            if (elem.Value > 0)
                popularityList.Add(elem);
        popularityList.Sort((x, y) => (-(x.Value)).CompareTo(-(y.Value)));

        /*
        foreach (var pair in popularityList)
            Console.WriteLine($"{pair.Key} - {pair.Value}");
        Console.WriteLine();
        */

        // ����� ������ n ��������� (����� ����������)
        var answer = new List<string>();
        for (int i = 0; i < Math.Min(count, popularityList.Count); i++)
            answer.Add(popularityList[i].Key);
        return answer;
    }
}