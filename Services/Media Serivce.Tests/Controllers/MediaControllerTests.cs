using Media_Service.Database;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Serivce.Tests.Controllers
{
    [TestClass]
    public class MediaControllerTests
    {
        Mock<AppDbContext> _appDbContextMock;
        

        public MediaControllerTests()
        {
            _appDbContextMock = new Mock<AppDbContext>();

            
        }

        [TestMethod]
        public void Get_NoFilters_ShowAllResults()
        {
            
        }
    }
}
