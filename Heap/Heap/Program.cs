Heap<int> heap = new Heap<int>();

heap.Add(25);
heap.Add(35);
heap.Add(45);
heap.Add(15);
heap.Add(5);
heap.Add(65);

heap.Print();

class Heap<T> where T : IComparable
{
    Node root;

    class Node
    {
        public T data;
        public Node left, right;
    }
    public void Add(T input)
    {
        if (root == null)
        {
            root = new Node();
        }

        AddRecursive(root, input);
    }
    private void AddRecursive(Node root, T input)
    {
        if (input.CompareTo(root.data) <= 0)
        {
            if (root.left != null)
            {
                AddRecursive(root.left, input);
            }
            else
            {
                if (root.right != null)
                {
                    AddRecursive(root.right, input);
                }
            }
        }
    }
    public void Print()
    {
        if (root.left != null)
        {
            PrintRecursive(root);
        }
    }
    private void PrintRecursive(Node root)
    {
        if (root.left != null)
        {
            PrintRecursive(root.left);
        }
        Console.WriteLine(root.data);
        if (root.right != null)
        {
            PrintRecursive(root.right);
        }
    }
    public void Delete(T input)
    {
        Node node = new Node();
        DeleteRecursive(root, node);
    }
    private Node DeleteRecursive(Node root, Node node)
    {
        if (root == null)
        {
            return root;
        }

        if (node.data.CompareTo(root.data) < 0)
        {
            root.left = DeleteRecursive(root.left, node);
        }
        else if (node.data.CompareTo(root.data) > 0)
        {
            root.right = DeleteRecursive(root.right, node);
        }
        else
        {
            if (root.left == null)
            {
                return root.right;
            }
            else if (root.right == null)
            {
                return root.left;
            }
            root.data = GetSmallerData(root.right);

            Node temp = new Node();
            temp.data = root.data;
            root.right = DeleteRecursive(root.right, temp);
        }
        return root;
    }

    private T GetSmallerData(Node root)
    {
        T min = root.data;
        while (root.left != null)
        {
            min = root.left.data;
            root = root.left;
        }
        return min;
    }

    public int GetDepth()
    {
        if (root == null)
        {
            return 0;
        }
        return GetDepthRecursive(root);
    }

    private int GetDepthRecursive(Node root)
    {
        if (root == null)
        {
            return 1;
        }
        int left = GetDepthRecursive(root.left);
        int right = GetDepthRecursive(root.right);
        return left > right ? left : right;
    }
}