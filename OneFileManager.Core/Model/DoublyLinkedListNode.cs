using System;
using System.Collections.Generic;
using System.Text;

namespace OneFileManager.Core.Model
{
    //双向链表节点类(用来存储用户的历史访问路径)
    public class DoublyLinkedListNode
    {
          //保存的路径
            public string Path { set; get; }
            public DoublyLinkedListNode PreNode { set; get; }
            public DoublyLinkedListNode NextNode { set; get; }
    }
}
