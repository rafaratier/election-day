using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

[Collection("Sequential")]
public class TestThirdReq
{
  [Theory(DisplayName = "Deve imprimir o resultado")]
  [InlineData(new string[] { "6", "1", "1", "5", "A", "3", "2" }, 2, 1, 1, 2)]
  public void TestPrintResult(
      string[] entries,
      int expectedReceivedOption1,
      int expectedReceivedOption2,
      int expectedReceivedOption3,
      int expectedOptionNull)
  {
    using (var stringWriter = new StringWriter())
    {
      using (var stringReader = new StringReader(string.Join("\n", entries)))
      {
        Console.SetOut(stringWriter);
        Console.SetIn(stringReader);

        if (entries.Length <= 0)
        {
          throw new Xunit.Sdk.XunitException();
        }

        Program.Main();

        var ballotResults = stringWriter.ToString().Trim();

        ballotResults.Should().Contain($"A opção 1 recebeu: {expectedReceivedOption1} votos(s)");
        ballotResults.Should().Contain($"A opção 2 recebeu: {expectedReceivedOption2} votos(s)");
        ballotResults.Should().Contain($"A opção 3 recebeu: {expectedReceivedOption3} votos(s)");
        ballotResults.Should().Contain($"Total de votos anulados: {expectedOptionNull} votos(s)");
      }
    }
  }
}