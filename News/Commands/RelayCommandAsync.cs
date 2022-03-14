using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Commands
{
    internal class RelayCommandAsync : BaseCommandAsync
    {
        public RelayCommandAsync(Func<Task> method, Action<Exception> onException) : base(onException) 
        {
            _method = method;
        }

        public override async Task ExecuteAsync(object parametr) => await _method();

        private Func<Task> _method;
    }
}
