using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lesson_7
{
    struct Repository
    {
        private Worker[] workers;
        private string path;
        int index;
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.workers = new Worker[1];
        }
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length + 1);
            }
        }
        public void Add(Worker ConcreteWorker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = ConcreteWorker;
            index++;
        }
        public void PrintToConsole()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.workers[i].Print());
            }
        }
        public void Load()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                Worker[] clearArray = new Worker[1];
                clearArray = workers;
                index = 0;
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    args[0] = Convert.ToString(index + 1);
                    Add(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], args[3], args[4], args[5], args[6]));
                }
            }
        }
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(this.path, false, Encoding.Unicode))
            {
                foreach (var staff in workers)
                {
                    sw.WriteLine(staff.Id + "#" +
                        staff.TimeDate + "#" +
                        staff.FullName + "#" +
                        staff.Age + "#" +
                        staff.Growth + "#" +
                        staff.DateOfBirth + "#" +
                        staff.PlaceOfBirth + "#");
                }
            }
        }
        public void Remove(int id)
        {
            int index = id - 1;
            Worker[] newWorkers = new Worker[workers.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newWorkers[i] = workers[i];
            }
            for (int i = index + 1; i < workers.Length; i++)
            {
                newWorkers[i - 1] = workers[i];
            }
            workers = newWorkers;
            this.index--;
        }
        public Worker GetId(int id) => workers.FirstOrDefault(j => j.Id == id);
        public int Count { get { return this.index; } }
        public int IdCount()
        {
            int idCount = Count + 1;
            Console.WriteLine(idCount);
            return idCount;
        }
        public void Edit(Worker staff, int x)
        {
            workers[x - 1] = staff;
        }
        public void DateSearch(string a, string b)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                Worker staff = workers[i];
                if (staff.TimeDate >= Convert.ToDateTime(a) & staff.TimeDate <= Convert.ToDateTime(b).AddDays(1))
                {
                    Console.WriteLine(workers[i].Print());
                }
            }
        }
        public void SortMinMax()
        {
            Worker[] sortStaff = workers;
            sortStaff = sortStaff.OrderBy(e => e.TimeDate).ToArray();
            foreach (var staff in sortStaff)
            {
                Console.WriteLine(staff.Id + " " +
                    staff.TimeDate + " " +
                    staff.FullName + " " +
                    staff.Age + " " +
                    staff.Growth + " " +
                    staff.DateOfBirth + " " +
                    staff.PlaceOfBirth);
            }
        }
        public void SortMaxMin()
        {
            Worker[] sortStaff = workers;
            sortStaff = sortStaff.OrderByDescending(e => e.TimeDate).ToArray();
            foreach (var staff in sortStaff)
            {
                Console.WriteLine(staff.Id + " " +
                    staff.TimeDate + " " +
                    staff.FullName + " " +
                    staff.Age + " " +
                    staff.Growth + " " +
                    staff.DateOfBirth + " " +
                    staff.PlaceOfBirth);
            }
        }
    }
}
