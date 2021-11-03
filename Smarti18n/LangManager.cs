using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;


namespace Smarti18n
{
    public class LangManager : Fields, INotifyPropertyChanged
    {
        private CultureInfo _currentCulture = new CultureInfo("en");

        //Static Instance
        public static LangManager Instance => new LangManager();

        //ctor
        public LangManager()
        {
            LoadTranslation(CurrentCulture);
        }

        public CultureInfo CurrentCulture
        {
            get { return _currentCulture; }
            set
            {
                if (_currentCulture != value)
                {
                    _currentCulture = value;
                    LoadTranslation(CurrentCulture);

                    RaisePropertyChanged(nameof(CurrentCulture));
                    RaiseCultureChanged(CurrentCulture);
                }
            }
        }
        public static string LangAppDir { get; set; } = "Languages";
        public static ICollection<string> AvailableCultures => GetAvailableCultures().ToList();

        //For notification as value changed -- would be the one to be overrided
        public virtual event Action<CultureInfo> CultureChanged;
        public void RaiseCultureChanged(CultureInfo newCulture)
        {
            if (CultureChanged != null)
            {
                CultureChanged(newCulture);
            }
        }


        //Load Translation based on CurrentCulture property value
        public void LoadTranslation(CultureInfo culture)
        {
            var jsonTxt = "{}";

            if (AvailableCultures.Contains(culture.TwoLetterISOLanguageName.Trim()))
            {
                jsonTxt = File.ReadAllText(Path.Join("Languages", $"{culture.TwoLetterISOLanguageName.Trim()}.json"));
            }
            else
            {
                try
                {
                    jsonTxt = File.ReadAllText(Path.Join("Languages", "en.json"));
                }
                catch (Exception)
                {
                    //Ignore
                }
            }

            //a JSON Object 
            var obj = JObject.Parse(jsonTxt).ToObject<Fields>();

            //Use reflexion to map Translatable properties
            var translatablePropsNames = new List<string>();

            //Get Translatable Props
            GetType().GetProperties().ToList().ForEach(pInfo =>
            {
                if (pInfo.GetCustomAttribute<TransalatableAttribute>() != null) translatablePropsNames.Add(pInfo.Name);
            });

            //set Transalatable Fields to this LangManager instance from JObject
            translatablePropsNames.ForEach(propName => GetType()
                                                           .GetProperty(propName)
                                                           .SetValue(this, obj.GetType()
                                                                              .GetProperty(propName)
                                                                              .GetValue(obj)));
        }


        //Get Available Cultures
        private static ICollection<string> GetAvailableCultures()
        {
            var _filesList = Directory.EnumerateFiles(LangAppDir, "*.json");
            var _availableCultures = new List<string>();

            if (_filesList.Count() != 0)
            {
                foreach (var file in _filesList)
                {
                    var lang = Path.GetFileNameWithoutExtension(file);
                    _availableCultures.Add(lang);
                }
            }

            return _availableCultures;
        }
    }
}
