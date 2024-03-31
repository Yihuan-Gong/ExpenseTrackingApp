using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 記帳
{
    internal static class DebounceExtension
    {
        private static System.Threading.Timer singletonTimer;

        public static void DebounceHandler(this Form form, Action callback, int debounceTime = 1000)
        {

            if (singletonTimer != null)
            {
                singletonTimer.Change(debounceTime, Timeout.Infinite);
                return;
            }
            form.Tag = callback;

            singletonTimer = new System.Threading.Timer
            (
                HandleDebounce,
                form,
                debounceTime,
                Timeout.Infinite
            );
        }

        private static void HandleDebounce(object sender)
        {
            Form form = sender as Form;
            Action action = form.Tag as Action;

            form.Invoke((Action)(() =>
            {
                action.Invoke();
            }));
        }
    }
}
