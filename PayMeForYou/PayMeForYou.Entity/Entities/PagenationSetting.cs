namespace PayMeForYou.Entity.Entities
{
    public class PagenationSetting
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int StartIndex => (PageIndex - 1) * PageSize;
    }
}
