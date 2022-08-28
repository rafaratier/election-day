namespace election_day
{
  public class BallotBox
  {
    private int receivedOption1;
    private int receivedOption2;
    private int receivedOption3;
    private int optionNull;

    public int GetCountVoters()
    {
      string? votersQuantityInput;

      do
      {
        Console.Write("Informe o número de eleitores: ");

        votersQuantityInput = Console.ReadLine();
      } while (String.IsNullOrWhiteSpace(votersQuantityInput));

      return Convert.ToInt32(votersQuantityInput);
    }

    public void Start(int countVoters)
    {
      throw new NotImplementedException();
    }

    public void PrintResult()
    {
      throw new NotImplementedException();
    }
  }
}
