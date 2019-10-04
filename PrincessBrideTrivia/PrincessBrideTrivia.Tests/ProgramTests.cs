using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.AreEqual(2, questions.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
        {
            // Arrange
            Question question = new Question();
            question.CorrectAnswerIndex = "1";

            // Act
            bool displayResult = Program.DisplayResult(userGuess, question);

            // Assert
            Assert.AreEqual(expectedResult, displayResult);
        }

        [TestMethod]
        public void GetFilePath_ReturnsFileThatExists()
        {
            // Arrange

            // Act
            string filePath = Program.GetFilePath();

            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }

        [DataTestMethod]
        [DataRow(1, 1, "100%")]
        [DataRow(5, 10, "50%")]
        [DataRow(1, 10, "10%")]
        [DataRow(0, 10, "0%")]
        public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses, 
            int numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }


        private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = "2";
                File.AppendAllLines(filePath, lines);
            }
        }

        public string [] getCorrectAnswersAsStrings(Question [] questions, int numberOfQuestions)

        {
            string[] correctAnswers = new string[numberOfQuestions];
            for (int x = 0; x < numberOfQuestions; x++)
            {
                Question q = questions[x];
                int correctAnswerIndex = (Int32.Parse(q.CorrectAnswerIndex)) - 1;
                correctAnswers[x] = q.Answers[correctAnswerIndex];
            }
            return correctAnswers;
        }

    [TestMethod]
        public void CorrectAnswerIsMarkedCorrectlyAfterRandomAnswerOrder()

        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);
                

                // Act
                Question[] questionsOriginal = Program.LoadQuestions(filePath);
                int numberOfQuestions = questionsOriginal.Length;
                string [] originalCorrectAnswerArray = getCorrectAnswersAsStrings(questionsOriginal,numberOfQuestions);

                Question[] questionsRandomAnswer = Program.LoadQuestionsRandomAnswerOrder(filePath);
                string[] randomCorrectAnswerArray = getCorrectAnswersAsStrings(questionsOriginal, numberOfQuestions);

               

                // Assert 
                for (int x=0; x<numberOfQuestions;x++)
                {
                    Assert.IsTrue(string.Equals(randomCorrectAnswerArray[x], originalCorrectAnswerArray[x]), "correct answers are not marked correctly");
                }


            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void QuestionAnswerOrderIsRandom()

        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act


                Question[] questionsA = Program.LoadQuestionsRandomAnswerOrder(filePath);
                Question[] questionsB = Program.LoadQuestionsRandomAnswerOrder(filePath);

                //Question[] questionsA = Program.LoadQuestions(filePath);
                //Question[] questionsB = Program.LoadQuestions(filePath);



                StringBuilder allAnswersfromQuestionsA = new StringBuilder();
                StringBuilder allAnswersfromQuestionsB = new StringBuilder();

                foreach (Question qA in questionsA)
                {
                    allAnswersfromQuestionsA.Append(string.Concat(qA.Answers));
                }
                foreach (Question qB in questionsB)
                {
                    allAnswersfromQuestionsB.Append(string.Concat(qB.Answers));
                }

                // Assert 
                Assert.IsFalse(string.Equals(allAnswersfromQuestionsA.ToString(), allAnswersfromQuestionsB.ToString()), "Question Answers are not random.");


            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
