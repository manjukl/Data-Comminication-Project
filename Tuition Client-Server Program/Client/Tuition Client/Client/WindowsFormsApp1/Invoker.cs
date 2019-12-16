using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace Tuition
{
    public class Invoker
    {
        private Stack<Command> redoStack;
        private Stack<Command> undoStack;

        public Invoker()
        {
            undoStack = new Stack<Command>();
            redoStack = new Stack<Command>();
        }


        public void Add(Student stu, Admin ad )
        {
            AddStudent add = new AddStudent(stu, ad);
            add.Execute();
            undoStack.Push(add);
            redoStack.Clear();
        }

        public void Remove(Student stu, Admin ad)
        {
            RemoveStudent rem = new RemoveStudent(stu, ad);
            rem.Execute();
            undoStack.Push(rem);
            redoStack.Clear();
        }
        public Boolean canUndo()
        {
            if (undoStack.Count > 0)
                return true;
            else
                return false;
        }
        public Boolean canRedo()
        {
            if (redoStack.Count > 0)
                return true;
            else
                return false;
        }
        public void Undo()
        {
            Command cmd = undoStack.Pop();
            cmd.Unexecute();
            redoStack.Push(cmd);
        }
        public void Redo()
        {
            Command cmd = redoStack.Pop();
            cmd.Execute();
            undoStack.Push(cmd);
        }
    }
}
