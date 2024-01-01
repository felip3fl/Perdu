using FL.Perdu.Csv;
using FL.Perdu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace FL.Perdu.Work.Services
{
    public class LocalFileService
    {
        public List<ProgramDetail> programDetails = new List<ProgramDetail>();

        public void LoadProgramDetail()
        {
            var dataFromFile = ReadFile();
            var currentLineNumber = 0;

            while (!dataFromFile.EndOfStream)
            {
                var lineValues = dataFromFile.ReadLine();
                var columnValues = lineValues.Split(';');

                programDetails.Add(new ProgramDetail { 
                    Order = currentLineNumber, 
                    Address = columnValues[0], 
                    BackupAddress = columnValues[1] 
                });

                currentLineNumber++;
            }

            RemoveHead(programDetails);

            DefineProgramName(programDetails);
        }

        private StreamReader ReadFile()
        {
            var reader = new StreamReader(@"C:\Users\felip\Source\FL_PERDU\Source\source.csv");
            return reader;
        }

        private void RemoveHead(List<ProgramDetail> programDetails)
        {
            programDetails.Remove(programDetails[0]);
        }

        private void DefineProgramName(List<ProgramDetail> programDetails)
        {
            foreach (var item in programDetails)
            {
                string[] parts = item.BackupAddress.Split('\\');
                string lastWord = parts[parts.Length - 2];
                item.Name = lastWord;
            }
        }

    }
}
