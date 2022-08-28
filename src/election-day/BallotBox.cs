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
      for (var index = 1; index <= countVoters; index++)
      {
        Console.WriteLine($"Digite o número do candidato de 1 a 3: ");
        string? vote = Console.ReadLine();

        switch (vote)
        {
          case "1": receivedOption1++; break;
          case "2": receivedOption2++; break;
          case "3": receivedOption3++; break;
          default: optionNull++; break;
        }

        Console.WriteLine($"Voto registrado.");
        Console.WriteLine($"Votação finalizada!!!");
      }
    }

    public void PrintResult()
    {
      Console.WriteLine($"A opção 1 recebeu: {receivedOption1} votos(s)");
      Console.WriteLine($"A opção 2 recebeu: {receivedOption2} votos(s)");
      Console.WriteLine($"A opção 3 recebeu: {receivedOption3} votos(s)");
      Console.WriteLine($"Total de votos anulados: {optionNull} votos(s)");
    }
  }
}
