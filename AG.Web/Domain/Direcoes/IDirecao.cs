namespace AG.Web.Domain
{
    /// <summary>
    /// NORTE = "01";
    /// LESTE = "00";
    /// OESTE = "10";
    /// SUL = "11";
    /// </summary>
    public interface IDirecao
    {
        public string Valor { get;  }
    }
}
