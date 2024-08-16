public class Question{
    public string questionText;
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;
    public char correctAnswerLetter;

    private static char defaultCorrectAnswerLetter;

    static Question(){
        defaultCorrectAnswerLetter = 'X';
    }

    public Question(){
        correctAnswerLetter = defaultCorrectAnswerLetter;
    }

    public Question(string questionText){
        
        this.questionText = questionText;
        correctAnswerLetter = defaultCorrectAnswerLetter;
    }


public Question(string questionText,string optionA,string optionB,string optionC,string optionD){
        this.questionText = questionText;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.optionD = optionD; 
        this.correctAnswerLetter = defaultCorrectAnswerLetter;
    }
    public Question(string questionText,string optionA,string optionB,string optionC,string optionD ,char correctAnswerLetter){
        this.questionText = questionText;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.optionD = optionD; 
        this.correctAnswerLetter = correctAnswerLetter;
    }

    public bool AreOptionsValid(){
        int inValidOptions = 0;
        inValidOptions += optionA == null ? 1 : 0;
        inValidOptions += optionB == null ? 1 : 0;
        inValidOptions += optionC != null ? 1 : 0;   
        inValidOptions += optionD != null ? 1 : 0;   
        return inValidOptions <=2;
    }


}