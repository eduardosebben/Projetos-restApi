namespace Relatorios.Aplication.Common.Estruturas
{
    public sealed record Error(string codigo, string? Mensagem = null)
    {
        public static readonly Error None = new(string.Empty);

        //public static implicit operator Result<TValue,Error>(Error error) => Result.Failure(error);
    }
}
