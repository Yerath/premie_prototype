using LicentieService.Agents;
using LicentieService.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace LicentieServiceTests.Agents
{
    [TestClass]
    public class LicentieAgentTest
    {
        private LicentieAgent _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new LicentieAgent();
        }

        [TestMethod]
        public void RetrieveTokenShouldReturnTokenIfUserIsKnow()
        {
            var result = _sut.RetrieveToken("dimitry", "volker");
            result.ShouldBe("eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJVTklUNCJ9.QXtZsYJvr0hXy8k4o56YqdW2zmX9b_FRdK84J-rYdv0");
        }

        [TestMethod]
        public void RetrieveTokenShouldThrowExceptionWhenUserIsNotFound()
        {
            Should.Throw<InvalidUserException>(() => { _sut.RetrieveToken("invalid", "user"); });
        }
    }
}
