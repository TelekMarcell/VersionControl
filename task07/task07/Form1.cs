using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using task07.Entities;

namespace task07
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbalitily> BirthProbabilities = new List<BirthProbalitily>();
        List<DeathProbalitily> DeathProbabilities = new List<DeathProbalitily>();
        public Form1()
        {
            InitializeComponent();
            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<BirthProbalitily> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbalitily> birthprb = new List<BirthProbalitily>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthprb.Add(new BirthProbalitily()
                    {
                        BirthYear = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        BProbalitily = double.Parse(line[2])
                    });
                }
            }

            return birthprb;
        }

        public List<DeathProbalitily> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbalitily> deathprb = new List<DeathProbalitily>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    deathprb.Add(new DeathProbalitily()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        DeathProba = double.Parse(line[2])
                    });
                }
            }

            return deathprb;
        }

    }
}
