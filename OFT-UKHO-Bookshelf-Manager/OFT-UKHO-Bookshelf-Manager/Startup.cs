using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace OFT_UKHO_Bookshelf_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
