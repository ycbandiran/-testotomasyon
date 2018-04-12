using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support;
using System.Data.SqlClient;
using System.IO;
using Selenium.Helper;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Helpers
{
    public class Helper
    {
        public IWebDriver _driver;
        public IWait<IWebDriver> _task;
        public Random random;
        //public SqlConnection connection;


        public Helper(IWebDriver driver, IWait<IWebDriver> task, string username, string password)
        {
            _driver = driver;
            _task = task;
            random = new Random();
            //connection = new SqlConnection(@"Data Source = NETBLTTSTDB01; Initial Catalog = TicketingDb; Integrated Security = True; MultipleActiveResultSets = True");

            try
            {
                GoToUrl("http://testbackoffice.netasticketing.com");
                SetTextByName("username", username);
                SetTextByName("password", password);
                ClickByXPath("//*[@id='content']/div/div/div/form/footer/button");
                WaitUntilPageLoad();
            }
            catch (Exception exception)
            {
                GiveError(exception.Message, "Login işlemi başarısız.");
            }
        }


        // Veritabanı işlemleri
        #region Veritabanı
        //public void Add()
        //{
        //    SqlCommand command = new SqlCommand("SELECT Name, Color FROM Category WHERE IsActive = '1'", connection);
        //    connection.Open();
        //    SqlDataReader dataReader = command.ExecuteReader();

        //    if (dataReader.HasRows)
        //    {
        //        while (dataReader.Read())
        //        {
        //            Console.WriteLine("{0} {1}", dataReader.GetValue(0), dataReader.GetValue(1));
        //        }
        //    }

        //    connection.Close();
        //}
        #endregion

        // Sayfanın tamamen yüklendiğinden emin olmamızı sağlar
        // Çalışıp çalışmadığı belli değil
        public void WaitUntilPageLoad()
        {
            _task.Until(Driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public void WaitUntilPageLoad2()
        {
            _task.Until((_driver) =>
            {
                return (bool)((RemoteWebDriver)_driver).ExecuteScript("return document.readyState").Equals("complete");
            });
        }



        // path adresine git
        public void GoToUrl(string path)
        {
            try
            {
                _driver.Navigate().GoToUrl(path);
            }
            catch (Exception exception)
            {
                GiveError(exception.Message);
            }
        }

        //Date i string döndürür
        public string DateTimeToString(DateTime date)
        {
            return date.ToString(@"MM\/dd\/yyyy HH:mm");
        }

        // Rastgele metin döndürür
        public string GetRandomString()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).TrimEnd().Substring(0, 8);
        }

        // Rastgele renk değeri döndürür
        public string GetRandomColor()
        {
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }

        public string GetRandomChannelName()
        {
            string chars = "ABCDEFGĞHIİJKLMNOöPQRSŞTUüVWXYZ";
            string[] paymentTypes = new string[] { "POS", "Web", "Channel" };
            string prefix = new string(Enumerable.Repeat(chars, 3).Select(s => s[random.Next(chars.Length)]).ToArray());
            string postfix = paymentTypes[random.Next(paymentTypes.Length)];
            return prefix + "spor" + postfix;
        }

        public string GetRandomInteger(int min, int max)
        {
            return random.Next(min, max + 1).ToString();
        }

        //Xpath üzerinden rastgele bir int değer girer
        public void SetRandomIntegerByXpath(string xpath, int min, int max)
        {

            _driver.FindElement(By.XPath(xpath)).SendKeys(GetRandomInteger(min, max));

        }

        //Name üzerinden rastgele bir int değer girer
        public void SetRandomIntegerByName(string name, int min, int max)
        {

            _driver.FindElement(By.Name(name)).SendKeys(GetRandomInteger(min, max));

        }

        // Rastgele bir dosya dönderir
        public string GetRandomFile(string path)
        {
            path = Path.GetDirectoryName(@"D:\Users\yigitb\Desktop\Images\");
            string[] files = Directory.GetFiles(path);
            int index = random.Next(files.Length);
            string file = files[index];
            return file;
        }

        //Xpath üzerinden rastgele bir file yükler
        public void SetRandomFileByXpath(string xpath, string folderPath)
        {
            IsVisibleByXPath(xpath);
            _driver.FindElement(By.XPath(xpath)).SendKeys(GetRandomFile(folderPath));
        }

        //1-9 arasında rastgele int çağırır
        public static int GetRandomInteger1()
        {
            return new Random().Next(1, 9);
        }

        //Rastgele bir e-mail adresi yazılır
        public static string SetRandomEmail()
        {
            return "yigit.bandiran" + GetRandomInteger1() + "@gmail.com";
        }

        //Name üzerinden rastgele bir email yazar
        public void SetRandomEmailByName(string name)
        {
            _driver.FindElement(By.Name(name)).SendKeys(SetRandomEmail());
        }

        //Name üzerinden rastgele dosya yükler
        public void SetRandomFileByName(string name, string folderPath)
        {
            IsVisibleByName(name);
            _driver.FindElement(By.Name(name)).SendKeys(GetRandomFile(folderPath));
        }

        //bir değerin tutulması için kullanılması gereken fonksiyon
        public string GetTextByXPath(string xpath)
        {
            IsVisibleByXPath(xpath);
            string text = _driver.FindElement(By.XPath(xpath)).Text;
            return text;
        }

        public string GetTextByName(string name)
        {
            IsVisibleByName(name);
            string text = _driver.FindElement(By.Name(name)).Text;
            return text;
        }
        // xpath değerine göre seçilen elementi dönderir
        public IWebElement GetSelectedElementByXPath(string xpath)
        {
            IsVisibleByXPath(xpath);
            return _driver.FindElement(By.XPath(xpath));
        }

        // name değerine göre seçilen elementi dönderir
        public IWebElement GetSelectedElementByName(string name)
        {
            IsVisibleByName(name);
            return _driver.FindElement(By.Name(name));
        }

        // css seçiciye göre seçilen elementi dönderir
        public IWebElement GetSelectedElemenByCssSelector(string cssSelector)
        {
            IsVisibleByCssSelector(cssSelector);
            return _driver.FindElement(By.CssSelector(cssSelector));
        }

        // name değerine sahip elementin içindeki elementleri dönder
        public ICollection<IWebElement> GetElementsByName(string name)
        {
            IsVisibleByName(name);
            return _driver.FindElements(By.Name(name));
        }

        // XPath değeri verilen HTML elementine rastgele değer girer
        public void SetRandomTextByXPath(string xpath)
        {
            IsVisibleByXPath(xpath);
            _driver.FindElement(By.XPath(xpath)).SendKeys(GetRandomString());
        }

        // name değeri verilen HTML elementine rastgele değer girer
        public void SetRandomTextByName(string name)
        {
            IsVisibleByName(name);
            _driver.FindElement(By.Name(name)).SendKeys(GetRandomString());
        }

        public void SetLimitedRandomStringByName(string name, int limit)
        {
            string rondomString = GetRandomString().Substring(0, limit);
            IsVisibleByName(name);
            _driver.FindElement(By.Name(name)).SendKeys(rondomString);

        }

        public void SetLimitedRandomStringByXPath(string xpath, int limit)
        {
            string rondomString = GetRandomString().Substring(0, limit);
            IsVisibleByXPath(xpath);
            _driver.FindElement(By.XPath(xpath)).SendKeys(rondomString);

        }

        // XPath değeri verilen HTML elementine value parametresine verilmiş değeri girer
        public void SetTextByXPath(string xpath, string value)
        {
            IsVisibleByName(xpath);
            _driver.FindElement(By.XPath(xpath)).SendKeys(value);
        }

        // name değeri verilen HTML elementine value parametresine verilmiş değeri girer
        public void SetTextByName(string name, string value)
        {
            IsVisibleByName(name);
            _driver.FindElement(By.Name(name)).SendKeys(value);
        }

        // XPath değeri verilen HTML elementine rastgele renk değeri girer
        public void SetRandomColorByXPath(string xpath)
        {
            IsVisibleByName(xpath);
            _driver.FindElement(By.XPath(xpath)).Clear();
            _driver.FindElement(By.XPath(xpath)).SendKeys(GetRandomColor());
        }

        // name değeri verilen HTML elementine rastgele renk değeri girer
        public void SetRandomColorByName(string name)
        {
            IsVisibleByName(name);
            _driver.FindElement(By.Name(name)).Clear();
            _driver.FindElement(By.Name(name)).SendKeys(GetRandomColor());
        }

        //Xpath e göre rastgele bir tarih girer
        public DateTime SetRandomDateTimeByName(string name)
        {
            DateTime randomDate = GetRandomDateTime();
            _driver.FindElement(By.Name(name)).Clear();         
            _driver.FindElement(By.Name(name)).SendKeys(DateTimeToString(randomDate));
            return randomDate;
        }

        // Belirli bir tarihten sonra rastgele DateTime dönderir
        public DateTime SetRandomDateTimeAfterThisDateTime(DateTime date, int days = 30)
        {
            return date.AddDays(random.Next(1, days));
        }

        // xpath değerine sahip elemente date ile belirtilen tarihi girer
        public void SetDateTimeByName(string name, DateTime date)
        {
            string dateTimeString = DateTimeToString(date);
            _driver.FindElement(By.Name(name)).Clear();
            _driver.FindElement(By.Name(name)).SendKeys(dateTimeString);
        }

        // input tipi file olan alana rastgele bir dosya yerleştir
        // bu metodu çağırırken, dosyaların bulunduğu klasör yolu şu formatta olmalı: @"D:/Users/ocirakli/source/repos/TestOtomasyon/Images/"
        //public void SetRandomFileByXPhat(string xpath, string folderPath)
        //{
        //  IsVisibleByXPath(xpath);
        //_driver.FindElement(By.XPath(xpath)).SendKeys(GetRandomFile(folderPath));
        //}

        // XPath değeri verilen HTML elementine tıklar

        // Henüz kullanılmıyor

        // Rastgele bir tarih dönderir
        public DateTime GetRandomDateTime(int days = 30)
        {
            return DateTime.Now.AddDays(days);
        }

        /*public void RandomDatePicker()
        {
            int range1;
            DateTime start = new DateTime(1995, 1, 1);
            range1 = (DateTime.Today - start).Days;
            start.AddDays(random.Next(range1));
        }
        */
        public ICollection<IWebElement> GetElementsByXpathAndTag(string xpath, string tag)
        {
            IWebElement element = _driver.FindElement(By.XPath(xpath));
            ICollection<IWebElement> elements = element.FindElements(By.TagName(tag));
            return elements;

        }

        public void ClickRandomTagByXPath(string xpath, string tag)
        {
            IsVisibleByXPath(xpath);
            ICollection<IWebElement> elements = GetElementsByXpathAndTag(xpath, tag);
            int length = elements.Count();
            int randomIndex = random.Next(length);
            IsVisibleByXPath(xpath);
            elements.ElementAt(randomIndex).Click();
        }

        //Listeden ilk elemanın seçilmesini sağlayan fonksiyon.

        public int ClickRandomRadioButton(string xpath1, string xpath2)
        {
            int randomIndex = random.Next(2);
            if (randomIndex == 1)
            {
                ClickByXPath(xpath1);
                return 1;
            }
            else
            {
                ClickByXPath(xpath2);
                return 2;
            }


        }

        public string GetRandomLatitude()
        {
            double lat = random.Next(516400146, 630304598);
            lat = 18d + lat / 1000000000d;
            return lat.ToString();
        }

        public string GetRandomLongitude()
        {
            double lon = random.Next(224464416, 341194152);
            lon = -72d - lon / 1000000000d;
            return lon.ToString();
        }

        public void ClickByXPath(string xpath)
        {
            IsClickableByXPath(xpath);
            _driver.FindElement(By.XPath(xpath)).Click();
        }

        // id değeri verilen HTML elementine tıklar
        public void ClickById(string id)
        {
            IsClickableById(id);
            _driver.FindElement(By.Id(id)).Click();
        }

        // name değeri verilen HTML elementine tıklar
        public void ClickByName(string name)
        {
            IsClickableByXPath(name);
            _driver.FindElement(By.Name(name)).Click();
        }

        public void ClickByClassName(string className)
        {
            IsVisibleByClassName(className);
            _driver.FindElement(By.ClassName(className)).Click();
        }

        public void ClickByCssSelector(string cssSelector)
        {
            IsVisibleByClassName(cssSelector);
            _driver.FindElement(By.CssSelector(cssSelector)).Click();
            Console.WriteLine(_driver.FindElement(By.CssSelector(cssSelector)).GetAttribute("value"));
        }

        // Id değeri verilen HTML elementinin tıklanabilir olacağı zamana kadar bekler
        public void IsClickableById(string id)
        {
            _task.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
        }

        // XPath değeri verilen HTML elementinin tıklanabilir olacağı zamana kadar bekler
        public void IsClickableByXPath(string xpath)
        {
            //IsPresenceLocatedByXPath(xpath);
            _task.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }

        // name değeri verilen HTML elementinin tıklanabilir olacağı zamana kadar bekler
        public void IsClickableByName(string name)
        {
            _task.Until(ExpectedConditions.ElementToBeClickable(By.Name(name)));
        }

        // XPath değeri verilen HTML elementinin sayfaya yüklenip yüklenmediğini kontrol et
        public void IsVisibleByXPath(string xpath)
        {
            _task.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        // Name değeri verilen HTML elementinin sayfaya yüklenip yüklenmediğini kontrol et
        public void IsVisibleByName(string name)
        {
            _task.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
        }

        // HTML class değeri verilen HTML elementinin sayfaya yüklenip yüklenmediğini kontrol et
        public void IsVisibleByClassName(string className)
        {
            _task.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));
        }

        // CSS seçisi değeri verilen HTML elementinin sayfaya yüklenip yüklenmediğini kontrol et
        public void IsVisibleByCssSelector(string cssSelector)
        {
            _task.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }

        public void IsPresenceLocatedByXPath(string xpath)
        {
            _task.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath)));
        }

        public string SelectRandomDropdownElementByName(string name)
        {
            IsVisibleByName(name);
            SelectElement element = new SelectElement(_driver.FindElement(By.Name(name)));
            int max = element.Options.Count;
            int index = random.Next(max);
            element.SelectByIndex(index);
            string value = element.SelectedOption.Text;
            //return element.Options[index].GetAttribute("value");
            return value;
        }

        public string SelectRandomDropdownElementByXPath(string xpath)
        {
            IsVisibleByXPath(xpath);
            SelectElement element = new SelectElement(_driver.FindElement(By.XPath(xpath)));
            int max = element.Options.Count;
            int index = random.Next(max);
            element.SelectByIndex(index);
            string value = element.SelectedOption.Text;
            //return element.Options[index].GetAttribute("value");
            return value;
        }

        public void SelectRandomDropdownLabelByXPath(string xpath)
        {
            SelectElement s = new SelectElement(_driver.FindElement(By.XPath(xpath)));
            s.SelectByIndex(random.Next());
        }
        public void SelectRandomCheckboxesByName(string name)
        {
            ICollection<IWebElement> elements = GetElementsByName(name);
            int max = random.Next(elements.Count);

            for (int i = 0; i < max; i++)
            {
                int index = random.Next(elements.Count);
                elements.ElementAt(index).Click();
            }
        }
        public int ClickRandomCheckbox(string xpath1)
        {
            int randomIndex = random.Next(1);
            if (randomIndex == 1)
            {
                ClickByXPath(xpath1);
                return 1;
            }
            else
            {
                return 0;
            }


        }

        // Tek bir checkbox'ı rastgele olarak seçip seçmemeye yarar
        /*public bool SelectRandomCheckboxByName(string name)
        {
            IWebElement checkbox = GetSelectedElementByName("name");
            int check = random.Next(2);

            if (check == 1)
            {
                checkbox.Click();
                return true;
            }

            return false;
        }
        */

        //Program başlangıcını bilgi verir
        public void GiveInfo(params string[] info)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in info)
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }

        //Modüller arası geçişte bilgi verir
        public void GivePassInfo(params string[] info)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in info)
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }

        public void GiveError(params string[] error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in error)
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }

        //Yakaladığı exception ı txt dosyası olarak masaüstüne atar
        public void ErrorLogging(Exception ex)
        {
            string strPath = @"D:\Users\yigitb\Desktop\Exceptions.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }
        public void DenemeClick(string xpath)
        {
            _driver.FindElementExtension(By.XPath(xpath), 1);
        }
    }
}

