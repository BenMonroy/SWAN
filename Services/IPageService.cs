using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SWAN
{
    public interface IPageService
    {
        T? GetPage<T>() where T : class;
        FrameworkElement? GetPage(Type pageType);
    }

}
