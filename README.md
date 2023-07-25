# Shamir's Secret Sharing

A simple implementation in C# of Shamir's secret sharing algorithm.

# How to split a message into shares

```C#
using (var sss = new ShamirSecretSharing() )
{
    var message = "Share your knowledge. It is a way to achieve immortality.";

    var shares = sss.Split(2, 3, message);

    foreach (var share in shares)
    {
        Console.WriteLine(share);
    }
}
```

# How to join shares into a message

```C#
using (var sss = new ShamirSecretSharing() )
{
    var shares = new[] 
    {
        Share.Parse("01-D4C58986F4FC661818FB85094E28EFB6AE17132DC0BDB4318E4D5F67D7516E3C3CF8CFEBE02A47793880C41A5E35A61B5AEDEF12498E80C219E563B98AB41238B800"),
                   
        Share.Parse("02-5523B29A83D954C1BA83EBA72DE16601F8CABEF4515B20EFFB314BAE4D836517FFCF2B68A1F42A8A079B12D09B01DFC944686BC425B38C0B05CAC772156925707001")
    };

    var message = sss.Join(shares);

    Console.WriteLine(message);
}
```