namespace Rabbits
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capcity)
        {
            this.Name = name;
            this.Capacity = capcity;
            this.data = new List<Rabbit>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get => this.data.Count; }

        public void Add(Rabbit rabbit)
        {
            if (this.Capacity > 0)
            {
                this.data.Add(rabbit);
                this.Capacity--;
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit selected = this.data.FirstOrDefault(x => x.Name == name);
            this.Capacity++;
            return this.data.Remove(selected);
        }

        public void RemoveSpecies(string species)
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                Rabbit selected = this.data[i];
                if (selected.Species == species)
                {
                    this.data.RemoveAt(i);
                    this.Capacity++;
                    i--;
                }
            }
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit selected = this.data.FirstOrDefault(x => x.Name == name);
            selected.Available = false;
            return selected;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] arr = this.data.Where(x => x.Species == species).ToArray();
            foreach (var item in arr)
            {
                item.Available = false;
            }
            return arr;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.data.Where(x => x.Available == true))
            {
                sb.AppendLine(rabbit.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
