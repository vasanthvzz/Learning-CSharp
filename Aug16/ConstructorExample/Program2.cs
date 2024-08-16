class Program2
{
    static void Main2()
    {
        //TO DO: Create an object of Question class and pass no arguments to the constructor
        Question question = new Question();

        //TO DO: Create an object of Question class and pass value for questionText only to the constructor.
        Question question1 = new Question("What is the smallest dog breed");

        //TO DO: Create an object of Question class and pass values for questionText, optionA, optionB, optionC, optionD and correctAnswerLetter to the constructor.
        Question question2 = new Question("What is the fastest animal","lion","tiger","cheetah","jaguar",'C');

        //TO DO: Create an object of Question class and pass values for questionText, optionA, optionB, optionC, optionD only to the constructor.
        Question question3 = new Question("What is the fastest animal","lion","tiger","cheetah","jaguar");
    }
}