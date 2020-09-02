using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

public class NotifyHub : Hub
{
    private static ConcurrentBag<TaskItem> _tasks = new ConcurrentBag<TaskItem>();

    // Going to be called from the client side (vue)
    public async Task AddTask(object taskItem)
    {
        var item = JsonConvert.DeserializeObject<TaskItem>(((JsonElement)taskItem).ToString());

        _tasks.Add(item);
        await Task.Factory.StartNew(DoTasks);

        await Clients.All.SendAsync("AddedTask", taskItem);
    }

    public async Task TaskDone(object taskItem)
    {
        await Clients.All.SendAsync("TaskIsDone", taskItem);
    }

    private void DoTasks()
    {
        _tasks.ToList().ForEach(x => {
            Thread.Sleep(1000*RandomNumber(1, 10));
            HubHelper.Notifier.NotifyDone(x);
        });
    }

    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}