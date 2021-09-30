using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Login to Google &Login to the site 'yefe-nof' & Go to Categories -> Sales
            IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory());
            driver.Navigate().GoToUrl("https://yefe.co.il/product-category/%d7%9e%d7%91%d7%a6%d7%a2%d7%99%d7%9d/");

            //Entry into the category of children's books
            IWebElement element = driver.FindElement(By.Id("berocket_aapf_single-28"));
            element.FindElement(By.ClassName("brw-product_cat-%d7%a1%d7%a4%d7%a8%d7%99-%d7%99%d7%9c%d7%93%d7%99%d7%9d-%d7%91%d7%9e%d7%91%d7%a6%d7%a2"))
            .Click();
            Thread.Sleep(2000);

            //Select two different books and add to cart
            IWebElement productsElement = driver.FindElement(By.ClassName("products-container"));
            IWebElement book1Element = productsElement.FindElement(By.CssSelector("li:nth-child(3)"));
            book1Element.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("single_add_to_cart_button")).Click();
            Thread.Sleep(2000);
            driver.Navigate().Back(); driver.Navigate().Back(); Thread.Sleep(2000);
            IWebElement productsElement1 = driver.FindElement(By.ClassName("products-container"));
            IWebElement book2Element = productsElement1.FindElement(By.CssSelector("li:nth-child(5)"));
            book2Element.Click();
            Thread.Sleep(2000);

            //Proceed to the next screen
            driver.FindElement(By.ClassName("single_add_to_cart_button")).Click();
            driver.Navigate().Back(); Thread.Sleep(2000);
            IWebElement cartBtnEle = driver.FindElement(By.Id("mini-cart"));
            cartBtnEle.Click();
            IWebElement cartPopupEle = driver.FindElement(By.ClassName("cart-popup"));
            IWebElement cartPage = cartPopupEle.FindElement(By.CssSelector("a[href='https://yefe.co.il/cart/']"));
            cartPage.Click();
            Thread.Sleep(2000);
            IWebElement e = driver.FindElement(By.Id("panel-cart-total"));
            e.FindElement(By.CssSelector("a[href='https://yefe.co.il/checkout/']")).Click();

            //Full of required fields & Which terms of use
            driver.FindElement(By.Name("billing_first_name")).SendKeys("Esther");
            driver.FindElement(By.Name("billing_last_name")).SendKeys("Winkler");
            driver.FindElement(By.Name("billing_address_1")).SendKeys("זריצקי דוד");
            driver.FindElement(By.Name("billing_address_2")).SendKeys("12");
            driver.FindElement(By.Name("billing_wooccm13")).SendKeys("8");
            driver.FindElement(By.Name("billing_wooccm25")).SendKeys("1");
            driver.FindElement(By.Name("billing_city")).SendKeys("ירושלים");
            driver.FindElement(By.Name("billing_email")).SendKeys("estiwinkler207@gmail.com");
            driver.FindElement(By.Name("billing_wooccm15")).SendKeys("רמות");
            driver.FindElement(By.Name("billing_phone")).SendKeys("0534142685");
            driver.FindElement(By.Name("terms")).Click();

            //Go to the payment page
            driver.FindElement(By.Name("woocommerce_checkout_place_order")).Click();

            //Return to the main page
            driver.FindElement(By.ClassName("BusinessLogoHeight")).Click();

            //Search for a specific book
            driver.FindElement(By.Name("s")).SendKeys("זירת הקולוסיאום");

            //Add to the basket
            IWebElement resSearchEle = driver.FindElement(By.ClassName("aws_result_content"));
            resSearchEle.FindElement(By.ClassName("aws_cart_button_text")).Click();

            //Proceed to the next screen
            driver.FindElement(By.ClassName("single_add_to_cart_button")).Click();
            driver.Navigate().Back(); Thread.Sleep(2000);
            IWebElement cartBtnEle1 = driver.FindElement(By.Id("mini-cart"));
            cartBtnEle1.Click();
            IWebElement cartPopupEle1 = driver.FindElement(By.ClassName("cart-popup"));
            IWebElement cartPage1 = cartPopupEle1.FindElement(By.CssSelector("a[href='https://yefe.co.il/cart/']"));
            cartPage1.Click();
            Thread.Sleep(2000);
            IWebElement e1 = driver.FindElement(By.Id("panel-cart-total"));
            e1.FindElement(By.CssSelector("a[href='https://yefe.co.il/checkout/']")).Click();




        }
    }
}