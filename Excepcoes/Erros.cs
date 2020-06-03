using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepcoes
{
    /// <summary>
    /// Excepção se não existir auditoria
    /// </summary>
    public class AuditoriaInexistenteException : ApplicationException 
    {
        public AuditoriaInexistenteException() : base("Auditoria Inexistente!!") { }
        public AuditoriaInexistenteException(string s) : base(s) { }
        public AuditoriaInexistenteException(string s, Exception e) 
        {
            throw new AuditoriaInexistenteException(e.Message + " - " + s);
        }
    }
    /// <summary>
    /// Excepção se não existir vulnerabilidade
    /// </summary>
    public class VulnerabilidadeInexistenteException : ApplicationException
    {
        public VulnerabilidadeInexistenteException() : base("Vulnerabilidade Inexistente!!") { }
        public VulnerabilidadeInexistenteException(string s) : base(s) { }
        public VulnerabilidadeInexistenteException(string s, Exception e)
        {
            throw new VulnerabilidadeInexistenteException(e.Message + " - " + s);
        }
    }
    /// <summary>
    /// Excepção se não existir Colaborador
    /// </summary>
    public class ColaboradorInexistenteException : ApplicationException
    {
        public ColaboradorInexistenteException() : base("Colaborador Inexistente!!") { }
        public ColaboradorInexistenteException(string s) : base(s) { }
        public ColaboradorInexistenteException(string s, Exception e)
        {
            throw new ColaboradorInexistenteException(e.Message + " - " + s);
        }
    }
    /// <summary>
    /// Excepção se não conseguir inserir
    /// </summary>
    public class InsercaoException : ApplicationException
    {
        public InsercaoException() : base("Inserção Inválida!!"){}
        public InsercaoException(string s) : base(s) { }
        public InsercaoException(string s, Exception e)
        {
            throw new InsercaoException("ERRO: " + s + " - " + e.Message);
        }
    }
}
