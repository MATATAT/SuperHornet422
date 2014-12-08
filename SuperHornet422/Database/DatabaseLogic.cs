using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace SuperHornet422.Database
{    
    public class DatabaseLogic
    {
        string DATABASE_FILENAME = "StoreScoresDatabase.xml";

        /// <summary>
        /// Adds name and corresponding score to the database. Returns true on successful add, false otherwise.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public bool AddToDatabase(string name, int score)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            

            if (!store.FileExists(DATABASE_FILENAME))
            {
                CreateDatabase(name, score);
                return true;
            }
            if (InDatabase(name))
            {
                return false;
            }

            Dictionary<string, int> scores = ReadDatabase();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("\t");
            IsolatedStorageFileStream isoStream = store.OpenFile(DATABASE_FILENAME, FileMode.Open, FileAccess.Write);
            XmlWriter textWriter = XmlWriter.Create(isoStream, settings);

            textWriter.WriteStartElement("ScoresDatabase");

            //Add values already in database
            foreach (KeyValuePair<string, int> entry in scores)
            {
                textWriter.WriteStartElement("Entry");

                textWriter.WriteStartElement("Name");
                textWriter.WriteString(entry.Key);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("Score");
                textWriter.WriteString(entry.Value.ToString());
                textWriter.WriteEndElement();

                textWriter.WriteEndElement(); //Entry end
            }

            textWriter.WriteStartElement("Entry");

            textWriter.WriteStartElement("Name");
            textWriter.WriteString(name);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Score");
            textWriter.WriteString(score.ToString());
            textWriter.WriteEndElement();

            textWriter.WriteEndElement(); //Entry end

            textWriter.WriteEndElement(); //ScoresDatabse end

            textWriter.WriteEndDocument();
            textWriter.Close();

            isoStream.Close();

            return true;
        }

        private void CreateDatabase(string name, int score)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();

            if (store.FileExists(DATABASE_FILENAME))
            {
                store.DeleteFile(DATABASE_FILENAME);
            }

            IsolatedStorageFileStream isoStream = store.OpenFile(DATABASE_FILENAME, FileMode.CreateNew, FileAccess.Write);            

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("\t");

            XmlWriter textWriter = XmlWriter.Create(isoStream, settings);                          

            textWriter.WriteStartElement("ScoresDatabase");
            textWriter.WriteStartElement("Entry");

            textWriter.WriteStartElement("Name");
            textWriter.WriteString(name);
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("Score");
            textWriter.WriteString(score.ToString());
            textWriter.WriteEndElement();

            textWriter.WriteEndElement(); //Score end
            textWriter.WriteEndElement(); //ScoresDatabse end

            textWriter.WriteEndDocument();
            textWriter.Close();

            isoStream.Close();            
        }

        /// <summary>
        /// Reads database. Returns all entries as a dictionary. Names are keys, scores are values.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> ReadDatabase()
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream isoStream = store.OpenFile(DATABASE_FILENAME, FileMode.Open, FileAccess.Read);

            Dictionary<string, int> scores = new Dictionary<string, int>();
            XmlReader reader = XmlReader.Create(isoStream);
            string currName = null;
            int currScore = 0;

            while (reader.Read())
            {
                if (reader.Name == "Name")
                {
                    reader.Read();
                    currName = reader.Value;
                    reader.Read();
                }

                if (reader.Name == "Score")
                {
                    reader.Read();
                    currScore = int.Parse(reader.Value);
                    scores.Add(currName, currScore);
                    reader.Read();
                }
            }

            reader.Close();
            isoStream.Close();
            return scores;
        }

        /// <summary>
        /// Finds corresponding score for name. Returns score. Returns -1 if score is not found.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int FindScore(string name)
        {
            Dictionary<string, int> scores = ReadDatabase();

            foreach (KeyValuePair<string, int> entry in scores)
            {
                if (entry.Key == name)
                {
                    return entry.Value;
                }
            }

            return -1;
        }

        /// <summary>
        /// Checks to see if name is in database. Returns true if so, false otherwise.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool InDatabase(string name)
        {
            Dictionary<string, int> scores = ReadDatabase();

            foreach (KeyValuePair<string, int> entry in scores)
            {
                if (entry.Key == name)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Changes score in database to newScore for name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newScore"></param>
        public void UpdateScore(string name, int newScore)
        {
            Dictionary<string, int> scores = ReadDatabase();

            foreach (KeyValuePair<string, int> entry in scores)
            {
                if (entry.Key == name)
                {
                    scores.Remove(entry.Key);
                    break;
                }
            }

            CreateDatabase(name, newScore);

            foreach (KeyValuePair<string, int> entry in scores)
            {
                AddToDatabase(entry.Key, entry.Value);
            }
        }

        /// <summary>
        /// Prints score to debug in output window. For diagnostic purposes only.
        /// </summary>
        public void PrintDatabase()
        {
            Dictionary<string, int> scores = ReadDatabase();

            Debug.WriteLine("");
            foreach (KeyValuePair<string, int> entry in scores)
            {
                Debug.WriteLine(entry.Key.ToString() + " " + entry.Value.ToString());
            }
        }
    }
}
