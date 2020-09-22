namespace Royal.Pages
{
    public abstract class PageBase
    {
        public readonly HeaderNav headerNav;
        public PageBase()
        {
            headerNav = new HeaderNav();
        }
    }
}
    