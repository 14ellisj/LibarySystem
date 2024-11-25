using Media_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Serivce.Tests.Models
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void Filter_NoAuthor_ReturnTrue()
        {
            //Arrange
            var query = "";
            var expectedResult = true;
            var author = new Author();

            //Act
            var result = author.Filter(query);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Filter_OneName_TrueWhenFirstContains()
        {
            var query = "test";
            var firstName = query + query;

            var author = new Author() { FirstName = firstName };

            var result = author.Filter(query);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Filter_OneName_TrueWhenLastContains()
        {
            var query = "test";
            var lastName = query + query;

            var author = new Author() { LastName = lastName };

            var result = author.Filter(query);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Filter_OneName_FalseWhenFirstDoesNotContain()
        {
            var query = "test2";
            var firstName = query.Substring(0, query.Length - 2);

            var author = new Author() { FirstName = firstName };

            var result = author.Filter(query);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Filter_OneName_FalseWhenLastDoesNotContain()
        {
            var query = "test2";
            var lastName = query.Substring(0, query.Length - 2);

            var author = new Author() { LastName = lastName };

            var result = author.Filter(query);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Filter_TwoName_TrueWhenFirstContainsFirst()
        {
            var query = "test two";
            var firstName = query.Split(" ").First();
            var lastName = "";

            var author = new Author() { FirstName = firstName, LastName = lastName };

            var result = author.Filter(query);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Filter_TwoName_TrueWhenFirstContainsLast()
        {
            var query = "test two";
            var firstName = query.Split(" ").Last();
            var lastName = "";

            var author = new Author() { FirstName = firstName, LastName = lastName };

            var result = author.Filter(query);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Filter_TwoName_TrueWhenLastContainsFirst()
        {
            var query = "test two";
            var firstName = "";
            var lastName = query.Split(" ").First();

            var author = new Author() { FirstName = firstName, LastName = lastName };

            var result = author.Filter(query);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Filter_TwoName_TrueWhenLastContainsLast()
        {
            var query = "test two";
            var firstName = "";
            var lastName = query.Split(" ").Last();

            var author = new Author() { FirstName = firstName, LastName = lastName };

            var result = author.Filter(query);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Filter_TwoName_FalseWhenFirstAndLastNotContained()
        {
            var query = "test two";
            var firstName = "tes";
            var lastName = "tw";

            var author = new Author() { FirstName = firstName, LastName = lastName };

            var result = author.Filter(query);

            Assert.IsFalse(result);
        }
    }
}
