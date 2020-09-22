using System;
using FrameWork.Selenium;
using OpenQA.Selenium;

namespace Royal.Pages
{
    public class HeaderNav
    {
      public readonly HeaderNavMap map;
      public HeaderNav(){

        map= new HeaderNavMap();

      }
      public void GoToCardsPage()
      {
        map.CardsTabLink.Click();
      }
    }

     public class HeaderNavMap
    {
        public IWebElement CardsTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"));
        
    }
}
