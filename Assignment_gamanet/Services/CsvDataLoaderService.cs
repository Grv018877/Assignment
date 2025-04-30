using Assignment_gamanet.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_gamanet.Services
{
    public class CsvDataLoaderService
    {
        private _MainPanelContext _mpContext;

        public CsvDataLoaderService(_MainPanelContext context)
        {
            _mpContext = context;
        }
        public IEnumerable<PersonEntity> LoadDataFromCsv(string csvFilePath)
        {
            var Persons = new List<PersonEntity>();
            using (TextFieldParser parser = new TextFieldParser(csvFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.HasFieldsEnclosedInQuotes = true;

                if (!parser.EndOfData)
                {
                    string[] headerFields = parser.ReadFields(); //Headers
                }

                // Read and process the rest of the rows
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields.Length >= 6) // Ensure there are enough columns
                    {
                        var person = new PersonEntity
                        {
                            Name = fields[0],
                            Country = fields[1],
                            Address = fields[2],
                            PostalZip = fields[3],
                            Email = fields[4],
                            Phone = fields[5]
                        };

                        Persons.Add(person);
                    }

                }
            }
            return Persons;
        }
    }
}