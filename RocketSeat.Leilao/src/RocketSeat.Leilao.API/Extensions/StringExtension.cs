namespace RocketSeat.Leilao.API.Extensions;

public static class StringExtension
{
    public static string FromBase64(this string value)
    {
        var dados = Convert.FromBase64String(value);

        return System.Text.ASCIIEncoding.UTF8.GetString(dados);
    } 
}
