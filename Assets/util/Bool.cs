using System;
using System.Threading.Tasks;

namespace Util{
    public static class Bool{
        public static async Task SetBoolAfterDelay(Action action, float delayTime){
            await Task.Delay((int)(delayTime*1000));
            action();
        }
    }
}