using MusicRecordApi.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecordTest
{
    [TestClass]
    public class RecordReposositoryTest
    {
        [TestMethod]
        public void GetAllRecords_ReturnsAllRecords()
        {
            //Arrange
            var repository = new RecordsRepository();

            //Act
            var result = repository.GetAllRecords();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}

     
 