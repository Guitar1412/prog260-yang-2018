using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartArray;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        const int SMART_ARRAY_SIZE = 5;

        // SmartArray should initialize with all zeros
        [TestMethod]
        public void ArrayStartWithAll_0s()
        {
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE);
            //testSmartArray.SetAtIndex(2, 5);  //used to verify test is working
            int actual = 0;
            for (int i = 0; i < SMART_ARRAY_SIZE; i++)
            {
                actual = actual + testSmartArray.GetAtIndex(i);
            }
            // assert
            int expected = 0;
            Assert.AreEqual(expected, actual, 0.000001, "SmartArray not initilized to all zeros");
        }

        // SmartArray should allow setting the 0 location
        [TestMethod]
        public void SetLocation_0()
        {
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(0, 5);
            // assert
            int actual = testSmartArray.GetAtIndex(0);
            int expected = 5;
            Assert.AreEqual(expected, actual, 0.000001, "Did not set SmartArray loc 0 correctly");
        }

        // SmartArray throw exception trying to set location greater than size of array
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetLocationAtSizeOfArrayValue()
        {
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(SMART_ARRAY_SIZE, 15);

            // assert is handled by ExpectedException
        }

        //1. Adding value 11 in to loction 5.
        [TestMethod]
        public void AddValueInLoc()
        {
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(0, 1);
            testSmartArray.SetAtIndex(1, 2);
            testSmartArray.SetAtIndex(2, 3);
            testSmartArray.SetAtIndex(3, 4);
            testSmartArray.SetAtIndex(4, 11);
            // assert
            int actual = testSmartArray.GetAtIndex(4);
            int expected = 11;
            Assert.AreEqual(expected, actual, 0.000001, "Number added in loc 5 is 11.");
        }

        //2. Throw an exception when trying a negative index
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NegativeIndexExcep()
        {
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(SMART_ARRAY_SIZE, -1);
        }

        //3. Return true after finding the value in the array
        [TestMethod]
        public void ReturnTrueTest()
        {
            //Assemble
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(4, 11);
            //Act
            bool resault = testSmartArray.Find(11);
            //Assert
            Assert.IsTrue(resault);
        }

        //4. Return false after finding the value in the array
        [TestMethod]
        public void ReturnFalseTest()
        {
            //Assemble
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE);
            testSmartArray.SetAtIndex(4, 11);
            //Act
            bool resault = testSmartArray.Find(12);
            //bool resault = testSmartArray.Find(11); //To test return false will fail.
            //Assert
            Assert.IsFalse(resault);
        }

        //5. Increase the array length to 10
        [TestMethod]
        public void IncreaseArraySize()
        {
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE+5);
            testSmartArray.SetAtIndex (9, 10);
            int actual = testSmartArray.GetAtIndex(9);
            int expected = 10;
            Assert.AreEqual(expected, actual, 0.000001, "The search is not Loc 10.");
        }

        //6. SmartArray preserve the values of loc 0 to 4 after resize length from 5 to 10
        [TestMethod]
        public void PreValueAfterResize()
        {
            int SMART_ARRAY_SIZE = 5;
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE+5);
            testSmartArray.SetAtIndex(0, 1);
            testSmartArray.SetAtIndex(1, 2);
            testSmartArray.SetAtIndex(2, 3);
            testSmartArray.SetAtIndex(3, 4);
            //testSmartArray.SetAtIndex(9, 0); //Making sure that the array size has increased to 10.
            int actual = testSmartArray.GetAtIndex(0);
            int expected = 1;
            Assert.AreEqual(expected, actual, 0.000001, "loc 0 preserved number is 1.");
        }

        //7. Decrease the array length to 10
        [TestMethod]
        public void DecreaseArraySize()
        {
            int SMART_ARRAY_SIZE = 10;
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE-5);
            //testSmartArray.SetAtIndex(5, 10); //Error testing, to see if the array is decreased down to 5
            //int actual = testSmartArray.GetAtIndex(5);
            testSmartArray.SetAtIndex(4, 10);
            int actual = testSmartArray.GetAtIndex(4);
            int expected = 10;
            Assert.AreEqual(expected, actual, 0.000001, "The arrary length is bigger than 5.");
        }

        //8. SmartArray preserve the values of loc 0 to 4 after resize length from 10 to 5
        [TestMethod]
        public void PreValueAfterResize2()
        {
            int SMART_ARRAY_SIZE = 10;
            SmartArrayClass testSmartArray = new SmartArrayClass(SMART_ARRAY_SIZE - 5);
            testSmartArray.SetAtIndex(0, 1);
            testSmartArray.SetAtIndex(1, 2);
            testSmartArray.SetAtIndex(2, 3);
            testSmartArray.SetAtIndex(3, 4);
            //testSmartArray.SetAtIndex(9, 0); //Will give an error, to making sure that the array size has decreased to 5.
            int actual = testSmartArray.GetAtIndex(0);
            int expected = 1;
            Assert.AreEqual(expected, actual, 0.000001, "loc 0 preserved number is 1.");
        }
    }
}
