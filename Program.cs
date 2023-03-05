
static class Program
{
    static void Main(string[] args)
    {
        SLL test = new SLL();
        test.Add(1,'a');
        test.Add(2,'b');
        test.Add(3,'c');
        test.Add(4,'d');
        test.Add(5,'e');
        test.Print();
        test.Add(3, 'z');
        test.Print();
        test.Remove(3);
        test.Print();

    }
}

public class Node
{
    public char x;
    public Node? next;

    public Node(char x)
    {
        this.x = x;
        next = null;
    }
}

public class SLL
{
    private Node? head;
    private Node? tail;
    private int n;

    public SLL()
    {
        head = null;
        tail = null;
    }

    // Returns an element at position i, counting from the head of the list as the element 1.
    public char? Get(int i)
    {
        Node u = head;
        if (i > n) return null;
        for (int count = 1; count < i; count++)
        {
            u = u.next;
        }
        return u.x;
    }

    // Sets the provided char to the element at position i, counting from the head of the list as element 1.
    // Returns true on success, false on failure.
    public bool Set(int i, char x)
    {
        Node u = head;
        if (i > n) return false; // Position is greater than nnumber of elements.
        for (int count = 1; count < i; count++)
        {
            u = u.next;
        }
        u.x = x;
        return true;

    }

    // Right-shifts all elements from position i, counting from the head as element 1, then adds a new node to the list at position i.
    public void Add(int i, char x)
    {
        Node u = new(x);
        
        // New element is the only one in the list, therefore it must be the head and tail
        if (n == 0)
        { 
            head = u;
            tail = u;
            n++;
            return;
        }

        u.next = head;
        // If requeted position is 1, the new node will become the head.
        if (i == 1)
        {
            head = u;
            n++;
            return;
        }


        Node t = new('a'); // Temp node used to store position before new node, needed to keep tack of .next pointer
        t.next = head;
        u.next = head.next;


        for (int count = 1; count < i - 1; count++)
        {
            t.next = u.next;
            u.next = (u.next).next;
        }
        (t.next).next = u;
        n++;
        return;
    }

    // Removes an element at position i, counting from the head as element 1.
    // Returns false if there's a failure, otherwrise returns true.
    public bool Remove(int i)
    {
        if (n == 0) return false; // No elements in the list to remove
        if (n == 1) // List will be empty, head and tail become nulls.
        {
            head = null;
            tail = null;
            n--;
            return true;
        }
        if (i == 1) // Remove the head, new head will be the 2nd element in the list.
        {
            head = head.next;
            n--;
            return true;
        }

        Node t = new('a'); // Temp node to iterate through the list
        t.next = head;

        for (int count = 1; count < i - 1; count++)
        {
            t.next = (t.next).next;
        }
        (t.next).next = ((t.next).next).next; // Removes a node by setting the current .next pointer by jumping the next element.
        n--;
        return true;
    }

    // Prints all elements in the list
    public void Print()
    {
        Node current = this.head;
        Console.Write("Contents: ");
        while (current != null)
        {
            Console.Write(current.x);
            current = current.next;
        }
        Console.WriteLine();
    }
}
