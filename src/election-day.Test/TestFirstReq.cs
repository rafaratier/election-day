using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

[Collection("Sequential")]
public class TestFirstReq
{
  [Theory(DisplayName = "Deve retornar a quantidade de eleitores recebida como entrada.")]
  [InlineData(1)]
  public void TestGetCountVoters(int countVoters)
  {
    if (countVoters <= 0)
    {
      throw new Xunit.Sdk.XunitException();
    }

    var ballotBox = new BallotBox();

    using (var stringWriter = new StringWriter())
    {
      using (var stringReader = new StringReader(Convert.ToString(countVoters)))
      {
        Console.SetOut(stringWriter);
        Console.SetIn(stringReader);

        int votersQuantity = ballotBox.GetCountVoters();

        votersQuantity.Should().Be(countVoters);
      }
    }
  }
}
