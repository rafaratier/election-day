using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

[Collection("Sequential")]
public class TestSecondReq
{
  [Theory(DisplayName = "Deve ler os votos")]
  [InlineData(2, 2)]
  public void TestStart(int countVoters, int printExpected)
  {
    using (var stringWriter = new StringWriter())
    {
      using (var stringReader = new StringReader(countVoters.ToString()))
      {

        Console.SetOut(stringWriter);
        Console.SetIn(stringReader);

        var ballotBox = new BallotBox();
        ballotBox.Start(countVoters);

        var result = stringWriter.ToString().Trim().Split("\n");
        result.Length.Should().Be(printExpected * 2);
      }
    }
  }
}