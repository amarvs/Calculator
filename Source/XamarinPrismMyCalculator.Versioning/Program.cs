using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XamarinPrismMyCalculator.Versioning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Updating version");
            UpdateUwpVersion(args[0], args[1]);
            UpdateAndroidVersion(args[0], args[1]);
            Console.WriteLine("Version Updated");
        }

        static void UpdateUwpVersion(string version, string build)
        {
            string fileName = @"..\..\..\..\Source\XamarinPrismMyCalculator\XamarinPrismMyCalculator.UWP\Package.appxmanifest";
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(fileName);
                var attributes = xml.LastChild.FirstChild.Attributes;
                foreach (XmlAttribute attr in attributes)
                {
                    if (attr.Name == "Version")
                        attr.Value = version;

                }
                xml.Save(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void UpdateAndroidVersion(string version, string build)
        {
            string fileName = @"..\..\..\..\Source\XamarinPrismMyCalculator\XamarinPrismMyCalculator.Android\Properties\AndroidManifest.xml";
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(fileName);
                var attributes = xml.LastChild.Attributes;

                foreach (XmlAttribute attr in attributes)
                {
                    if (attr.Name == "android:versionCode")
                        attr.Value = build;
                    if (attr.Name == "android:versionName")
                        attr.Value = version;

                }
                xml.Save(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
