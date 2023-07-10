

using Delegate;

Mydelegate mydelegate = new Mydelegate(Day1.Getmyname);

/* Mydelegate mydelegate = Day1.Getmyname;
/* Mydelegate mydelegate = (stirng name) => Console.WriteLine(name);
*/

Mydelegate mydelegate1 = (string id) => Console.WriteLine(id+"Kahn");

Mydelegate del = mydelegate + mydelegate1;

void get(Mydelegate del)
{
    del("sojib");
}

get(del);



GenericDelegates<int> delegates =(int num) =>num;

Console.WriteLine(delegates(29));


func<int, int> funcdelegtae = (int num) => num;

Console.WriteLine(funcdelegtae(529));

Func<string, string> MyName = (string name) => name;

Console.WriteLine(MyName("Alibaba"));

Action<string> action_Delegate = (string name) => Console.WriteLine(name);

action_Delegate("Jak ma");