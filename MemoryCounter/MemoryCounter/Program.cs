LinkList<int> list = new LinkList<int>();

list.Prepend(1);
list.Show();

class LinkList<T>
{
    Node first, last;
    class Node
    {
        public T data;
        public Node next, prev;
    }

    public void Prepend(T input)
    {
        Node node = new Node();
        node.data = input;
        node.next = first;
    }

    public void Append(T input)
    {
        Node node = new Node();
        node.data = input;

        Node temp = first;
        if (temp == null)
        {
            first = null;
            return;
        }
        while (temp.next != null)
        {
            temp = temp.next;
        }
        temp.next = node;
        node.prev = null;
    }

    public void Show()
    {
        Node temp;
        temp = first;
        while (temp != null)
        {
            Console.WriteLine(temp.data);
        }
    }

    public void Insert(T input, int index)
    {
        if (index == 0)
        {
            Prepend(input);
        }
    }

    public void Sort(T vstup)
    {

    }
}