
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Xml;
using UrlWebApp.Models;

namespace UrlWebApp.Services
{

    public interface IDataService
    {
        Object SaveDataToJson(IGenericModel dataToSave);

        ListURLViewModel GetDataSaved();

    }

    public class DataService : IDataService
    {
        public Object SaveDataToJson(IGenericModel dataToSave)
        {
            string jsonToSave = JsonConvert.SerializeObject(dataToSave, Newtonsoft.Json.Formatting.Indented);

            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"dataText.txt");
            File.WriteAllText(fileName, jsonToSave);

            // read text file with model as string
            string textRead = File.ReadAllText(fileName);

            //Converting JSON Array Objects into generic list    
            Object modelRead = JsonConvert.DeserializeObject<Object>(textRead);

            return modelRead;

        }

        public ListURLViewModel GetDataSaved()
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"dataText.txt");  

            // read text file with model as string
            string textRead = File.ReadAllText(fileName);

            ListURLViewModel oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<ListURLViewModel>(textRead);

            return oMycustomclassname;
        }

        #region Commented Notes

        //public URLViewModel GetDataSavedInJson(ExpenseType? expenseType)
        //{
        //    // json file as sample
        //    string jsonFileName = "MyData.json";
        //    // read sample file
        //    var assembly = typeof(MainPage).GetTypeInfo().Assembly;
        //    Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
        //    using (var reader = new System.IO.StreamReader(stream))
        //    {
        //        var jsonString = reader.ReadToEnd();

        //    }

        //    // the bit that worked -----------------------------
        //    //void GetJsonData()
        //    //{
        //    //    string jsonFileName = "contacts.json";
        //    //    ContactList ObjContactList = new ContactList();
        //    //    var assembly = typeof(MainPage).GetTypeInfo().Assembly;
        //    //    Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
        //    //    using (var reader = new System.IO.StreamReader(stream))
        //    //    {
        //    //        var jsonString = reader.ReadToEnd();

        //    //        //Converting JSON Array Objects into generic list    
        //    //        ObjContactList = JsonConvert.DeserializeObject<ContactList>(jsonString);
        //    //    }
        //    //    //Binding listview with json string     
        //    //    listviewConacts.ItemsSource = ObjContactList.contacts;
        //    //}

        //    return new DataStoredViewModel(new NavigationService()); //@todo
        //}

        #endregion
    }
}
