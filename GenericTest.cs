using System;
using System.Collections.Generic;
using System.Collections;

namespace Demo
{
    class MyArray<T>
    {
        public T[] array{ get;set; }
        public MyArray(int size){ array = new T[size + 1]; }
        public T getItem(int index){ return array[index]; }
        public void setItem(int index, T value) { array[index] = value;}
    }
    class GenericTest
    {
        public List<Student> stu = new List<Student>();
        public String[] names = new string[]{"John","Matt","Lucy","Jack"};
        public GenericTest()
        {
            for(int i=0;i<names.Length;i++)
            {
                stu.Add(new Student(names[i],$"202021000{i+1}"));
            }
        }
        public void arrayTest()
        {
            int[] arr = new int[]{0,1,2,3,4};
            for(int i=0; i<arr.Length; i++){ 
                Console.Write($"{arr[i]} "); 
            }
        }
        public void arraylistTest()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(stu[0].name);
            arrayList.Add(stu[0].studentid);
            for(int i=0; i<arrayList.Count; i++){ 
                Console.Write($"{arrayList[i]} "); 
            }
        }
        public void bitarrayTest()
        {
            byte[] a = {13};
            byte[] b = {60};
            BitArray bitArray1 = new BitArray(a);
            BitArray bitArray2 = new BitArray(b);

            for(int i=0;i<bitArray1.Count;i++){ Console.Write("{0,-6}",bitArray1[i]); }

            BitArray bitArray3 = bitArray1.And(bitArray2);
            BitArray bitArray4 = bitArray1.Or(bitArray2);
        }
        public void listTest()
        {
            List<Student> stu_list = new List<Student>();
            stu_list.Add( stu[0]);
            stu_list.Add( stu[1]);
            foreach( Student stu in stu_list){ 
                Console.WriteLine(stu.ToString());
            }
        }
        public void linkedlistTest()
        {
            LinkedList<Student> stu_linkedlist = new LinkedList<Student>();
            stu_linkedlist.AddLast(stu[1]);
            
            foreach(Student s in stu_linkedlist){ Console.WriteLine(s.ToString()); }

            LinkedListNode<Student> node = stu_linkedlist.Find(stu[1]);
            stu_linkedlist.AddBefore(node,stu[0]); // 在结点前插
            stu_linkedlist.AddAfter(node,stu[2]);  // 在结点后插
            stu_linkedlist.Remove(stu[1]);         // 移除某个元素
            stu_linkedlist.AddFirst(stu[1]);       // 头插
            stu_linkedlist.RemoveLast();           // 移除最后一个元素
        }
        public void sortedlistTest()
        {
            SortedList stu_sortedlist = new SortedList();
            for(int i=0;i<stu.Count;i++)
            {
                stu_sortedlist.Add(stu[i].studentid,stu[i].name);
            }
            ICollection stu_id = stu_sortedlist.Keys;
            foreach(string id in stu_id)
            { 
                Console.WriteLine($"id: {id}\nname: {stu_sortedlist[id]}"); 
            }
        }
        public void hashtableTest()
        {
            Hashtable hashtable = new Hashtable();
            for(int i=0;i<stu.Count;i++)
            {
                hashtable.Add(stu[i].studentid,stu[i]);
            }
            foreach(DictionaryEntry entry in hashtable)
            {
                Console.WriteLine(entry.Key + ":" + entry.Value.ToString());
            }
        }
        public void dictionaryTest()
        {
            Dictionary<String,Student> studict = new Dictionary<string, Student>();
            for(int i=0;i<stu.Count;i++)
            {
                studict.Add(stu[i].studentid,stu[i]);
            }
            foreach(KeyValuePair<String,Student> pair in studict)
            {
                Console.WriteLine(pair.Key + "\n" + pair.Value.ToString());
            }
        }
        public void hashsetTest()
        {
            HashSet<int> hashset = new HashSet<int>();
            int[] repeat_data = new int[]{0,1,5,7,3,6,4,5,2,3,1};
            for(int i=0;i<repeat_data.Length;i++){ hashset.Add(repeat_data[i]); }
            foreach(int n in hashset){ Console.Write($"{n} "); }
        }
        public void queueTest()
        {
            Queue queue = new Queue();
            for(int i=0;i<stu.Count;i++){ queue.Enqueue(stu[i]); }
            // foreach(var elem in queue){ Console.WriteLine(elem); }
            queue.Dequeue();
            queue.Dequeue();
            // foreach(var elem in queue){ Console.WriteLine(elem); }

            Queue<Student> stu_queue = new Queue<Student>();
            for(int i=0;i<stu.Count;i++){ stu_queue.Enqueue(stu[i]); }
            foreach(Student s in stu_queue){ Console.WriteLine(s.ToString()); }
            stu_queue.Dequeue();
        }
        public void stackTest()
        {
            Stack stack = new Stack();
            stack.Push(stu[0]);
            stack.Push(stu[1]);
            // foreach(var s in stack){ Console.WriteLine(s); }
            stack.Pop();
            // Console.WriteLine(stack.Peek());

            Stack<Student> stu_stack = new Stack<Student>();
            for(int i=0;i<stu.Count;i++){ stu_stack.Push(stu[i]); }
            foreach(Student s in stu_stack){ Console.WriteLine(s.ToString()); }
            Console.WriteLine(stu_stack.Peek());
            stu_stack.Pop();
            stu_stack.Pop();
            Console.WriteLine(stu_stack.Peek());
        }
    }
}