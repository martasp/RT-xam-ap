using System;

namespace app5.MaterDetailPages
{

    public class MasterDetailPage1MenuItem
    {
        public MasterDetailPage1MenuItem(Type pageType)
        {
            TargetType = pageType;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}