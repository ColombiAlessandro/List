using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sikdmf
{
    public class Node
    {

        public Node(string element)
        {
            Element = element;
            Next = null;
        }

        public string Element { get; set; }

        public Node Next { get; set; }

        public override string ToString()
        {
            return "{" + Element + "}";
        }
        public Node(Node n)
        {
            Element = n.Element;
            Next = Next.Clone();
        }
        public Node Clone()
        {
            return new Node(this);
        }

    }

    public class MyList
    {

        private Node Head { get; set; }

        public MyList()
        {
            Head = null;
        }

        public void AddTail(string el)
        {
            Node n = new Node(el);

            //se la lista è vuota
            if (Head == null)
            {
                Head = n;
                return;
            }

            //se la lista non è vuota
            //trovo l'ultimo elementi
            Node i = Head;
            while (i.Next != null)
            {
                i = i.Next;
            }
            //i punta all'ultimo elemento
            i.Next = n;

        }

        public void AddHead(string el)
        {
            Node n = new Node(el);
            n.Next = Head;
            Head = n;
        }

        public void AddPos(string el, int index)
        {
            if (index == 0)
            {
                AddHead(el);
                return;
            }
            if (Head == null && index != 0)
            {
                throw new Exception("index is not valid");
            }
            Node n = new Node(el);
            Node j = Head;
            int i = 0;
            for (i = 0; i < index - 1 && j.Next != null; i++)
            {
                j = j.Next;
            }
            if (i < (index - 1))
            {
                throw new Exception("index is not valid");
            }

            Node temp = j.Next;
            j.Next = n;
            n.Next = temp;

        }

        //metodi da fare per casa

        public Node RemoveHead()
        {
            Node i = new Node(Head.Element);
            Head = Head.Next;
            return i;
        }

        public Node RemoveTail()
        {
            Node i = Head;
            while (i.Next != null)
            {
                i = i.Next;
            }
            Node j = new Node(i.Element);
            i = null;
            return j;
            
        }

        public Node RemovePos(int index)
        {
            if (index == 0)
            {
                Node x = new Node(Head.Element);
                RemoveHead();
                return x;
            }
            if (Head == null && index != 0)
            {
                throw new Exception("index is not valid");
            }
            Node j = Head;
            int i = 0;
            for (i = 0; i < index && j.Next != null; i++)
            {
                j = j.Next;
            }
            
            if (i < (index - 1))
            {
                throw new Exception("index is not valid");
            }
            Node n = j.Next;
            
            while (n.Next != null)
            {
                n.Next = n.Next.Next;
            }
            Node tmp = j.Clone();
            j = null;
            return tmp;

        }

        public int IndexOf(string el)
        {
            Node j = Head;
            int cont = 0;
            while (j.Next != null)
            {
                if (j.Element == el)
                {
                    return cont;
                }
                cont++;
            }
            throw new Exception("element doesn't exist");
        }

        public Node getHead()
        {
            if (Head == null)
            {
                throw new Exception("List is empty");
            }
            return Head.Clone();
        }

        public Node getTail()
        {
            if(Head.Next == null)
            {
                return getHead();
            } else if (Head == null)
            {
                throw new Exception("list is empty");
            }
            Node j = Head;
            while (j.Next != null)
            {
                j = j.Next;
            }
            return j.Clone();
        }

        public string getElement(int index)
        {
                if (index == 0)
                {
                return Head.Element;
                }
                if (Head == null && index != 0)
                {
                    throw new Exception("index is not valid");
                }
                Node j = Head;
                int i = 0;
                for (i = 0; i < index && j.Next != null; i++)
                {
                    j = j.Next;
                }

                if (i < (index - 1))
                {
                    throw new Exception("index is not valid");
                }
            return j.Element;

        }

        public int Count()
        {
            if(Head == null)
            {
                return 0;
            }
            if (Head.Next == null)
            {
                return 1;
            }
            int cont = 0;
            Node j = Head;
            while (j.Next != null)
            {
                j = j.Next;
                cont++;
            }
            return cont;
        }

        public void sort()
        {
            if (Head.Next != null)
            {
                Node j = Head.Next;
                Node f = Head;
                int cont = 0;
                bool primo = true;
                int max = this.Count();
                while (cont < max)
                {
                    while (j.Next != null)
                    {
                        if (primo)
                        {
                            primo = false;
                            if (String.Compare(f.Element, j.Element) > 0)
                            {
                                Node tmp = Head;
                                Head = j;
                                j = tmp;
                                Node tmp2=j.Next;
                                j.Next = Head.Next;
                                Head.Next = j.Next;
                            }

                        } else if (String.Compare(j.Element, j.Next.Element) > 0)
                        {
                            Node tmp = f;
                            f = j;
                            j = tmp;
                            Node tmp2 = j.Next;
                            j.Next = f.Next;
                            f.Next = j.Next;

                        }
                        j = j.Next;
                        f = f.Next;
                    }
                }
            } throw new Exception("list too short");
        }



        public override string ToString()
        {
            string s = "[";

            Node i = Head;
            while (i != null)
            {
                s = s + " " + i.ToString() + " ";
                i = i.Next;
            }

            s = s + "]";

            return s;
        }

    }

    public class Program
    {

        public static void Main(string[] args)
        {
            MyList l = new MyList();
            l.AddTail("Aronne");
            l.AddTail("tomas");
            l.AddTail("Domenico");
            Console.WriteLine(l.ToString());

            l.AddPos("Patelli", 1);

            Console.WriteLine(l.ToString());


            l = new MyList();
            //l.AddPos("Aronne",3);


        }
    }
}
