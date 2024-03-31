using 記帳;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

namespace 記帳
{
    internal class SingletonForm
    {
        private static readonly Dictionary<string, Form> instantiatedFormDictionary
            = new Dictionary<string, Form>();

        public static Form prevForm;

        private SingletonForm()
        {

        }

        public static Form GetInstance(string formDisplayName)
        {
            Form currentForm;

            prevForm?.Hide();

            instantiatedFormDictionary.TryGetValue(formDisplayName, out currentForm);

            if (currentForm == null)
            {
                currentForm = CreateFormInstanceByDisplayName(formDisplayName);
                instantiatedFormDictionary.Add(formDisplayName, currentForm);
            }

            prevForm = currentForm;
            return currentForm;
        }

        private static Form CreateFormInstanceByDisplayName(string displayName)
        {
            // 取得所有在目前執行環境中已載入的型別
            var types = AppDomain.CurrentDomain.GetAssemblies()
                             .SelectMany(s => s.GetTypes())
                             .Where(p => typeof(Form).IsAssignableFrom(p) && p.IsClass);

            // 透過反射找到對應 DisplayName 的 Form 實例
            foreach (var type in types)
            {
                var displayNameAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
                if (displayNameAttribute != null && displayNameAttribute.DisplayName == displayName)
                {
                    // 找到對應的型別，實例化並返回
                    return (Form)Activator.CreateInstance(type);
                }
            }

            // 找不到對應 DisplayName 的實例
            return null;
        }
    }

}

